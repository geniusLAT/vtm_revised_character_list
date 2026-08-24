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
            label1 = new Label();
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
            DefaultOptionsPanel.Location = new Point(14, 40);
            DefaultOptionsPanel.Name = "DefaultOptionsPanel";
            DefaultOptionsPanel.Size = new Size(369, 398);
            DefaultOptionsPanel.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(403, 99);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 22;
            label1.Text = "label1";
            label1.Click += DefaultOption_Click;
            // 
            // AddARatingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 450);
            Controls.Add(label1);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private NumericUpDown RatingNumeric;
        private RadioButton RatingButton5;
        private RadioButton RatingButton4;
        private RadioButton RatingButton3;
        private RadioButton RatingButton2;
        private RadioButton RatingButton1;
        private Button AddButton;
        private Panel DefaultOptionsPanel;
        private Label label1;
    }
}