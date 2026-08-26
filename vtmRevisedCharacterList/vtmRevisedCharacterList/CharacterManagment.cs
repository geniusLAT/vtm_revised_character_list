namespace vtmRevisedCharacterList;

public partial class CharacterManagment : Form
{
    public CharacterManagment(CharacterForm form)
    {
        _parentForm = form;

        
        InitializeComponent();

        Start();
    }

    private void CharacterManagment_FormClosed(object sender, FormClosedEventArgs e)
    {
        _parentForm.CharacterManagmentOpened = false;
    }

    private void InitRollButton_Click(object sender, EventArgs e)
    {
        RollInit();
    }
}
