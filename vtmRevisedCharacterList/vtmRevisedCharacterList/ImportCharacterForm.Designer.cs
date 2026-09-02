namespace vtmRevisedCharacterList
{
    partial class ImportCharacterForm
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
            ImportTextBox = new TextBox();
            panel1 = new Panel();
            AddNewUserButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ImportTextBox
            // 
            ImportTextBox.Location = new Point(13, 0);
            ImportTextBox.Multiline = true;
            ImportTextBox.Name = "ImportTextBox";
            ImportTextBox.ScrollBars = ScrollBars.Vertical;
            ImportTextBox.Size = new Size(776, 564);
            ImportTextBox.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(ImportTextBox);
            panel1.Location = new Point(-1, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 564);
            panel1.TabIndex = 1;
            // 
            // AddNewUserButton
            // 
            AddNewUserButton.Location = new Point(608, 12);
            AddNewUserButton.Name = "AddNewUserButton";
            AddNewUserButton.Size = new Size(180, 23);
            AddNewUserButton.TabIndex = 24;
            AddNewUserButton.Text = "Добавить нового персонажа";
            AddNewUserButton.UseVisualStyleBackColor = true;
            AddNewUserButton.Click += AddNewUserButton_Click;
            // 
            // ImportCharacterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 603);
            Controls.Add(AddNewUserButton);
            Controls.Add(panel1);
            Name = "ImportCharacterForm";
            Text = "ImportCharacterForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox ImportTextBox;
        private Panel panel1;
        private Button AddNewUserButton;
    }
}