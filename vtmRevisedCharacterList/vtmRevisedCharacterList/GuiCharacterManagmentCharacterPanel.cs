using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

internal class GuiCharacterManagmentCharacterPanel : IComparable<GuiCharacterManagmentCharacterPanel>
{
    public required Character Character { get; set; }

    public required Guid CharacterUuid { get; set; }

    public bool RollInit { get; set; }

    public bool Favorite { get; set; }

    public int LastRoundInit { get; set; }

    #region GUI
    public required Panel Panel { get; set; }

    public required Label Label { get; set; }
    public required Label InitLabel { get; set; }

    public required Button Button { get; set; }

    public required CheckBox InitCheckBox { get; set; }

    public  required CheckBox UserRightCheckBox { get; set; }

    public required NumericUpDown NumericBonus { get; set; }

    public int CompareTo(GuiCharacterManagmentCharacterPanel? other)
    {
        if (this.Favorite && !other.Favorite) return 1;

        if(LastRoundInit > other.LastRoundInit) return -1;

        return 0;
    }

    #endregion
}
