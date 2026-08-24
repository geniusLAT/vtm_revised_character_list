using System.Data;
using vtmRevisedCharacterList.AddFormHelper;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class AddARatingForm : Form
{
    #region FromConstructor

    CharacterForm _parentForm;

    List<ARating> _collectionToAdd;

    Type _type;

    IAddFormHelper _helper;

    #endregion

    #region GeneratedFields

    private List<Label> _defaultOptionsLabels = [];

    #endregion

    private void AutoCompleteDefault()
    {
        var autocompleteOptions = _helper.GetAutoComplete().ToArray();

       for (int i = 0; i < autocompleteOptions.Count(); i++)
       {
            var option = autocompleteOptions[i];
            var label = new Label()
            {
                Width = 76,
                Height = 15,
                Text = option,
                Font = new("Segoe UI", 9),
                Location = new Point(3, 4 + 15 * i)
            };
            label.Click += DefaultOption_Click;
            DefaultOptionsPanel.Controls.Add(label);
            _defaultOptionsLabels.Add(label);
        }
    }

    public void AddSomething()
    {
        var name = NameTextBox.Text.Trim();
        if (name.Length < 1)
        {
            MessageBox.Show("Неверное имя. Его необходимо ввести");
            return;
        }

        var sameNamedItem = _collectionToAdd.Where(item =>  item.Name == name).FirstOrDefault();
        if (sameNamedItem != null)
        {
            MessageBox.Show($"{name} уже есть в этом списке");
            return;
        }

        ARating created = (ARating)Activator.CreateInstance(_type);
        created.Name = name;
        created.Rating = (uint)RatingNumeric.Value;
        _collectionToAdd.Add(created);

        _parentForm.RenderCharacter();

        _parentForm.UpdateCharacter();

        this.Close();
    }

    private void LabelClicked(object sender)
    {
        var label = (Label)sender;
        NameTextBox.Text = label.Text;
    }
}
