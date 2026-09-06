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

    private void DropBloodBuffButton_Click(object sender, EventArgs e)
    {
        StrenghtNumeric.Value
            = DexterityNumeric.Value
            = StaminaNumeric.Value
            = 0;
    }

    private void BloodBuffMode_CheckedChanged(object sender, EventArgs e)
    {

        _parentForm.Invoke(new Action(() => _parentForm.SyncBloodModeCheckBoxStatus(BloodBuffMode.Checked)));
    }
}
