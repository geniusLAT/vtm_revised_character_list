using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtmRevisedCharacterList.AddFormHelper;

public interface IAddFormHelper
{
    public IEnumerable<string> GetAutoComplete();
}
