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
    public AddARatingForm(CharacterForm characterForm, List<ARating> collectionToAdd, Type type)
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
        var v = RatingNumeric.Value;
        if (v > 1)
        {
            RatingButton2.Checked = true;
        }
        else
        {
            RatingButton2.Checked = false;
        }
        if (v > 2)
        {
            RatingButton3.Checked = true;
        }
        else
        {
            RatingButton3.Checked = false;
        }
        if (v > 3)
        {
            RatingButton4.Checked = true;
        }
        else
        {
            RatingButton4.Checked = false;
        }
        if (v > 4)
        {
            RatingButton5.Checked = true;
        }
        else
        {
            RatingButton5.Checked = false;
        }
    }
}
