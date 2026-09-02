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
            UserListPanel = new Panel();
            UserNameTextBox = new TextBox();
            UserNameLabel = new Label();
            AddNewUserButton = new Button();
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
            // UserListPanel
            // 
            UserListPanel.Location = new Point(320, 197);
            UserListPanel.Name = "UserListPanel";
            UserListPanel.Size = new Size(273, 241);
            UserListPanel.TabIndex = 2;
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(393, 444);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(200, 23);
            UserNameTextBox.TabIndex = 17;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(320, 447);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(75, 15);
            UserNameLabel.TabIndex = 18;
            UserNameLabel.Text = "Имя игрока:";
            // 
            // AddNewUserButton
            // 
            AddNewUserButton.Location = new Point(322, 472);
            AddNewUserButton.Name = "AddNewUserButton";
            AddNewUserButton.Size = new Size(151, 23);
            AddNewUserButton.TabIndex = 19;
            AddNewUserButton.Text = "Добавить нового игрока";
            AddNewUserButton.UseVisualStyleBackColor = true;
            AddNewUserButton.Click += AddNewUserButton_Click;
            // 
            // CharacterManagment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 647);
            Controls.Add(AddNewUserButton);
            Controls.Add(UserNameLabel);
            Controls.Add(UserNameTextBox);
            Controls.Add(UserListPanel);
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
        private Panel UserListPanel;
        private TextBox UserNameTextBox;
        private Label UserNameLabel;
        private Button AddNewUserButton;
    }
}