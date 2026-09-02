using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

internal class GuiCharacterManagmentUserPanel 
{
    public required UserEntity User { get; set; }

    #region GUI
    public required Panel Panel { get; set; }
    public required Label Label { get; set; }

    #endregion
}
