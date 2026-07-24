using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class CharacterForm : Form
{
    AttributeVtm? _chosenAttribute;

    #region RadioButtons

    #region AttributeButtons;
    RadioButton[] StrenghtButtons = [];
    RadioButton[] DexterityButtons = [];
    RadioButton[] StaminaButtons = [];

    RadioButton[] CharismaButtons = [];
    RadioButton[] ManipulationButtons = [];
    RadioButton[] AppearanceButtons = [];

    RadioButton[] PerceptionButtons = [];
    RadioButton[] IntelligeceButtons = [];
    RadioButton[] WitsButtons = [];
    #endregion

    #endregion

    void FindButtonsForAttributes()
    {
        StrenghtButtons = [SButton, SButton2, SButton3, SButton4, SButton5];
        DexterityButtons = [DexterityButton1, DexterityButton2 , DexterityButton3, DexterityButton4, DexterityButton5];
        StaminaButtons = [StaminaButton1, StaminaButton2, StaminaButton3 , StaminaButton4, StaminaButton5];
        CharismaButtons = [CharismaButton1, CharismaButton2, CharismaButton3, CharismaButton4, CharismaButton5];
        ManipulationButtons = [ManupulationButton1, ManupulationButton2, ManupulationButton3, ManupulationButton4, ManupulationButton5];
        AppearanceButtons = [AppearanceButton1, AppearanceButton2, AppearanceButton3, AppearanceButton4, AppearanceButton5];
        PerceptionButtons = [PerceptionButton1, PerceptionButton2, PerceptionButton3, PerceptionButton4, PerceptionButton5];
        IntelligeceButtons = [IntelligeceButton1, IntelligeceButton2, IntelligeceButton3, IntelligeceButton4, IntelligeceButton5];
    }

    void ClearAttributeChoice()
    {
        StrenghtPanel.BackColor =
            DexterityPanel1.BackColor =
            StaminaPanel.BackColor =
            CharismaPanel.BackColor =
            ManipulationPanel.BackColor =
            AppearancePanel.BackColor =
            PerceptionPanel.BackColor =
            IntelligecePanel.BackColor =
            WitsPanel.BackColor =
            Color.White;
    }
    
    void SetButtonsForNum(RadioButton[] buttons, uint numToSet)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < numToSet)
            {
                buttons[i].Checked = true;
            }else
            {
                buttons[i].Checked = false;
            }
        }
    }

    Panel? GetAttributePanel(AttributeVtm? attribute)
    {
        switch (attribute)
        {
            case AttributeVtm.Strenght:
                return StrenghtPanel;
            case AttributeVtm.Dexterity:
                return DexterityPanel1;
            case AttributeVtm.Stamina:
                return StaminaPanel;
            case AttributeVtm.Charisma:
                return CharismaPanel;
            case AttributeVtm.Manipulation:
                return ManipulationPanel;
            case AttributeVtm.Appearance:
                return AppearancePanel;
            case AttributeVtm.Perception:
                return PerceptionPanel;
            case AttributeVtm.Intelligance:
                return IntelligecePanel;
            case AttributeVtm.Wits:
                return WitsPanel;
            case null:
            default:
                return null;
        }
    }

    RadioButton[]? GetAttributeButtons(AttributeVtm? attribute)
    {
        switch (attribute)
        {
            case AttributeVtm.Strenght:
                return StrenghtButtons;
            case AttributeVtm.Dexterity:
                return DexterityButtons;
            case AttributeVtm.Stamina:
                return StaminaButtons;
            case AttributeVtm.Charisma:
                return CharismaButtons;
            case AttributeVtm.Manipulation:
                return ManipulationButtons;
            case AttributeVtm.Appearance:
                return AppearanceButtons;
            case AttributeVtm.Perception:
                return PerceptionButtons;
            case AttributeVtm.Intelligance:
                return IntelligeceButtons;
            case AttributeVtm.Wits:
                return WitsButtons;
            case null:
            default:
                return null;
        }
    }

    NumericUpDown? GetAttributeNumeric(AttributeVtm? attribute)
    {
        switch (attribute)
        {
            case AttributeVtm.Strenght:
                return StrenghtNumeric;
            case AttributeVtm.Dexterity:
                return DexterityNumeric;
            case AttributeVtm.Stamina:
                return StaminaNumeric;
            case AttributeVtm.Charisma:
                return CharismaNumeric;
            case AttributeVtm.Manipulation:
                return ManupulationNumeric;
            case AttributeVtm.Appearance:
                return AppearanceNumeric;
            case AttributeVtm.Perception:
                return PerceptionNumeric;
            case AttributeVtm.Intelligance:
                return IntelligeceNumeric;
            case AttributeVtm.Wits:
                return WitsNumeric;
            case null:
            default:
                return null;
        }
    }

    void ChooseAttribute(AttributeVtm attribute)
    {
        _chosenAttribute = attribute;
        ClearAttributeChoice();
        var panel = GetAttributePanel(_chosenAttribute);
        if (panel != null)
        {
            panel.BackColor = Color.Yellow;
        }
    }

    void RenderCharacter(Character character)
    {
        for (int i = 0; i < 9; i++)
        {
            AttributeVtm attribute = (AttributeVtm)i;
            uint attributeValue = character.GetAttribute(attribute);
            GetAttributeNumeric(attribute)!.Value = attributeValue;
            SetButtonsForNum( GetAttributeButtons(attribute), attributeValue);

        }
    }
}
