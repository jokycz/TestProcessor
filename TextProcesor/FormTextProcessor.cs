using System.IO;
using TextProcessor.Data;
using TextProcessor.Processor;

namespace TextProcessor
{
    public partial class FormTextProcessor : Form
    {
        private Task BackgroundTask;

        public FormTextProcessor()
        {
            InitializeComponent();
            bsTextStatistic.DataSource = new FileStatisticData();
            StateButton(true);
        }

        private void beInputFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            openFileDialog.Filter = @"Text Files (*.txt)|*.txt";
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            fileStatisticData.InputFile = openFileDialog.FileName;
            bsTextStatistic.ResetBindings(false);
        }

        private void beOutputFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            saveFileDialog.Filter = @"Text Files (*.txt)|*.txt";
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            fileStatisticData.OutputFile = saveFileDialog.FileName;
            bsTextStatistic.ResetBindings(false);
        }

        private void CopyActionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TestValidFileName()) return;

                var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
                fileStatisticData.Operation = OperationProcessor.RemoveDiacritics;
                StateButton(false);

                var processor = new CopyProcessor(bsTextStatistic);
                BackgroundTask = Task.Run(() => processor.Process(UpdateUI));

                BackgroundTask.ContinueWith(completedTask => { CloseProcessUI(); });
            }
            finally
            {
                if (BackgroundTask?.Status == TaskStatus.RanToCompletion)
                {
                    StateButton(true);
                }
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
            Invoke((Delegate)(() =>
            {
                FileStatisticData fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
                if (fileStatisticData.Abort)
                {
                    labTypeStatistic.Text = @"Zpracování neproběhlo";

                    labNumberOfCharacters.Text = fileStatisticData.CharactersCountStr;
                    labNumberOfSentences.Text = fileStatisticData.NumberOfSentencesStr;
                    labWordCount.Text = fileStatisticData.WordCountStr;
                    labNumberOfRows.Text = fileStatisticData.LinesCountStr;
                }

                labTypeStatistic.Text = (fileStatisticData.Operation == OperationProcessor.Input)
                    ? "Vstupní soubor"
                    : "Výstupní soubor";
                fileStatisticData.Operation = OperationProcessor.None;
                labNumberOfCharacters.Text = fileStatisticData.CharactersCountStr;
                labNumberOfSentences.Text = fileStatisticData.NumberOfSentencesStr;
                labWordCount.Text = fileStatisticData.WordCountStr;
                labNumberOfRows.Text = fileStatisticData.LinesCountStr;
                ProcessProgress.Position = fileStatisticData.Position;
                ProcessProgress.Refresh();
                StateButton(true);
            }));
        }

        public void StateButton(bool Active)
        {
            CopyActionButton.Enabled = Active;
            RemoveDiacriticsButton.Enabled = Active;
            RemoveEmptyLineButton.Enabled = Active;
            SpecialFormatButton.Enabled = Active;
            AbortButton.Visible = !Active;
            ProcessProgress.Visible = !Active;
            ProcessProgress.Position = 0;
        }

        private void FormTextProcessor_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void FormTextProcessor_FormClosing(object sender, FormClosingEventArgs e)
        {
            var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
            if (fileStatisticData.Operation == OperationProcessor.None)
            {
                return;
            }

            if (fileStatisticData.Operation == OperationProcessor.Input)
            {
                fileStatisticData.Abort = true;

                while (BackgroundTask.Status == TaskStatus.Running)
                {
                }

                return;
            }

            //messge box otázka probíha operace opravdu přeušit operaci a zavřít aplikaci

            string operationStr;
            switch (fileStatisticData.Operation)
            {
                case OperationProcessor.Copy:
                    operationStr = "Kopírování";
                    break;
                case OperationProcessor.RemoveDiacritics:
                    operationStr = "Odstranění diakritiky";
                    break;
                case OperationProcessor.RemoveEmptyLine:
                    operationStr = "Odstranění prázdných řádků";
                    break;
                case OperationProcessor.SpecialFormat:
                    operationStr = "Speciální formát";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var result = MessageBox.Show($@"Probíhá operace {operationStr}. Chcete ji přerušit a závřít aplikaci ?",
                @"Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                fileStatisticData.Abort = true;

                while (BackgroundTask.Status == TaskStatus.Running)
                {
                }

                return;
            }

            e.Cancel = true;
        }

        private void RemoveDiacriticsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TestValidFileName()) return;

                var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
                fileStatisticData.Operation = OperationProcessor.RemoveDiacritics;
                StateButton(false);

                var processor = new RemoveDiacriticsProcessor(bsTextStatistic);
                BackgroundTask = Task.Run(() => processor.Process(UpdateUI));

                BackgroundTask.ContinueWith(completedTask => { CloseProcessUI(); });
            }
            finally
            {
                if (BackgroundTask?.Status == TaskStatus.RanToCompletion)
                {
                    StateButton(true);
                }
            }
        }

        private void RemoveEmptyLineButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TestValidFileName()) return;

                var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
                fileStatisticData.Operation = OperationProcessor.RemoveEmptyLine;
                StateButton(false);

                var processor = new RemoveEmptyLineProcessor(bsTextStatistic);
                BackgroundTask = Task.Run(() => processor.Process(UpdateUI));

                BackgroundTask.ContinueWith(completedTask => { CloseProcessUI(); });
            }
            finally
            {
                if (BackgroundTask?.Status == TaskStatus.RanToCompletion)
                {
                    StateButton(true);
                }
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
            }
        }

        private void SpecialFormatButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TestValidFileName()) return;

                var fileStatisticData = (FileStatisticData)bsTextStatistic.DataSource;
                fileStatisticData.Operation = OperationProcessor.RemoveEmptyLine;
                StateButton(false);

                var processor = new SpecialFormatProcessor(bsTextStatistic);
                BackgroundTask = Task.Run(() => processor.Process(UpdateUI));

                BackgroundTask.ContinueWith(completedTask => { CloseProcessUI(); });
            }
            finally
            {
                if (BackgroundTask?.Status == TaskStatus.RanToCompletion)
                {
                    StateButton(true);
                }
            }
        }
    }
}