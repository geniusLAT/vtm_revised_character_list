namespace vtmRevisedCharacterList
{
    partial class CharacterManagment
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
            InitRollButton = new Button();
            CharacterListPanel = new Panel();
            LogPanel = new Panel();
            logLabel = new Label();
            LogPanel.SuspendLayout();
            SuspendLayout();
            // 
            // InitRollButton
            // 
            InitRollButton.Location = new Point(506, -1);
            InitRollButton.Name = "InitRollButton";
            InitRollButton.Size = new Size(87, 23);
            InitRollButton.TabIndex = 0;
            InitRollButton.Text = "Инициатива";
            InitRollButton.UseVisualStyleBackColor = true;
            InitRollButton.Click += InitRollButton_Click;
            // 
            // CharacterListPanel
            // 
            CharacterListPanel.Location = new Point(6, 9);
            CharacterListPanel.Name = "CharacterListPanel";
            CharacterListPanel.Size = new Size(308, 429);
            CharacterListPanel.TabIndex = 1;
            // 
            // LogPanel
            // 
            LogPanel.AutoScroll = true;
            LogPanel.AutoSize = true;
            LogPanel.BackColor = SystemColors.ActiveCaption;
            LogPanel.Controls.Add(logLabel);
            LogPanel.ForeColor = SystemColors.Window;
            LogPanel.Location = new Point(599, -1);
            LogPanel.MaximumSize = new Size(2000, 2000);
            LogPanel.Name = "LogPanel";
            LogPanel.Size = new Size(230, 636);
            LogPanel.TabIndex = 16;
            // 
            // logLabel
            // 
            logLabel.AutoSize = true;
            logLabel.Location = new Point(0, 0);
            logLabel.Name = "logLabel";
            logLabel.Size = new Size(0, 15);
            logLabel.TabIndex = 0;
            logLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // CharacterManagment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 647);
            Controls.Add(LogPanel);
            Controls.Add(CharacterListPanel);
            Controls.Add(InitRollButton);
            Name = "CharacterManagment";
            Text = "CharacterManagment";
            FormClosed += CharacterManagment_FormClosed;
            LogPanel.ResumeLayout(false);
            LogPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button InitRollButton;
        private Panel CharacterListPanel;
        private Panel LogPanel;
        private Label logLabel;
    }
}