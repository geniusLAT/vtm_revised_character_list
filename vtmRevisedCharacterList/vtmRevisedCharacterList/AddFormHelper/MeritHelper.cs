using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList.AddFormHelper;

public class MeritHelper : IAddFormHelper
{
    public bool Rated => false;

    public IEnumerable<string> GetAutoComplete()
    {
        List<string> result = [];
        for (int i = 0; i < 83; i++)
        {
            var merit = (DefaultMerit)i;
            result.Add(RussianTranslator.TranslateMerit(merit));
        }
        return result;
    }

    public void ProcessClick(AddARatingForm form, ARating item)
    {
        var index = form.FindClickedTextBoxIndex(item.Name);

    }

    public void ProcessCreatedItem(AddARatingForm form, ARating item)
    {
        var index = form.FindClickedTextBoxIndex(item.Name);

        DefaultMerit defaultMerit = (DefaultMerit)index;
        var merit = (MeritEntity)item;
        merit.DefaultMerit = defaultMerit;
    }   
}
