using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList
{
    public partial class AddNewCharacterForm : Form
    {

        private CharacterManagment _characterManagment;

        public AddNewCharacterForm(CharacterManagment characterManagment)
        {
            InitializeComponent();
            _characterManagment = characterManagment;
        }

        private void AddNewUserButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewCharacterNameTextBox.Text))
            {
                MessageBox.Show("Введите имя нового персонажа корректного");
                return;
            }

            if (string.IsNullOrWhiteSpace(PlayerNameTextBox.Text))
            {
                MessageBox.Show("Введите имя игрока корректно");
                return;
            }

            if (string.IsNullOrWhiteSpace(ChronicleNameTextBox.Text))
            {
                MessageBox.Show("Введите название хроники корректно");
                return;
            }

            Character newCharacter = new()
            {
                CharacterName = NewCharacterNameTextBox.Text,
                PlayerName = PlayerNameTextBox.Text,
                ChronicleName = ChronicleNameTextBox.Text,
            };

            _characterManagment.AddNewCharacter(newCharacter);
            this.Close();
        }
    }
}
