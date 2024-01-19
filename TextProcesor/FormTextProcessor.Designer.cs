namespace TextProcessor
{
    partial class FormTextProcessor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTextProcessor));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            lcTextProcesor = new DevExpress.XtraLayout.LayoutControl();
            CopyActionButton = new DevExpress.XtraEditors.SimpleButton();
            RemoveDiacriticsButton = new DevExpress.XtraEditors.SimpleButton();
            RemoveEmptyLineButton = new DevExpress.XtraEditors.SimpleButton();
            SpecialFormatButton = new DevExpress.XtraEditors.SimpleButton();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            beOutputFile = new DevExpress.XtraEditors.ButtonEdit();
            bsTextStatistic = new BindingSource(components);
            beInputFile = new DevExpress.XtraEditors.ButtonEdit();
            ProcessProgress = new DevExpress.XtraEditors.ProgressBarControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            panelProgress = new DevExpress.XtraEditors.PanelControl();
            AbortButton = new Button();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            panelControl2 = new DevExpress.XtraEditors.PanelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            panelControl3 = new DevExpress.XtraEditors.PanelControl();
            labNumberOfRows = new DevExpress.XtraEditors.LabelControl();
            labNumberOfCharacters = new DevExpress.XtraEditors.LabelControl();
            labWordCount = new DevExpress.XtraEditors.LabelControl();
            labNumberOfSentences = new DevExpress.XtraEditors.LabelControl();
            labTypeStatistic = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)lcTextProcesor).BeginInit();
            lcTextProcesor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beOutputFile.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsTextStatistic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)beInputFile.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProcessProgress.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelProgress).BeginInit();
            panelProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelControl2).BeginInit();
            panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelControl3).BeginInit();
            panelControl3.SuspendLayout();
            SuspendLayout();
            // 
            // lcTextProcesor
            // 
            lcTextProcesor.Controls.Add(CopyActionButton);
            lcTextProcesor.Controls.Add(RemoveDiacriticsButton);
            lcTextProcesor.Controls.Add(RemoveEmptyLineButton);
            lcTextProcesor.Controls.Add(SpecialFormatButton);
            lcTextProcesor.Location = new Point(0, 192);
            lcTextProcesor.Name = "lcTextProcesor";
            lcTextProcesor.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1051, 1325, 1300, 800);
            lcTextProcesor.Root = layoutControlGroup1;
            lcTextProcesor.Size = new Size(1910, 100);
            lcTextProcesor.TabIndex = 0;
            lcTextProcesor.Text = "layoutControl2";
            // 
            // CopyActionButton
            // 
            CopyActionButton.Appearance.Font = new Font("Tahoma", 10.875F);
            CopyActionButton.Appearance.Options.UseFont = true;
            CopyActionButton.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("CopyActionButton.ImageOptions.SvgImage");
            CopyActionButton.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            CopyActionButton.ImageOptions.SvgImageSize = new Size(32, 32);
            CopyActionButton.Location = new Point(12, 12);
            CopyActionButton.Name = "CopyActionButton";
            CopyActionButton.Size = new Size(446, 72);
            CopyActionButton.StyleController = lcTextProcesor;
            CopyActionButton.TabIndex = 0;
            CopyActionButton.Text = "Překopíruj";
            CopyActionButton.Click += CopyActionButton_Click;
            // 
            // RemoveDiacriticsButton
            // 
            RemoveDiacriticsButton.Appearance.Font = new Font("Tahoma", 10.875F);
            RemoveDiacriticsButton.Appearance.Options.UseFont = true;
            RemoveDiacriticsButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            RemoveDiacriticsButton.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("RemoveDiacriticsButton.ImageOptions.SvgImage");
            RemoveDiacriticsButton.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            RemoveDiacriticsButton.ImageOptions.SvgImageSize = new Size(32, 32);
            RemoveDiacriticsButton.Location = new Point(462, 12);
            RemoveDiacriticsButton.Name = "RemoveDiacriticsButton";
            RemoveDiacriticsButton.Size = new Size(533, 72);
            RemoveDiacriticsButton.StyleController = lcTextProcesor;
            RemoveDiacriticsButton.TabIndex = 2;
            RemoveDiacriticsButton.Text = "Odstraň diakritiku";
            RemoveDiacriticsButton.Click += RemoveDiacriticsButton_Click;
            // 
            // RemoveEmptyLineButton
            // 
            RemoveEmptyLineButton.Appearance.Font = new Font("Tahoma", 10.875F);
            RemoveEmptyLineButton.Appearance.Options.UseFont = true;
            RemoveEmptyLineButton.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("RemoveEmptyLineButton.ImageOptions.SvgImage");
            RemoveEmptyLineButton.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            RemoveEmptyLineButton.ImageOptions.SvgImageSize = new Size(32, 32);
            RemoveEmptyLineButton.Location = new Point(999, 12);
            RemoveEmptyLineButton.Name = "RemoveEmptyLineButton";
            RemoveEmptyLineButton.Size = new Size(492, 72);
            RemoveEmptyLineButton.StyleController = lcTextProcesor;
            RemoveEmptyLineButton.TabIndex = 3;
            RemoveEmptyLineButton.Text = "Odstraň prázdné řádky";
            RemoveEmptyLineButton.Click += RemoveEmptyLineButton_Click;
            // 
            // SpecialFormatButton
            // 
            SpecialFormatButton.Appearance.Font = new Font("Tahoma", 10.875F);
            SpecialFormatButton.Appearance.Options.UseFont = true;
            SpecialFormatButton.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("SpecialFormatButton.ImageOptions.SvgImage");
            SpecialFormatButton.ImageOptions.SvgImageSize = new Size(32, 32);
            SpecialFormatButton.Location = new Point(1495, 12);
            SpecialFormatButton.Name = "SpecialFormatButton";
            SpecialFormatButton.Size = new Size(403, 72);
            SpecialFormatButton.StyleController = lcTextProcesor;
            toolTipTitleItem1.Text = "Specíální formát";
            toolTipItem1.Text = "Odstraň mezery a interpunkční znaménka, slova odděluj velkými písmeny (CamelCase)";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            SpecialFormatButton.SuperTip = superToolTip1;
            SpecialFormatButton.TabIndex = 4;
            SpecialFormatButton.Text = "Specialní formát";
            SpecialFormatButton.Click += SpecialFormatButton_Click;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem5, layoutControlItem4, layoutControlItem6, layoutControlItem7, simpleSeparator1 });
            layoutControlGroup1.Name = "Root";
            layoutControlGroup1.Size = new Size(1910, 100);
            layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = RemoveDiacriticsButton;
            layoutControlItem5.Location = new Point(450, 0);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(537, 76);
            layoutControlItem5.TextSize = new Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = CopyActionButton;
            layoutControlItem4.Location = new Point(0, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(450, 76);
            layoutControlItem4.TextSize = new Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = RemoveEmptyLineButton;
            layoutControlItem6.Location = new Point(987, 0);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(496, 76);
            layoutControlItem6.TextSize = new Size(0, 0);
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = SpecialFormatButton;
            layoutControlItem7.Location = new Point(1483, 0);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new Size(407, 76);
            layoutControlItem7.TextSize = new Size(0, 0);
            layoutControlItem7.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.AllowHotTrack = false;
            simpleSeparator1.Location = new Point(0, 76);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new Size(1890, 4);
            // 
            // beOutputFile
            // 
            beOutputFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            beOutputFile.DataBindings.Add(new Binding("EditValue", bsTextStatistic, "OutputFile", true));
            beOutputFile.Location = new Point(346, 24);
            beOutputFile.Name = "beOutputFile";
            beOutputFile.Properties.Appearance.Font = new Font("Tahoma", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            beOutputFile.Properties.Appearance.Options.UseFont = true;
            beOutputFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            beOutputFile.Size = new Size(1544, 50);
            beOutputFile.TabIndex = 2;
            beOutputFile.ButtonClick += beOutputFile_ButtonClick;
            // 
            // bsTextStatistic
            // 
            bsTextStatistic.AllowNew = false;
            // 
            // beInputFile
            // 
            beInputFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            beInputFile.DataBindings.Add(new Binding("EditValue", bsTextStatistic, "InputFile", true));
            beInputFile.Location = new Point(343, 26);
            beInputFile.Name = "beInputFile";
            beInputFile.Properties.Appearance.Font = new Font("Tahoma", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            beInputFile.Properties.Appearance.Options.UseFont = true;
            beInputFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            beInputFile.Size = new Size(1547, 50);
            beInputFile.TabIndex = 0;
            beInputFile.ButtonClick += beInputFile_ButtonClick;
            // 
            // ProcessProgress
            // 
            ProcessProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ProcessProgress.Location = new Point(6, 6);
            ProcessProgress.MaximumSize = new Size(0, 120);
            ProcessProgress.MinimumSize = new Size(0, 120);
            ProcessProgress.Name = "ProcessProgress";
            ProcessProgress.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            ProcessProgress.Properties.ShowTitle = true;
            ProcessProgress.ShowProgressInTaskBar = true;
            ProcessProgress.Size = new Size(1745, 120);
            ProcessProgress.TabIndex = 1;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            Root.Location = new Point(0, 0);
            Root.Name = "Root";
            Root.Size = new Size(1823, 779);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = lcTextProcesor;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(1823, 779);
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // panelProgress
            // 
            panelProgress.Controls.Add(AbortButton);
            panelProgress.Controls.Add(ProcessProgress);
            panelProgress.Dock = DockStyle.Bottom;
            panelProgress.Location = new Point(0, 642);
            panelProgress.Name = "panelProgress";
            panelProgress.Size = new Size(1910, 128);
            panelProgress.TabIndex = 1;
            // 
            // AbortButton
            // 
            AbortButton.Dock = DockStyle.Right;
            AbortButton.Image = Properties.Resources.close;
            AbortButton.Location = new Point(1757, 3);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(150, 122);
            AbortButton.TabIndex = 2;
            AbortButton.UseVisualStyleBackColor = true;
            AbortButton.Click += AbortButton_Click;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Tahoma", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.ImageOptions.Alignment = ContentAlignment.MiddleLeft;
            labelControl1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("labelControl1.ImageOptions.SvgImage");
            labelControl1.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            labelControl1.Location = new Point(18, 26);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(294, 48);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "        Vstupní soubor";
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(beInputFile);
            panelControl1.Controls.Add(labelControl1);
            panelControl1.Dock = DockStyle.Top;
            panelControl1.Location = new Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new Size(1910, 96);
            panelControl1.TabIndex = 3;
            // 
            // panelControl2
            // 
            panelControl2.Controls.Add(labelControl2);
            panelControl2.Controls.Add(beOutputFile);
            panelControl2.Dock = DockStyle.Top;
            panelControl2.Location = new Point(0, 96);
            panelControl2.Name = "panelControl2";
            panelControl2.Size = new Size(1910, 96);
            panelControl2.TabIndex = 4;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new Font("Tahoma", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.ImageOptions.Alignment = ContentAlignment.MiddleLeft;
            labelControl2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("labelControl2.ImageOptions.SvgImage");
            labelControl2.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            labelControl2.Location = new Point(18, 26);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(296, 48);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "        Výtupní soubor";
            // 
            // panelControl3
            // 
            panelControl3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelControl3.Controls.Add(labNumberOfRows);
            panelControl3.Controls.Add(labNumberOfCharacters);
            panelControl3.Controls.Add(labWordCount);
            panelControl3.Controls.Add(labNumberOfSentences);
            panelControl3.Controls.Add(labTypeStatistic);
            panelControl3.Location = new Point(12, 298);
            panelControl3.Name = "panelControl3";
            panelControl3.Size = new Size(1886, 330);
            panelControl3.TabIndex = 5;
            // 
            // labNumberOfRows
            // 
            labNumberOfRows.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labNumberOfRows.Dock = DockStyle.Top;
            labNumberOfRows.Location = new Point(3, 223);
            labNumberOfRows.Name = "labNumberOfRows";
            labNumberOfRows.Size = new Size(1880, 55);
            labNumberOfRows.TabIndex = 4;
            labNumberOfRows.Text = "Počet řádků : ";
            // 
            // labNumberOfCharacters
            // 
            labNumberOfCharacters.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labNumberOfCharacters.Dock = DockStyle.Top;
            labNumberOfCharacters.Location = new Point(3, 168);
            labNumberOfCharacters.Name = "labNumberOfCharacters";
            labNumberOfCharacters.Size = new Size(1880, 55);
            labNumberOfCharacters.TabIndex = 3;
            labNumberOfCharacters.Text = "Počet znaků : ";
            // 
            // labWordCount
            // 
            labWordCount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labWordCount.Dock = DockStyle.Top;
            labWordCount.Location = new Point(3, 113);
            labWordCount.Name = "labWordCount";
            labWordCount.Size = new Size(1880, 55);
            labWordCount.TabIndex = 2;
            labWordCount.Text = "Počet slov :";
            // 
            // labNumberOfSentences
            // 
            labNumberOfSentences.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labNumberOfSentences.Dock = DockStyle.Top;
            labNumberOfSentences.Location = new Point(3, 58);
            labNumberOfSentences.Name = "labNumberOfSentences";
            labNumberOfSentences.Size = new Size(1880, 55);
            labNumberOfSentences.TabIndex = 1;
            labNumberOfSentences.Text = "Počet vět : ";
            // 
            // labTypeStatistic
            // 
            labTypeStatistic.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labTypeStatistic.Dock = DockStyle.Top;
            labTypeStatistic.Location = new Point(3, 3);
            labTypeStatistic.Name = "labTypeStatistic";
            labTypeStatistic.Size = new Size(1880, 55);
            labTypeStatistic.TabIndex = 0;
            labTypeStatistic.Text = "Zpracování neproběhlo";
            // 
            // FormTextProcessor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1910, 770);
            Controls.Add(lcTextProcesor);
            Controls.Add(panelControl3);
            Controls.Add(panelProgress);
            Controls.Add(panelControl2);
            Controls.Add(panelControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTextProcessor";
            Text = "Text Procesor";
            FormClosing += FormTextProcessor_FormClosing;
            ((System.ComponentModel.ISupportInitialize)lcTextProcesor).EndInit();
            lcTextProcesor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)beOutputFile.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsTextStatistic).EndInit();
            ((System.ComponentModel.ISupportInitialize)beInputFile.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProcessProgress.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelProgress).EndInit();
            panelProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)panelControl2).EndInit();
            panelControl2.ResumeLayout(false);
            panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)panelControl3).EndInit();
            panelControl3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControl lcTextProcesor;
        private DevExpress.XtraEditors.ButtonEdit beInputFile;
        private DevExpress.XtraEditors.ButtonEdit beOutputFile;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ProgressBarControl ProcessProgress;
        private BindingSource bsTextStatistic;
        private DevExpress.XtraEditors.SimpleButton CopyActionButton;
        private DevExpress.XtraEditors.SimpleButton RemoveDiacriticsButton;
        private DevExpress.XtraEditors.SimpleButton RemoveEmptyLineButton;
        private DevExpress.XtraEditors.SimpleButton SpecialFormatButton;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.PanelControl panelProgress;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labTypeStatistic;
        private DevExpress.XtraEditors.LabelControl labNumberOfSentences;
        private DevExpress.XtraEditors.LabelControl labWordCount;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labNumberOfRows;
        private DevExpress.XtraEditors.LabelControl labNumberOfCharacters;
        private Button AbortButton;
    }
}
