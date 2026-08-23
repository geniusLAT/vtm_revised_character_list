using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class AddARatingForm : Form
{
    CharacterForm _parentForm;

    List<ARating> _collectionToAdd;

    Type _type;

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

        MessageBox.Show($"{_collectionToAdd.Count()}");

        this.Close();
    }
}
