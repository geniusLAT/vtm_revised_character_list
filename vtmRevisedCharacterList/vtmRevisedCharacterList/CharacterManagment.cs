namespace vtmRevisedCharacterList;

public partial class CharacterManagment : Form
{
    public CharacterManagment(CharacterForm form)
    {
        _parentForm = form;

        InitializeComponent();
    }

    private void CharacterManagment_FormClosed(object sender, FormClosedEventArgs e)
    {
        _parentForm.CharacterManagmentOpened = false;
    }
}
