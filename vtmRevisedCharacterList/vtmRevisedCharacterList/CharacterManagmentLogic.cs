using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class CharacterManagment : Form
{
    private CharacterForm _parentForm;

    private List<Character> characters = [];

    private List<GuiCharacterManagmentCharacterPanel> characterPanels = [];

    private void Start()
    {
        LoadCharacters();
        Render();
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

        foreach (var task in tasks)
        {
            characters.Add(task.Result);
        }
        MessageBox.Show($"loaded {characters.Count()}");
        
    }

    private void Render()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            var character = characters[i];

            var panel = new Panel()
            {
                BackColor = Color.White,
                Width = 300,
                Height = 20,
                Location = new(0, 20 * i),
            };
            CharacterListPanel.Controls.Add(panel);

            var label = new Label()
            {
                Text = character.CharacterName,
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
            };
            panel.Controls.Add(initCheckBox);

            characterPanels.Add(new()
            {
                Character = character,
                Panel = panel,
                Label = label,
                Button = button,
                InitCheckBox = initCheckBox

            }
                );
        }
    }
}
