namespace vtmRevisedCharacterList
{
    partial class AddNewCharacterForm
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
            CharacterNameLabel = new Label();
            AddNewUserButton = new Button();
            NewCharacterNameTextBox = new TextBox();
            label1 = new Label();
            PlayerNameTextBox = new TextBox();
            ChronicleNameLabel = new Label();
            ChronicleNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // CharacterNameLabel
            // 
            CharacterNameLabel.AutoSize = true;
            CharacterNameLabel.Location = new Point(7, 15);
            CharacterNameLabel.Name = "CharacterNameLabel";
            CharacterNameLabel.Size = new Size(98, 15);
            CharacterNameLabel.TabIndex = 24;
            CharacterNameLabel.Text = "Имя персонажа:";
            // 
            // AddNewUserButton
            // 
            AddNewUserButton.Location = new Point(317, 11);
            AddNewUserButton.Name = "AddNewUserButton";
            AddNewUserButton.Size = new Size(180, 23);
            AddNewUserButton.TabIndex = 23;
            AddNewUserButton.Text = "Добавить нового персонажа";
            AddNewUserButton.UseVisualStyleBackColor = true;
            AddNewUserButton.Click += AddNewUserButton_Click;
            // 
            // NewCharacterNameTextBox
            // 
            NewCharacterNameTextBox.Location = new Point(111, 11);
            NewCharacterNameTextBox.Name = "NewCharacterNameTextBox";
            NewCharacterNameTextBox.Size = new Size(200, 23);
            NewCharacterNameTextBox.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 44);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 27;
            label1.Text = "Имя игрока:";
            // 
            // PlayerNameTextBox
            // 
            PlayerNameTextBox.Location = new Point(111, 41);
            PlayerNameTextBox.Name = "PlayerNameTextBox";
            PlayerNameTextBox.Size = new Size(200, 23);
            PlayerNameTextBox.TabIndex = 25;
            PlayerNameTextBox.Text = "NPC";
            // 
            // ChronicleNameLabel
            // 
            ChronicleNameLabel.AutoSize = true;
            ChronicleNameLabel.Location = new Point(7, 73);
            ChronicleNameLabel.Name = "ChronicleNameLabel";
            ChronicleNameLabel.Size = new Size(57, 15);
            ChronicleNameLabel.TabIndex = 30;
            ChronicleNameLabel.Text = "Хроника:";
            // 
            // ChronicleNameTextBox
            // 
            ChronicleNameTextBox.Location = new Point(111, 70);
            ChronicleNameTextBox.Name = "ChronicleNameTextBox";
            ChronicleNameTextBox.Size = new Size(200, 23);
            ChronicleNameTextBox.TabIndex = 28;
            // 
            // AddNewCharacterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 101);
            Controls.Add(ChronicleNameLabel);
            Controls.Add(ChronicleNameTextBox);
            Controls.Add(label1);
            Controls.Add(PlayerNameTextBox);
            Controls.Add(CharacterNameLabel);
            Controls.Add(AddNewUserButton);
            Controls.Add(NewCharacterNameTextBox);
            Name = "AddNewCharacterForm";
            Text = "Новый персонаж";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CharacterNameLabel;
        private Button AddNewUserButton;
        private TextBox NewCharacterNameTextBox;
        private Label label1;
        private TextBox PlayerNameTextBox;
        private Label ChronicleNameLabel;
        private TextBox ChronicleNameTextBox;
    }
}