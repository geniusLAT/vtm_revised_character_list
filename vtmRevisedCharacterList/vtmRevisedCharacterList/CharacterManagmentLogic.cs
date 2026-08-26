using System.Text;
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

    private string FormMessage()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var character in characterPanels) {

            if(character.LastRoundInit < 1)
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

        foreach (var task in tasks)
        {
            characters.Add(task.Result);
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

    private void Render()
    {
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
                Value = character.Dexterity,
                Minimum = -100,
                Maximum = 100,
                Width = 30,
                Location = new(230, 5),
            };
            panel.Controls.Add(numericBonus);


            characterPanels.Add(new()
            {
                Character = character,
                Panel = panel,
                Label = label,
                Button = button,
                InitCheckBox = initCheckBox,
                InitLabel = initLabel,
                NumericBonus = numericBonus

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
}
