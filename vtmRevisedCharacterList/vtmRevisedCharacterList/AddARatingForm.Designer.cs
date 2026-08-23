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
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            AddButton = new Button();
            DefaultOptionsPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)RatingNumeric).BeginInit();
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
            RatingNumeric.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            RatingNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RatingNumeric.Name = "RatingNumeric";
            RatingNumeric.Size = new Size(41, 23);
            RatingNumeric.TabIndex = 14;
            RatingNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            RatingNumeric.ValueChanged += RatingNumeric_ValueChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoCheck = false;
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(369, 19);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(14, 13);
            radioButton1.TabIndex = 13;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoCheck = false;
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(349, 19);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(14, 13);
            radioButton2.TabIndex = 12;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoCheck = false;
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Location = new Point(329, 19);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(14, 13);
            radioButton3.TabIndex = 11;
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoCheck = false;
            radioButton4.AutoSize = true;
            radioButton4.Checked = true;
            radioButton4.Location = new Point(309, 19);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(14, 13);
            radioButton4.TabIndex = 10;
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoCheck = false;
            radioButton5.AutoSize = true;
            radioButton5.Checked = true;
            radioButton5.Location = new Point(289, 19);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(14, 13);
            radioButton5.TabIndex = 9;
            radioButton5.UseVisualStyleBackColor = true;
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
            DefaultOptionsPanel.Location = new Point(14, 40);
            DefaultOptionsPanel.Name = "DefaultOptionsPanel";
            DefaultOptionsPanel.Size = new Size(501, 398);
            DefaultOptionsPanel.TabIndex = 21;
            // 
            // AddARatingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 450);
            Controls.Add(DefaultOptionsPanel);
            Controls.Add(AddButton);
            Controls.Add(RatingNumeric);
            Controls.Add(radioButton1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton3);
            Controls.Add(radioButton4);
            Controls.Add(radioButton5);
            Controls.Add(NameTextBox);
            Name = "AddARatingForm";
            Text = "AddARatingForm";
            ((System.ComponentModel.ISupportInitialize)RatingNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private NumericUpDown RatingNumeric;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private Button AddButton;
        private Panel DefaultOptionsPanel;
    }
}