using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class BloodBuffForm : Form
{
    public BloodBuffForm(CharacterForm parentForm, Character character)
    {
        _parentForm = parentForm;

        InitializeComponent();

        StartIt();

        RenderBloodBuffs(character);
    }

    private void BloodBuffForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _parentForm.BloodBuffWindowOpened = false;
    }
}
