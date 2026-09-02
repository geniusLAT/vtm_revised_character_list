namespace vtmRevisedCharacterList
{
    partial class AddNewUserForm
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
            NewUserNameTextBox = new TextBox();
            AddNewUserButton = new Button();
            UserNameLabel = new Label();
            SuspendLayout();
            // 
            // NewUserNameTextBox
            // 
            NewUserNameTextBox.Location = new Point(93, 13);
            NewUserNameTextBox.Name = "NewUserNameTextBox";
            NewUserNameTextBox.Size = new Size(200, 23);
            NewUserNameTextBox.TabIndex = 18;
            // 
            // AddNewUserButton
            // 
            AddNewUserButton.Location = new Point(299, 12);
            AddNewUserButton.Name = "AddNewUserButton";
            AddNewUserButton.Size = new Size(151, 23);
            AddNewUserButton.TabIndex = 20;
            AddNewUserButton.Text = "Добавить нового игрока";
            AddNewUserButton.UseVisualStyleBackColor = true;
            AddNewUserButton.Click += AddNewUserButton_Click;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(12, 16);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(75, 15);
            UserNameLabel.TabIndex = 21;
            UserNameLabel.Text = "Имя игрока:";
            // 
            // AddNewUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 39);
            Controls.Add(UserNameLabel);
            Controls.Add(AddNewUserButton);
            Controls.Add(NewUserNameTextBox);
            Name = "AddNewUserForm";
            Text = "AddNewUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NewUserNameTextBox;
        private Button AddNewUserButton;
        private Label UserNameLabel;
    }
}