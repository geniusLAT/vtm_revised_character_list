using System.Net.Http.Json;
using System.Text;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class CharacterManagment : Form
{
    private CharacterForm _parentForm;

    private List<CharacterExtended> characters = [];

    private List<UserGetResult> users = [];

    private List<GuiCharacterManagmentCharacterPanel> characterPanels = [];

    private List<GuiCharacterManagmentUserPanel> userPanels = [];

    private GuiCharacterManagmentUserPanel? _chosenUserPanel;

    private bool _unsavedUser = false;

    private void Start()
    {
        LoadCharacters();
        LoadUsers();
        RenderCharacters();
        RenderUsers();

        SetUnsavedUserStatus(false);
    }

    private string FormMessage()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var character in characterPanels) {

            if (character.LastRoundInit < 1)
            {
                break;
            }
            sb.Append($"{character.LastRoundInit} {character.Character.CharacterName}\n");

        }
        return sb.ToString();
    }

    private void Sort()
    {
        characterPanels.Sort();
        var gap = 0;
        var notInit = false;
        for (int i = 0; i < characterPanels.Count; i++)
        {
            var panel = characterPanels[i];

            if (!notInit && panel.LastRoundInit == 0)
            {
                notInit = true;
                gap = 1;
            }

            panel.Panel.Location = new Point(0, 20 * (i + gap));
        }

    }

    private void LoadCharacters()
    {
        List<Task<Character>> tasks = new List<Task<Character>>();
        for (int i = 0; i < _parentForm.AvaliableCharacters.Count; i++)
        {
            vtmRevisedCharacterListEntities.CharacterListMember? character = _parentForm.AvaliableCharacters[i];

            var loadedCharacter = Task.Run(async () => await _parentForm.GetCharacterAsync(character, _parentForm.Config.UserId));

            tasks.Add(loadedCharacter);
        }

        Task.WaitAll(tasks);

        for (int i = 0; i < tasks.Count; i++)
        {
            Task<Character>? task = tasks[i];
            characters.Add(new()
            {
                Character =task.Result,
                Uuid = _parentForm.AvaliableCharacters[i].CharacterUuid
            }
                );
        }
        //MessageBox.Show($"loaded {characters.Count()}");

    }

    private void RollInit()
    {
        var initCharacters = characterPanels.Where(character => character.RollInit).ToList();
        //MessageBox.Show($"loaded {initCharacters.Count()}");
        Random rnd = new Random();
        foreach (var character in initCharacters)
        {
            var bonus = (int)character.NumericBonus.Value;
            character.LastRoundInit = rnd.Next(1, 11) + bonus;
            character.InitLabel.Text = character.LastRoundInit.ToString();
        }

        var notInitCharacters = characterPanels.Where(character => !character.RollInit).ToList();
        foreach (var character in notInitCharacters)
        {
            character.LastRoundInit = 0;
            character.InitLabel.Text = string.Empty;
        }

        Sort();

        var message = FormMessage();
        if (message is null)
            return;

        //_parentForm.Invoke

        _parentForm.Invoke(new Action(() => _parentForm.SendInit(message)));
    }

    private void RenderUserRights()
    {
        foreach (var item in characterPanels)
        {
            item.UserRightCheckBox.CheckedChanged -= UserRightCheckox_CheckedChanged;
            item.UserRightCheckBox.Visible = _chosenUserPanel is not null;
            item.UserRightCheckBox.Checked = _chosenUserPanel?.User.AccessedCharacters.Contains(item.CharacterUuid) ?? false;
            item.UserRightCheckBox.CheckedChanged += UserRightCheckox_CheckedChanged;
        }
    }

    private void RenderCharacters()
    {
        CharacterListPanel.Controls.Clear();

        for (int i = 0; i < characters.Count; i++)
        {
            var character = characters[i];

            var panel = new Panel()
            {
                BackColor = Color.White,
                Width = 500,
                Height = 20,
                Location = new(0, 20 * i),
            };
            CharacterListPanel.Controls.Add(panel);

            var label = new Label()
            {
                Text = character.Character.CharacterName,
                Width = 100,
                Height = 20,
                //BackColor = Color.BlueViolet,
            };
            panel.Controls.Add(label);

            var button = new Button()
            {
                Text = "Открыть",
                Width = 90,
                Location = new(100, 0),
            };
            panel.Controls.Add(button);

            var initCheckBox = new CheckBox()
            {
                Location = new(190, 0),
                Width = 20,
            };
            initCheckBox.CheckedChanged += InitCheckox_CheckedChanged;
            panel.Controls.Add(initCheckBox);

            var initLabel = new Label()
            {
                Text = "-",
                Width = 20,
                Height = 20,
                Location = new(210, 5),
                //BackColor = Color.Black,
            };
            panel.Controls.Add(initLabel);

            var numericBonus = new NumericUpDown()
            {
                Value = character.Character.Dexterity,
                Minimum = -100,
                Maximum = 100,
                Width = 30,
                Location = new(230, 5),
            };
            panel.Controls.Add(numericBonus);


            var userRightCheckBox = new CheckBox()
            {
                Location = new(260, 0),
                Width = 20,
                Visible = _chosenUserPanel is not null,
                Checked = _chosenUserPanel?.User.AccessedCharacters.Contains(character.Uuid) ?? false
            };
            userRightCheckBox.CheckedChanged += UserRightCheckox_CheckedChanged;
            panel.Controls.Add(userRightCheckBox);

            characterPanels.Add(new()
            {
                Character = character.Character,
                Panel = panel,
                Label = label,
                Button = button,
                InitCheckBox = initCheckBox,
                InitLabel = initLabel,
                NumericBonus = numericBonus,
                UserRightCheckBox = userRightCheckBox,
                CharacterUuid = character.Uuid
                
            }
                );
        }
    }

    private void InitCheckox_CheckedChanged(object sender, EventArgs e)
    {
        var panel = characterPanels.Where(guiPanel => guiPanel.InitCheckBox == sender).FirstOrDefault();
        if (panel is null) return;

        panel.RollInit = true;
    }

    private void UserRightCheckox_CheckedChanged(object sender, EventArgs e)
    {
        if (_chosenUserPanel is null)
            return;

        var panel = characterPanels.Where(guiPanel => guiPanel.UserRightCheckBox == sender).FirstOrDefault();
        if (panel is null) return;

        if (panel.UserRightCheckBox.Checked)
        {
            _chosenUserPanel.User.AccessedCharacters.Add(panel.CharacterUuid);
        }
        else
        {
            _chosenUserPanel.User.AccessedCharacters.Remove(panel.CharacterUuid);
        }
        SetUnsavedUserStatus(true);
    }

    private void LoadUsers()
    {
        var loadedUsersTask = Task.Run(async () => await GetUsersAsync(_parentForm.Config.UserId));
        loadedUsersTask.Wait();
        users = loadedUsersTask.Result;
    }

    #region Users

    #region Network
    private async Task<List<UserGetResult>> GetUsersAsync(Guid adminGuid)
    {
        try
        {
            var response = await _parentForm.HttpClient.GetAsync($"/User/all?adminId={adminGuid}");
            response.EnsureSuccessStatusCode();

            var responseRequest = await response.Content.ReadFromJsonAsync<List<UserGetResult>>();
            return responseRequest;
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка сети или сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return [];
    }

    private async Task<Guid?> CreateUserAsync(Guid adminGuid, UserEntity userToCreate)
    {
        try
        {
            var request = new UserCreateRequest()
            {
                AdminUuid = adminGuid,
                User = userToCreate
            };

            var response = await _parentForm.HttpClient.PostAsJsonAsync($"/User/create",request);
            response.EnsureSuccessStatusCode();

            var responseRequest = await response.Content.ReadFromJsonAsync<Guid>();
            return responseRequest;
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка сети или сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return null;
    }

    private async Task<bool> DeleteUserAsync(Guid adminGuid, Guid userUuid)
    {
        try
        {
            var deleteRequest = new UserDeleteRequest()
            {
                AdminUuid = adminGuid,
                UserUuid = userUuid
            };

            var request = new HttpRequestMessage(HttpMethod.Delete, "/User")
            {
                Content = JsonContent.Create(deleteRequest) 
            };

            var response = await _parentForm.HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseRequest = await response.Content.ReadFromJsonAsync<bool>();
            return responseRequest;
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка сети или сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }

    private async Task<bool> UpdateUserAsync(Guid adminGuid, Guid userUuid, UserEntity user)
    {
        try
        {
            var updateRequest = new UserUpdateRequest()
            {
                AdminUuid = adminGuid,
                UserUuid = userUuid,
                User = user
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/User")
            {
                Content = JsonContent.Create(updateRequest)
            };

            var response = await _parentForm.HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка сети или сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }

    #endregion
    private void RenderUsers()
    {
        UserListPanel.Controls.Clear();
        UserNameTextBox.TextChanged -= UserNameTextBox_TextChanged;
        UserNameTextBox.Text = string.Empty;
        
        UserNameTextBox.TextChanged += UserNameTextBox_TextChanged;
        _chosenUserPanel = null;
        for (int i = 0; i < users.Count; i++)
        {
            var user = users[i];

            var panel = new Panel()
            {
                BackColor = Color.White,
                Width = 500,
                Height = 20,
                Location = new(0, 20 * i),
            };
            panel.Click += UserPanel_Clicked;
            UserListPanel.Controls.Add(panel);

            var label = new Label()
            {
                Text = user.User.Name,
                Width = 100,
                Height = 20,
                //BackColor = Color.BlueViolet,
            };
            label.Click += UserPanel_Clicked;
            panel.Controls.Add(label);

            userPanels.Add(new()
            {
                User = user.User,
                Panel = panel,
                Label = label,
                UserUuid = user.UserUuid
            }
                );
        }
    }

    private void UserPanel_Clicked(object sender, EventArgs e)
    {
        var panel = userPanels.Where(guiPanel => guiPanel.Label == sender || guiPanel.Panel == sender).FirstOrDefault();
        if (panel is null) return;
        ChooseUserPanel(panel);

    }

    private void ChooseUserPanel(GuiCharacterManagmentUserPanel userPanel)
    {
        if (_unsavedUser) return; //can not change if unsaved

        if (_chosenUserPanel is not null)
        {
            _chosenUserPanel.Panel.BackColor = Color.White;
            _chosenUserPanel.Label.ForeColor = Color.Black;
        }
        _chosenUserPanel = userPanel;
        _chosenUserPanel.Panel.BackColor = Color.Blue;
        _chosenUserPanel.Label.ForeColor = Color.White;

        UserNameTextBox.TextChanged -= UserNameTextBox_TextChanged;
        UserNameTextBox.Text = _chosenUserPanel.User.Name;
        UserNameTextBox.TextChanged += UserNameTextBox_TextChanged;

        RenderUserRights();
    }

    void SetUnsavedUserStatus(bool status)
    {
        _unsavedUser = status;

        SaveUserButton.Enabled = status;
        AddNewUserButton.Enabled = !status;

        if (status)
        {
            if (_chosenUserPanel is not null)
            {
                _chosenUserPanel.Panel.BackColor = Color.Orange;
            }
        }
        else
        {
            if (_chosenUserPanel is not null)
            {
                _chosenUserPanel.Panel.BackColor = Color.Blue;
            }
        }
    }

    private void UserNameTextBox_TextChanged(object sender, EventArgs e)
    {
        _chosenUserPanel.User.Name = UserNameTextBox.Text;
        SetUnsavedUserStatus(true);

    }

    private void OpenAddNewUserForm()
    {
        var form = new AddNewUserForm(this);
        form.ShowDialog();
    }

    public void AddNewUser(string username)
    {
        UserEntity userToCreate = new()
        {
            Name = username
        };

        var loadedUsersTask = Task.Run(async () => await CreateUserAsync(_parentForm.Config.UserId, userToCreate));
        loadedUsersTask.Wait();
        var newUserGuid = loadedUsersTask.Result;
        if (newUserGuid is not null) {
            users.Add(new()
            {
                User = userToCreate,
                UserUuid = (Guid)newUserGuid
            }); 
        }

        RenderUsers();
    }

    public void DeleteUser()
    {
        var loadedUsersTask = Task.Run(async () => await DeleteUserAsync(_parentForm.Config.UserId, _chosenUserPanel.UserUuid));
        loadedUsersTask.Wait();
        var success = loadedUsersTask.Result;
        if (success)
        {
            var userToRemove = users.Where(user => user.UserUuid == _chosenUserPanel.UserUuid).FirstOrDefault();
            users.Remove(userToRemove);
        }

        RenderUsers();
    }

    public void UpdateUser()
    {
        if(_chosenUserPanel is null)
            return;

        var task = Task.Run(async () => await UpdateUserAsync(
            _parentForm.Config.UserId, 
            _chosenUserPanel.UserUuid, 
            _chosenUserPanel.User)
        );
        task.Wait();
        var success = task.Result;

        if (success)
        {
            RenderUsers();
            SetUnsavedUserStatus(false);
        }
    }

    #endregion
}
