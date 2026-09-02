using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class AddNewCharacterForm : Form
{

    private CharacterManagment _characterManagment;

    private Character _character;

    public AddNewCharacterForm(CharacterManagment characterManagment, Character character = null)
    {
        InitializeComponent();
        _characterManagment = characterManagment;
        if (character is not null)
        {
            _character = JsonSerializer.Deserialize<Character>(JsonSerializer.Serialize(character));//making copy
            NewCharacterNameTextBox.Text = _character.CharacterName;
            PlayerNameTextBox.Text = _character.PlayerName;
            ChronicleNameTextBox.Text = _character.ChronicleName;
        }
        else
        {
            _character = new Character();
        }
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

        _character.CharacterName = NewCharacterNameTextBox.Text;
        _character.PlayerName = PlayerNameTextBox.Text;
        _character.ChronicleName = ChronicleNameTextBox.Text;

        _characterManagment.AddNewCharacter(_character);
        this.Close();
    }
}
