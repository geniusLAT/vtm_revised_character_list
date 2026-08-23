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

namespace vtmRevisedCharacterList;

public partial class AddARatingForm : Form
{
    public AddARatingForm(CharacterForm characterForm, IEnumerable<ARating> collectionToAdd, Type type)
    {
        _parentForm = characterForm;
        _collectionToAdd = collectionToAdd;
        _type = type;

        InitializeComponent();
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        AddSomething();
    }

    private void RatingNumeric_ValueChanged(object sender, EventArgs e)
    {

    }
}
