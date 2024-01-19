using System.IO;
using TextProcessor.Data;
using TextProcessor.Processor;

namespace TextProcessor
{
    public partial class FormTextProcessor : Form
    {
        private CancellationTokenSource cancellationTokenSource = new();
        

        public FormTextProcessor()
        {
            InitializeComponent();
            bsTextStatistic.DataSource = new FileStatisticData();
            ProgressBar(false);
        }

        private async void beInputFile_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            beInputFile.Enabled = false;

            if (await TextProcessorRunnig(fileStatisticData)) return;
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                using var openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                openFileDialog.Filter = @"Text Files (*.txt)|*.txt";
                fileStatisticData.InputFile = openFileDialog.FileName;
                bsTextStatistic.ResetBindings(false);

                fileStatisticData.Operation = OperationProcessor.Input;
                var processor = new AnalyzeProcessor(bsTextStatistic);
                ProgressBar(true);
                await Task.Run(() => processor.Process(UpdateProgressBar, cancellationTokenSource.Token),
                    cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                // The task was canceled, handle accordingly
                UpdateUI(fileStatisticData);
                MessageBox.Show(@"Analýza vstupního souboru přerušena.", @"Přerušení", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            finally
            {
                CloseProcessUI();
                beInputFile.Enabled = true;
                ProgressBar(false);
            }
        }

        private async Task<bool> TextProcessorRunnig(FileStatisticData fileStatisticData)
        {
            if ((new[]
                {
                    OperationProcessor.SpecialFormat, OperationProcessor.RemoveDiacritics,
                    OperationProcessor.RemoveEmptyLine, OperationProcessor.Copy, OperationProcessor.Input
                }).Contains(fileStatisticData.Operation))
            {
                if (MessageBox.Show(@"Předchozí analýza stále probíhá chcete jí zrušit ?", @"Otázka",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return true;
                }

                await cancellationTokenSource.CancelAsync();

                
                while (fileStatisticData.Operation != OperationProcessor.None)
                {
                    await Task.Delay(1000);
                }
            }

            return false;
        }

        private void beOutputFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;

            using var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            saveFileDialog.Filter = @"Text Files (*.txt)|*.txt";
            fileStatisticData.OutputFile = saveFileDialog.FileName;
            bsTextStatistic.ResetBindings(false);
        }

        private async void CopyActionButton_Click(object sender, EventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            if (await TextProcessorRunnig(fileStatisticData)) return;
            if (!TestValidFileName()) return;
            CopyActionButton.Enabled = false;
            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                ProgressBar(true);
                fileStatisticData.Operation = OperationProcessor.Copy;
                var processor = new CopyProcessor(bsTextStatistic);
                await Task.Run(() => processor.Process(UpdateProgressBar,cancellationTokenSource.Token), cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                UpdateUI(fileStatisticData);
                MessageBox.Show(@"Operace kopírování vstupního souboru přerušena.", @"Přerušení", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            finally
            {
                CloseProcessUI();
                CopyActionButton.Enabled = true;
                ProgressBar(false);
            }
        }

        private bool TestValidFileName()
        {
            FileStatisticData fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            if (string.IsNullOrEmpty(fileStatisticData.InputFile))
            {
                MessageBox.Show(@"Zadejte vstupní soubor!", @"Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(fileStatisticData.InputFile))
            {
                MessageBox.Show(@"Vstupní soubor neexistuje!", @"Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(fileStatisticData.OutputFile))
            {
                MessageBox.Show(@"Zadejte výstupní soubor!", @"Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (File.Exists(fileStatisticData.OutputFile))
            {
                var fileInfo = new FileInfo(fileStatisticData.InputFile);
                var fileSize = fileInfo.Length;

                if (fileSize <= 0) return true;

                var result = MessageBox.Show(@"Výstupní soubor existuje! Přepsat výstupními obsahem?",
                    @"Otázka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.Delete(fileStatisticData.OutputFile);
                }
            }
            else
            {
                File.Create(fileStatisticData.OutputFile).Close();
            }

            return true;
        }


        private void UpdateProgressBar(FileStatisticData Data)
        {
            // Use Invoke to update UI elements from a non-UI thread
            if (ProcessProgress.InvokeRequired)
            {
                ProcessProgress.Invoke((Action<FileStatisticData>)UpdateProgressBar, Data);
            }
            else
            {
                ProcessProgress.Position = Data.Position;
            }
        }

        public void UpdateUI(FileStatisticData Data)
        {
            Invoke((Delegate)(() =>
            {
                labTypeStatistic.Text = (Data.Operation == OperationProcessor.Input)
                    ? "Zpracovávám vstupní soubor"
                    : "Zpracovávám výstupní soubor";
                labNumberOfCharacters.Text = Data.CharactersCountStr;
                labNumberOfSentences.Text = Data.NumberOfSentencesStr;
                labWordCount.Text = Data.WordCountStr;
                labNumberOfRows.Text = Data.LinesCountStr;
                ProcessProgress.Position = Data.Position;
                ProcessProgress.Refresh();
            }));
        }

        public void CloseProcessUI()
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            if (fileStatisticData.Abort)
            {
                labTypeStatistic.Text = @"Zpracování neproběhlo";
            }
            else
            {
                labTypeStatistic.Text = (fileStatisticData.Operation == OperationProcessor.Input)
                    ? "Vstupní soubor"
                    : "Výstupní soubor";
            }

            fileStatisticData.Operation = OperationProcessor.None;
            labNumberOfCharacters.Text = fileStatisticData.CharactersCountStr;
            labNumberOfSentences.Text = fileStatisticData.NumberOfSentencesStr;
            labWordCount.Text = fileStatisticData.WordCountStr;
            labNumberOfRows.Text = fileStatisticData.LinesCountStr;
        }

        public void ProgressBar(bool Active)
        {
            AbortButton.Visible = Active;
            ProcessProgress.Visible = Active;
            ProcessProgress.Position = 0;
        }

        private async void FormTextProcessor_FormClosing(object sender, FormClosingEventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            if (fileStatisticData.Operation == OperationProcessor.None)
            {
                return;
            }

            if (!await TextProcessorRunnig(fileStatisticData)) return;

            e.Cancel = true;
        }

        private async void RemoveDiacriticsButton_Click(object sender, EventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            if (await TextProcessorRunnig(fileStatisticData)) return;
            if (!TestValidFileName()) return;
            CopyActionButton.Enabled = false;
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                ProgressBar(true);
                fileStatisticData.Operation = OperationProcessor.RemoveDiacritics;
                var processor = new RemoveDiacriticsProcessor(bsTextStatistic);
                await Task.Run(() => processor.Process(UpdateProgressBar, cancellationTokenSource.Token), cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                UpdateUI(fileStatisticData);
                MessageBox.Show(@"Operace odstranění diakritiky přerušena.", @"Přerušení", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            finally
            {
                CloseProcessUI();
                CopyActionButton.Enabled = true;
                ProgressBar(false);
            }
        }

        private async void RemoveEmptyLineButton_Click(object sender, EventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            if (await TextProcessorRunnig(fileStatisticData)) return;
            if (!TestValidFileName()) return;
            CopyActionButton.Enabled = false;
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                ProgressBar(true);
                fileStatisticData.Operation = OperationProcessor.RemoveEmptyLine;
                var processor = new RemoveEmptyLineProcessor(bsTextStatistic);
                await Task.Run(() => processor.Process(UpdateProgressBar, cancellationTokenSource.Token), cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                UpdateUI(fileStatisticData);
                MessageBox.Show(@"Operace odstranění prázdných řádků přerušena.", @"Přerušení", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            finally
            {
                CloseProcessUI();
                CopyActionButton.Enabled = true;
                ProgressBar(false);
            }
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;

            var result = MessageBox.Show(@"Opravdu chcete přerušit proces?", @"Potvrzení", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                fileStatisticData.Abort = true;
                cancellationTokenSource.Cancel();
            }
        }

        private async void SpecialFormatButton_Click(object sender, EventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            if (await TextProcessorRunnig(fileStatisticData)) return;
            if (!TestValidFileName()) return;
            CopyActionButton.Enabled = false;
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                ProgressBar(true);
                fileStatisticData.Operation = OperationProcessor.SpecialFormat;
                var processor = new SpecialFormatProcessor(bsTextStatistic);
                await Task.Run(() => processor.Process(UpdateProgressBar, cancellationTokenSource.Token), cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                UpdateUI(fileStatisticData);
                MessageBox.Show(@"Operace specialního formátování přerušena.", @"Přerušení", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            finally
            {
                CloseProcessUI();
                CopyActionButton.Enabled = true;
                ProgressBar(false);
            }

        }
    }
}