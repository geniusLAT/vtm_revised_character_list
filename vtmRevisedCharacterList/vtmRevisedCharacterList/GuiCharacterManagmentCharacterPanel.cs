using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

internal class GuiCharacterManagmentCharacterPanel
{
    public required Character Character { get; set; }

    public bool RollInit { get; set; }

    public bool Favorite { get; set; }

    public int LastRoundInit { get; set; }

    #region GUI
    public required Panel Panel { get; set; }

    public required Label Label { get; set; }

    public required Button Button { get; set; }
    public required CheckBox InitCheckBox { get; set; }

    #endregion
}
