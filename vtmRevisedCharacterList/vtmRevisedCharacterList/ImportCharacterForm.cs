using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class ImportCharacterForm : Form
{
    private CharacterManagment _characterManagment;

    public ImportCharacterForm(CharacterManagment characterManagment)
    {
        InitializeComponent();
        _characterManagment = characterManagment;
    }

    private void AddNewUserButton_Click(object sender, EventArgs e)
    {
        try
        {
            var character = JsonSerializer.Deserialize<Character>(ImportTextBox.Text);
            _characterManagment.AddNewCharacter(character);
            this.Close();
        }
        catch (JsonException ex)
        {

            MessageBox.Show(ex.Message);
            return;
        }
    }
}
