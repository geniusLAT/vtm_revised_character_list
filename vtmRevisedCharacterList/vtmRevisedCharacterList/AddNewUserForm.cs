namespace vtmRevisedCharacterList;

public partial class AddNewUserForm : Form
{
    private CharacterManagment _characterManagment;

    public AddNewUserForm(CharacterManagment characterManagment)
    {
        InitializeComponent();
        _characterManagment = characterManagment;
    }

    private void AddNewUserButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewUserNameTextBox.Text))
        {
            MessageBox.Show("Введите имя нового игрока корректного");
            return;
        }
        _characterManagment.AddNewUser(NewUserNameTextBox.Text);
        this.Close();
    }
}
