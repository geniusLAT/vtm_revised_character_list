using System.Text;

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

        var backgroundChangeLog = GenerateChangeLogForCollection(
            character1.Backgrounds, 
            character2.Backgrounds, 
            RussianTranslator.Backgrounds);
        if (!string.IsNullOrEmpty(backgroundChangeLog))
        {
            sb.Append(backgroundChangeLog);
        }

        var disciplineChangeLog = GenerateChangeLogForCollection(
           character1.Disciplines,
           character2.Disciplines,
           RussianTranslator.Disciplines);
        if (!string.IsNullOrEmpty(disciplineChangeLog))
        {
            sb.Append(disciplineChangeLog);
        }

        var meritChangeLog = GenerateChangeLogForCollection(
          character1.Merits,
          character2.Merits,
          RussianTranslator.Merits);
        if (!string.IsNullOrEmpty(meritChangeLog))
        {
            sb.Append(meritChangeLog);
        }

        if (sb.Length == 0)
        {
            return string.Empty;
        }

        return $"{character1.CharacterName} {sb.ToString()}";
    }

    public static string GenerateChangeLogForCollection(IEnumerable<ARating> collection1, IEnumerable<ARating> collection2, string collectionName)
    {
        StringBuilder sb = new StringBuilder();

        if (collection1.Count() != collection2.Count())
        {
            if (collection1.Count() > collection2.Count())
            {
                sb.Append($"\n{collectionName}, {RussianTranslator.Lenght} {collection1.Count()} {RussianTranslator.DecreasedWord} {collection2.Count()}");
            }
            if (collection1.Count() < collection2.Count())
            {
                sb.Append($"\n{collectionName}, {RussianTranslator.Lenght} {collection1.Count()} {RussianTranslator.IncreasedWord} {collection2.Count()}");
            }
        }

        foreach (var item1 in collection1)
        {
            bool found = false;
            foreach (var item2 in collection2)
            {
                if (item1.Name == item2.Name)
                {
                    found = true;

                    if (item1.Rating != item2.Rating)
                    {
                        if (item1.Rating > item2.Rating)
                        {
                            sb.Append($"\n{item1.Name} {item1.Rating} {RussianTranslator.DecreasedWord} {item2.Rating}");
                        }
                        if (item1.Rating < item2.Rating)
                        {
                            sb.Append($"\n{item2.Name} {item1.Rating} {RussianTranslator.IncreasedWord} {item2.Rating}");
                        }
                    }
                    MeritEntity merit1 = item1 as MeritEntity;
                    MeritEntity merit2 = item2 as MeritEntity;
                    if (merit1 is not null && merit2 is not null && merit1 != merit2)
                    {
                        sb.Append(ChangeLogForMerits(merit1, merit2));
                    }
                }
            }

            if (!found)
            {
                sb.Append($"\n{item1.Name} {item1.Rating} {RussianTranslator.Removed}");
               
            }
        }

        foreach (var item1 in collection2)
        {
            bool found = false;
            foreach (var item2 in collection1)
            {
                if (item1.Name == item2.Name)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                sb.Append($"\n{item1.Name} {item1.Rating} {RussianTranslator.Added}");
                if (item1 is MeritEntity)
                {
                    sb.Append($"\n{MeritDescription(item1 as MeritEntity)}");
                }

            }
        }

        return sb.ToString();
    }

    public static string MeritDescription(MeritEntity merit)
    {
        var sb = new StringBuilder();

        if (merit.CanBeActivated)
        {
            sb.Append($"\n{merit.Name} {RussianTranslator.CanBeActivated} {RussianTranslator.Activated}");
        }
        if (merit.Effect.DaredevilRemoveOne)
        {
            sb.Append($"\n{merit.Name} {RussianTranslator.DaredevilRemoveOne} {RussianTranslator.Activated}");
        }
        if (merit.Effect.ExtraHealth)
        {
            sb.Append($"\n{merit.Name} {RussianTranslator.ExtraHealth} {RussianTranslator.Activated}");
        }
        if (merit.Effect.MeritDifficultyEffect != 0)
        {
            sb.Append($"\n{merit.Name} {RussianTranslator.MeritDifficultyEffect} {merit.Effect.MeritDifficultyEffect}");
        }
        if (merit.Effect.MeritDicepoolEffect != 0)
        {
            sb.Append($"\n{merit.Name} {RussianTranslator.MeritDicepoolEffect} {merit.Effect.MeritDicepoolEffect}");
        }

        return sb.ToString();
    }

    public static string ChangeLogForMerits(MeritEntity merit1, MeritEntity merit2)
    {
        StringBuilder sb = new StringBuilder();


        {
            bool someLog = false;
            //Not sure if needed
            if (merit2.Active != merit1.Active)
            {
                if (merit2.Active)
                {
                    sb.Append($"\n{merit2.Name} {RussianTranslator.Activated}");
                }
                else
                {
                    sb.Append($"\n{merit2.Name} {RussianTranslator.Disactivated}");
                }
                someLog = true;
            }

            if (merit2.Effect.DaredevilRemoveOne != merit1.Effect.DaredevilRemoveOne)
            {
                if (merit2.Effect.DaredevilRemoveOne)
                {
                    sb.Append($"\n{merit2.Name} {RussianTranslator.DaredevilRemoveOne} {RussianTranslator.Activated}");
                }
                else
                {
                    sb.Append($"\n{merit2.Name} {RussianTranslator.DaredevilRemoveOne} {RussianTranslator.Disactivated}");
                }
                someLog = true;
            }

            if (merit2.CanBeActivated != merit1.CanBeActivated)
            {
                if (merit2.CanBeActivated)
                {
                    sb.Append($"\n{merit2.Name} {RussianTranslator.CanBeActivated} {RussianTranslator.Activated}");
                }
                else
                {
                    sb.Append($"\n{merit2.Name} {RussianTranslator.CanBeActivated} {RussianTranslator.Disactivated}");
                }
                someLog = true;
            }

            if (merit2.Effect.MeritDicepoolEffect != merit1.Effect.MeritDicepoolEffect)
            {
                if (merit1.Effect.MeritDicepoolEffect > merit2.Effect.MeritDicepoolEffect)
                {
                    sb.Append($"\n{merit1.Name} {RussianTranslator.MeritDicepoolEffect} {merit1.Effect.MeritDicepoolEffect} {RussianTranslator.DecreasedWord} {merit2.Effect.MeritDicepoolEffect}");
                }
                else
                {
                    sb.Append($"\n{merit1.Name} {RussianTranslator.MeritDicepoolEffect} {merit1.Effect.MeritDicepoolEffect} {RussianTranslator.IncreasedWord} {merit2.Effect.MeritDicepoolEffect}");
                }
                someLog = true;
            }

            if (merit2.Effect.MeritDifficultyEffect != merit1.Effect.MeritDifficultyEffect)
            {
                if (merit1.Effect.MeritDifficultyEffect > merit2.Effect.MeritDifficultyEffect)
                {
                    sb.Append($"\n{merit1.Name} {RussianTranslator.MeritDifficultyEffect} {merit1.Effect.MeritDifficultyEffect} {RussianTranslator.DecreasedWord} {merit2.Effect.MeritDifficultyEffect}");
                }
                else
                {
                    sb.Append($"\n{merit1.Name} {RussianTranslator.MeritDifficultyEffect} {merit1.Effect.MeritDifficultyEffect} {RussianTranslator.IncreasedWord} {merit2.Effect.MeritDifficultyEffect}");
                }
                someLog = true;
            }

        }
        return sb.ToString();
    }
}
