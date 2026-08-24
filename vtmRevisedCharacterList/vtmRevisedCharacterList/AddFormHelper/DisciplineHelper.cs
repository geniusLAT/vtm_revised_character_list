using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList.AddFormHelper;

public class DisciplineHelper : IAddFormHelper
{
    public IEnumerable<string> GetAutoComplete()
    {
        List<string> result = [];
        for (int i = 0; i < 23; i++)
        {
            var discipline = (DefaultDiscipline)i;
            result.Add(RussianTranslator.TranslateDiscipline(discipline));
        }
        return result;
    }
}
