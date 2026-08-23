using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtmRevisedCharacterListEntities;

public static class ChangeLogGenerator
{
    public static string GenerateChangeLog(Character character1, Character character2)
    {
        StringBuilder sb = new StringBuilder();

        if (character1.CharacterName != character2.CharacterName)
        {
            sb.Append($"\n{RussianTranslator.CharacterName} {character1.CharacterName
                } {RussianTranslator.ChangedWord} {character2.CharacterName}");  
        }
        if (character1.PlayerName != character2.PlayerName)
        {
            sb.Append($"\n{RussianTranslator.PlayerName} {character1.PlayerName
                } {RussianTranslator.ChangedWord} {character2.PlayerName}");
        }
        if (character1.ChronicleName != character2.ChronicleName)
        {
            sb.Append($"\n{RussianTranslator.ChronicleName} {character1.ChronicleName
                } {RussianTranslator.ChangedWord} {character2.ChronicleName}");
        }

        for (int i = 0; i < 9; i++)
        {
            AttributeVtm attribute = (AttributeVtm)i;
            uint attributeValue1 = character1.GetAttribute(attribute);
            uint attributeValue2 = character2.GetAttribute(attribute);

            if (attributeValue1 != attributeValue2)
            {
                if (attributeValue1 > attributeValue2) //attribute decreased 
                {
                    sb.Append($"\n{RussianTranslator.TranslateAttribute(attribute)} {attributeValue1
                        } {RussianTranslator.DecreasedWord} {attributeValue2}");
                }
                if (attributeValue1 < attributeValue2) //attribute increased
                {
                    sb.Append($"\n{RussianTranslator.TranslateAttribute(attribute)} {attributeValue1
                        } {RussianTranslator.IncreasedWord} {attributeValue2}");
                }
            }
        }

        for (int i = 0; i < 30; i++)
        {
            Ability ability = (Ability)i;
            uint abilityValue1 = character1.GetAbility(ability);
            uint abilityValue2 = character2.GetAbility(ability);

            if (abilityValue1 != abilityValue2)
            {
                if (abilityValue1 > abilityValue2) //ability decreased 
                {
                    sb.Append($"\n{RussianTranslator.TranslateAbility(ability)} {abilityValue1} {RussianTranslator.DecreasedWord} {abilityValue2}");
                }
                if (abilityValue1 < abilityValue2) //ability increased
                {
                    sb.Append($"\n{RussianTranslator.TranslateAbility(ability)} {abilityValue1} {RussianTranslator.IncreasedWord} {abilityValue2}");
                }
            }

        }

        for (int i = 0; i < 5; i++)
        {
            OtherRollable other = (OtherRollable)i;
            uint otherValue1 = character1.GetOther(other);
            uint otherValue2 = character2.GetOther(other);

            if (otherValue1 != otherValue2)
            {
                if (otherValue1 > otherValue2) //ability decreased 
                {
                    sb.Append($"\n{RussianTranslator.TranslateOther(other)} {otherValue1} {RussianTranslator.DecreasedWord} {otherValue2}");
                }
                if (otherValue1 < otherValue2) //ability increased
                {
                    sb.Append($"\n{RussianTranslator.TranslateOther(other)} {otherValue1} {RussianTranslator.IncreasedWord} {otherValue2}");
                }
            }
        }

        if (character1.CommonDamage != character2.CommonDamage)
        {
            if (character1.CommonDamage > character2.CommonDamage) 
            {
                sb.Append($"\n{RussianTranslator.CommonDamage} {character1.CommonDamage} {RussianTranslator.DecreasedWord} {character2.CommonDamage}");
            }
            if (character1.CommonDamage < character2.CommonDamage) 
            {
                sb.Append($"\n{RussianTranslator.CommonDamage} {character1.CommonDamage} {RussianTranslator.IncreasedWord} {character2.CommonDamage}");
            }
        }

        if (character1.AggravatedDamage != character2.AggravatedDamage)
        {
            if (character1.AggravatedDamage > character2.AggravatedDamage)
            {
                sb.Append($"\n{RussianTranslator.AggravatedDamage} {character1.AggravatedDamage} {RussianTranslator.DecreasedWord} {character2.AggravatedDamage}");
            }
            if (character1.AggravatedDamage < character2.AggravatedDamage)
            {
                sb.Append($"\n{RussianTranslator.AggravatedDamage} {character1.AggravatedDamage} {RussianTranslator.IncreasedWord} {character2.AggravatedDamage}");
            }
        }

        if (character1.Damage != character2.Damage)
        {
            if (character1.Damage > character2.Damage)
            {
                sb.Append($"\n{RussianTranslator.Damage} {character1.Damage} {RussianTranslator.DecreasedWord} {character2.Damage}");
            }
            if (character1.Damage < character2.Damage)
            {
                sb.Append($"\n{RussianTranslator.Damage} {character1.Damage} {RussianTranslator.IncreasedWord} {character2.Damage}");
            }
        }

        if (character1.Bloodpool != character2.Bloodpool)
        {
            if (character1.Bloodpool > character2.Bloodpool)
            {
                sb.Append($"\n{RussianTranslator.Bloodpool} {character1.Bloodpool} {RussianTranslator.DecreasedWord} {character2.Bloodpool}");
            }
            if (character1.Bloodpool < character2.Bloodpool)
            {
                sb.Append($"\n{RussianTranslator.Bloodpool} {character1.Bloodpool} {RussianTranslator.IncreasedWord} {character2.Bloodpool}");
            }
        }

        if (sb.Length == 0)
        {
            return string.Empty;
        }

        return $"{character1.CharacterName} {sb.ToString()}";
    }
}
