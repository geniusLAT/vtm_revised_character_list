using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class BloodBuffForm : Form
{
    private CharacterForm _parentForm;

    public RadioButton[] BloodBuffStrenghtButtons = [];
    public RadioButton[] BloodBuffDexterityButtons = [];
    public RadioButton[] BloodBuffStaminaButtons = [];

    void StartIt()
    {
        FindButtons();
    }

    public RadioButton[]? GetAttributeButtons(AttributeVtm? attribute) => attribute switch
    {
        AttributeVtm.BloodBuffStrenght => BloodBuffStrenghtButtons,
        AttributeVtm.BloodBuffDexterity => BloodBuffDexterityButtons,
        AttributeVtm.BloodBuffStamina => BloodBuffStaminaButtons,
        _ => null
    };

    public NumericUpDown? GetAttributeNumeric(AttributeVtm? attribute)
    {
        switch (attribute)
        {
            case AttributeVtm.BloodBuffStrenght:

                return StrenghtNumeric;
            case AttributeVtm.BloodBuffDexterity:

                return DexterityNumeric;
            case AttributeVtm.BloodBuffStamina:

                return StaminaNumeric;
            default:
                break;
        }
        return null;
    }

    public void RenderBloodBuffs(Character character)
    {
        for (int i = 9; i < 12; i++)
        {
            AttributeVtm attribute = (AttributeVtm)i;
            uint attributeValue = character.GetAttribute(attribute);
            var numeric = GetAttributeNumeric(attribute);
            if (numeric is not null)
            {
                numeric.Value = attributeValue;
                numeric.Enabled = true;
                numeric.ValueChanged += CharacterNumeric_ValueChanged;
            }
            var attributeButtons = GetAttributeButtons(attribute);
            if (attributeButtons is not null)
            {
                _parentForm.SetButtonsForNum(attributeButtons, attributeValue);
            }

        }
    }

    void FindButtons()
    {
        BloodBuffStrenghtButtons = [SButton, SButton2, SButton3, SButton4, SButton5];
        BloodBuffDexterityButtons = [DexterityButton1, DexterityButton2, DexterityButton3, DexterityButton4, DexterityButton5];
        BloodBuffStaminaButtons = [StaminaButton1, StaminaButton2, StaminaButton3, StaminaButton4, StaminaButton5];
    }

    private void CharacterNumeric_ValueChanged(object sender, EventArgs e)
    {
        _parentForm.Invoke(new Action(() => _parentForm.MarkUnsavedChanges()));
    }
}
