namespace vtmRevisedCharacterList
{
    partial class AddARatingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NameTextBox = new TextBox();
            RatingNumeric = new NumericUpDown();
            RatingButton5 = new RadioButton();
            RatingButton4 = new RadioButton();
            RatingButton3 = new RadioButton();
            RatingButton2 = new RadioButton();
            RatingButton1 = new RadioButton();
            AddButton = new Button();
            DefaultOptionsPanel = new Panel();
            MeritSettingPanel = new Panel();
            CanBeActivatedCheckBox = new CheckBox();
            RemoveOneCheckBox = new CheckBox();
            ExtraHealthCheckBox = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            MeritDicepoolNumeric = new NumericUpDown();
            MeritDiffiultyNumeric = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)RatingNumeric).BeginInit();
            MeritSettingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MeritDicepoolNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MeritDiffiultyNumeric).BeginInit();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(14, 11);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(272, 23);
            NameTextBox.TabIndex = 0;
            // 
            // RatingNumeric
            // 
            RatingNumeric.Location = new Point(386, 11);
            RatingNumeric.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            RatingNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RatingNumeric.Name = "RatingNumeric";
            RatingNumeric.Size = new Size(41, 23);
            RatingNumeric.TabIndex = 14;
            RatingNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            RatingNumeric.ValueChanged += RatingNumeric_ValueChanged;
            // 
            // RatingButton5
            // 
            RatingButton5.AutoCheck = false;
            RatingButton5.AutoSize = true;
            RatingButton5.Location = new Point(369, 19);
            RatingButton5.Name = "RatingButton5";
            RatingButton5.Size = new Size(14, 13);
            RatingButton5.TabIndex = 13;
            RatingButton5.TabStop = true;
            RatingButton5.UseVisualStyleBackColor = true;
            // 
            // RatingButton4
            // 
            RatingButton4.AutoCheck = false;
            RatingButton4.AutoSize = true;
            RatingButton4.Location = new Point(349, 19);
            RatingButton4.Name = "RatingButton4";
            RatingButton4.Size = new Size(14, 13);
            RatingButton4.TabIndex = 12;
            RatingButton4.UseVisualStyleBackColor = true;
            // 
            // RatingButton3
            // 
            RatingButton3.AutoCheck = false;
            RatingButton3.AutoSize = true;
            RatingButton3.Location = new Point(329, 19);
            RatingButton3.Name = "RatingButton3";
            RatingButton3.Size = new Size(14, 13);
            RatingButton3.TabIndex = 11;
            RatingButton3.UseVisualStyleBackColor = true;
            // 
            // RatingButton2
            // 
            RatingButton2.AutoCheck = false;
            RatingButton2.AutoSize = true;
            RatingButton2.Location = new Point(309, 19);
            RatingButton2.Name = "RatingButton2";
            RatingButton2.Size = new Size(14, 13);
            RatingButton2.TabIndex = 10;
            RatingButton2.UseVisualStyleBackColor = true;
            // 
            // RatingButton1
            // 
            RatingButton1.AutoCheck = false;
            RatingButton1.AutoSize = true;
            RatingButton1.Checked = true;
            RatingButton1.Location = new Point(289, 19);
            RatingButton1.Name = "RatingButton1";
            RatingButton1.Size = new Size(14, 13);
            RatingButton1.TabIndex = 9;
            RatingButton1.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(433, 11);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(90, 23);
            AddButton.TabIndex = 20;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // DefaultOptionsPanel
            // 
            DefaultOptionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DefaultOptionsPanel.AutoScroll = true;
            DefaultOptionsPanel.Location = new Point(14, 40);
            DefaultOptionsPanel.Name = "DefaultOptionsPanel";
            DefaultOptionsPanel.Size = new Size(366, 398);
            DefaultOptionsPanel.TabIndex = 21;
            // 
            // MeritSettingPanel
            // 
            MeritSettingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MeritSettingPanel.AutoScroll = true;
            MeritSettingPanel.Controls.Add(CanBeActivatedCheckBox);
            MeritSettingPanel.Controls.Add(RemoveOneCheckBox);
            MeritSettingPanel.Controls.Add(ExtraHealthCheckBox);
            MeritSettingPanel.Controls.Add(label2);
            MeritSettingPanel.Controls.Add(label1);
            MeritSettingPanel.Controls.Add(MeritDicepoolNumeric);
            MeritSettingPanel.Controls.Add(MeritDiffiultyNumeric);
            MeritSettingPanel.Location = new Point(386, 40);
            MeritSettingPanel.Name = "MeritSettingPanel";
            MeritSettingPanel.Size = new Size(137, 398);
            MeritSettingPanel.TabIndex = 22;
            // 
            // CanBeActivatedCheckBox
            // 
            CanBeActivatedCheckBox.AutoSize = true;
            CanBeActivatedCheckBox.Location = new Point(5, 182);
            CanBeActivatedCheckBox.Name = "CanBeActivatedCheckBox";
            CanBeActivatedCheckBox.Size = new Size(109, 19);
            CanBeActivatedCheckBox.TabIndex = 29;
            CanBeActivatedCheckBox.Text = "Активируемый";
            CanBeActivatedCheckBox.UseVisualStyleBackColor = true;
            // 
            // RemoveOneCheckBox
            // 
            RemoveOneCheckBox.AutoSize = true;
            RemoveOneCheckBox.Location = new Point(5, 135);
            RemoveOneCheckBox.Name = "RemoveOneCheckBox";
            RemoveOneCheckBox.Size = new Size(127, 34);
            RemoveOneCheckBox.TabIndex = 28;
            RemoveOneCheckBox.Text = "Убирает единички\r\nс броска";
            RemoveOneCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExtraHealthCheckBox
            // 
            ExtraHealthCheckBox.AutoSize = true;
            ExtraHealthCheckBox.Location = new Point(5, 95);
            ExtraHealthCheckBox.Name = "ExtraHealthCheckBox";
            ExtraHealthCheckBox.Size = new Size(124, 34);
            ExtraHealthCheckBox.TabIndex = 27;
            ExtraHealthCheckBox.Text = "Даёт доп \r\nуровень здоровья";
            ExtraHealthCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 47);
            label2.Name = "label2";
            label2.Size = new Size(85, 30);
            label2.TabIndex = 26;
            label2.Text = "Модификатор\r\nкол-ва кубов\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(85, 30);
            label1.TabIndex = 25;
            label1.Text = "Модификатор\r\nсложности";
            // 
            // MeritDicepoolNumeric
            // 
            MeritDicepoolNumeric.Location = new Point(94, 54);
            MeritDicepoolNumeric.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            MeritDicepoolNumeric.Name = "MeritDicepoolNumeric";
            MeritDicepoolNumeric.Size = new Size(41, 23);
            MeritDicepoolNumeric.TabIndex = 24;
            MeritDicepoolNumeric.ValueChanged += MeritDicepoolNumeric_ValueChanged;
            // 
            // MeritDiffiultyNumeric
            // 
            MeritDiffiultyNumeric.Location = new Point(94, 12);
            MeritDiffiultyNumeric.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            MeritDiffiultyNumeric.Name = "MeritDiffiultyNumeric";
            MeritDiffiultyNumeric.Size = new Size(41, 23);
            MeritDiffiultyNumeric.TabIndex = 23;
            // 
            // AddARatingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 450);
            Controls.Add(MeritSettingPanel);
            Controls.Add(DefaultOptionsPanel);
            Controls.Add(AddButton);
            Controls.Add(RatingNumeric);
            Controls.Add(RatingButton5);
            Controls.Add(RatingButton4);
            Controls.Add(RatingButton3);
            Controls.Add(RatingButton2);
            Controls.Add(RatingButton1);
            Controls.Add(NameTextBox);
            Name = "AddARatingForm";
            Text = "AddARatingForm";
            ((System.ComponentModel.ISupportInitialize)RatingNumeric).EndInit();
            MeritSettingPanel.ResumeLayout(false);
            MeritSettingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MeritDicepoolNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)MeritDiffiultyNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox NameTextBox;
        private NumericUpDown RatingNumeric;
        private RadioButton RatingButton5;
        private RadioButton RatingButton4;
        private RadioButton RatingButton3;
        private RadioButton RatingButton2;
        private RadioButton RatingButton1;
        private Button AddButton;
        private Panel DefaultOptionsPanel;
        private Panel MeritSettingPanel;
        public NumericUpDown MeritDiffiultyNumeric;
        public NumericUpDown MeritDicepoolNumeric;
        private Label label2;
        private Label label1;
        public CheckBox RemoveOneCheckBox;
        public CheckBox ExtraHealthCheckBox;
        public CheckBox CanBeActivatedCheckBox;
    }
}