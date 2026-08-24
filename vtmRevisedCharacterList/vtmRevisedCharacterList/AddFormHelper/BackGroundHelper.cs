using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList.AddFormHelper;

public class BackGroundHelper : IAddFormHelper
{
    public IEnumerable<string> GetAutoComplete()
    {
        List<string> result = [];
        for (int i = 0; i < 10; i++)
        {
            var background = (DefaultBackground)i;
            result.Add(RussianTranslator.TranslateBackground(background));
        }
        return result;
    }
}
