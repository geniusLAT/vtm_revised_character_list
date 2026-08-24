using vtmRevisedCharacterList.AddFormHelper;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class AddARatingForm : Form
{
    public AddARatingForm(CharacterForm characterForm, List<ARating> collectionToAdd, Type type, IAddFormHelper helper)
    {
        _parentForm = characterForm;
        _collectionToAdd = collectionToAdd;
        _type = type;
        _helper = helper;

        InitializeComponent();
        AutoCompleteDefault();
        if (!_helper.Rated)
        {
            RatingNumeric.Visible
                 = RatingNumeric.Enabled
                 = RatingButton1.Visible
                 = RatingButton2.Visible
                 = RatingButton3.Visible
                 = RatingButton4.Visible
                 = RatingButton5.Visible
                 = false;
        }
        else
        {
            MeritSettingPanel.Visible = false;
        }

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

    private void DefaultOption_Click(object sender, EventArgs e)
    {
        LabelClicked(sender);
    }

    private void MeritDicepoolNumeric_ValueChanged(object sender, EventArgs e)
    {

    }
}
