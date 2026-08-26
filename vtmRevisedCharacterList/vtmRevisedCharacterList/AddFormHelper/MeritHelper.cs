using System.Drawing.Imaging.Effects;
using System.Text.Json;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList.AddFormHelper;

public class MeritHelper : IAddFormHelper
{
    public bool Rated => false;

    public IEnumerable<string> GetAutoComplete()
    {
        List<string> result = [];
        for (int i = 0; i < 83; i++)
        {
            var merit = (DefaultMerit)i;
            result.Add(RussianTranslator.TranslateMerit(merit));
        }
        return result;
    }

    public void ProcessClick(AddARatingForm form)
    {
        var name = form.NameTextBox.Text.Trim();
        var index = form.FindClickedTextBoxIndex(name);
        DefaultMerit? defaultMerit = (DefaultMerit)index;
        if (defaultMerit is not null)
        {
            var effect = GetMeritEffectForDefaultMerit((DefaultMerit)defaultMerit);

            form.CanBeActivatedCheckBox.Checked = !effect.Narrative;
            form.MeritDicepoolNumeric.Value = effect.MeritDicepoolEffect;
            form.MeritDiffiultyNumeric.Value = effect.MeritDifficultyEffect;
            form.RemoveOneCheckBox.Checked = effect.DaredevilRemoveOne;
            form.ExtraHealthCheckBox.Checked = effect.ExtraHealth;
        }
    }

    public void ProcessCreatedItem(AddARatingForm form, ARating item)
    {
        var index = form.FindClickedTextBoxIndex(item.Name);

        DefaultMerit defaultMerit = (DefaultMerit)index;
        var merit = (MeritEntity)item;
        merit.DefaultMerit = defaultMerit;

        MeritEffect effect = new();

        merit.CanBeActivated = form.CanBeActivatedCheckBox.Checked;
        effect.MeritDicepoolEffect = (int)form.MeritDicepoolNumeric.Value;
        effect.MeritDifficultyEffect = (int)form.MeritDiffiultyNumeric.Value;
        effect.DaredevilRemoveOne = form.RemoveOneCheckBox.Checked;
        effect.ExtraHealth = form.ExtraHealthCheckBox.Checked;

        MessageBox.Show(JsonSerializer.Serialize(merit));

        merit.Effect = effect;
    }

    MeritEffect GetMeritEffectForDefaultMerit(DefaultMerit defaultMerit)
    {
        MeritEffect result = new();

        switch (defaultMerit)
        {
            case DefaultMerit.AcuteSense:
                result.MeritDifficultyEffect = -2;
                return result;
            case DefaultMerit.Ambidextrous:
                return result;
            case DefaultMerit.EatFood:
                return result;
            case DefaultMerit.CatlikeBalance:
                result.MeritDifficultyEffect = -2;
                return result;
            case DefaultMerit.BlushOfHealth:
                return result;
            case DefaultMerit.EnchantingVoice:
                result.MeritDifficultyEffect = -2;
                return result;
            case DefaultMerit.DareDevil:
                result.MeritDicepoolEffect = +3;
                result.DaredevilRemoveOne = true;
                return result;
            case DefaultMerit.EfficientDigestion:
                return result;
            case DefaultMerit.HugeSize:
                result.ExtraHealth = true;
                return result;
            case DefaultMerit.SmellOfTheGrave:
                result.MeritDifficultyEffect = +1;
                return result;
            case DefaultMerit.Short:
                return result;
            case DefaultMerit.HardOfHearing:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.FourteenthGeneration:
                return result;
            case DefaultMerit.InfectiousBite:
                return result;
            case DefaultMerit.BadSight:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.OneEye:
                result.MeritDifficultyEffect = +1;
                return result;
            case DefaultMerit.Disfigured:
                return result;
            case DefaultMerit.Child:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.Deformity:
                return result;
            case DefaultMerit.Lame:
                return result;
            case DefaultMerit.Monstrous:
                return result;
            case DefaultMerit.PermanentWound:
                return result;
            case DefaultMerit.SlowHealing:
                return result;
            case DefaultMerit.Addiction:
                return result;
            case DefaultMerit.Mute:
                return result;
            case DefaultMerit.ThinBlood:
                return result;
            case DefaultMerit.DiseaseCarrier:
                return result;
            case DefaultMerit.Deaf:
                result.MeritDifficultyEffect = +3;
                return result;
            case DefaultMerit.FleshOfTheCorpse:
                return result;
            case DefaultMerit.Blind:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.CommonSense:
                return result;
            case DefaultMerit.Concentration:
                return result;
            case DefaultMerit.TimeSense:
                return result;
            case DefaultMerit.CodeOfHonor:
                result.MeritDicepoolEffect = +2;
                return result;
            case DefaultMerit.EideticMemory:
                return result;
            case DefaultMerit.LightSleeper:
                return result;
            case DefaultMerit.NaturalLenguist:
                result.MeritDicepoolEffect = +3;
                return result;
            case DefaultMerit.CalmHeart:
                result.MeritDicepoolEffect = +2;
                return result;
            case DefaultMerit.IronWill:
                result.MeritDicepoolEffect = +3;
                return result;
            case DefaultMerit.DeepSleeper:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.Nightmares:
                result.MeritDicepoolEffect = -1;
                return result;
            case DefaultMerit.Phobia:
                return result;
            case DefaultMerit.PreyExclusion:
                return result;
            case DefaultMerit.Shy:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.SoftHearted:
                return result;
            case DefaultMerit.SpeechImpediment:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.ShortFuse:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.Territorial:
                return result;
            case DefaultMerit.Vengefil:
                return result;
            case DefaultMerit.Amnesia:
                return result;
            case DefaultMerit.Lunacy:
                return result;
            case DefaultMerit.WeakWilled:
                return result;
            case DefaultMerit.ConspicuousConsumption:
                return result;
            case DefaultMerit.PrestigiousSire:
                return result;
            case DefaultMerit.NaturalLeader:
                result.MeritDicepoolEffect = +2;
                return result;
            case DefaultMerit.DebtOfGratitude:
                return result;
            case DefaultMerit.DarkSecret:
                return result;
            case DefaultMerit.InfamousSire:
                return result;
            case DefaultMerit.MistakenIdentity:
                return result;
            case DefaultMerit.SireResentiment:
                return result;
            case DefaultMerit.Enemy:
                return result;
            case DefaultMerit.Hunted:
                return result;
            case DefaultMerit.ProbationarySectMember:
                return result;
            case DefaultMerit.Medium:
                return result;
            case DefaultMerit.MagicResistance:
                return result;
            case DefaultMerit.OracularAbility:
                return result;
            case DefaultMerit.SpiritMentor:
                return result;
            case DefaultMerit.Unbondable:
                return result;
            case DefaultMerit.Lucky:
                return result;
            case DefaultMerit.TrueLove:
                return result;
            case DefaultMerit.NineLives:
                return result;
            case DefaultMerit.TrueFaith:
                return result;
            case DefaultMerit.TouchOfFrost:
                return result;
            case DefaultMerit.RepulsedByGarlic:
                return result;
            case DefaultMerit.Cursed:
                return result;
            case DefaultMerit.CastNoReflection:
                return result;
            case DefaultMerit.EeriePresence:
                result.MeritDifficultyEffect = +2;
                return result;
            case DefaultMerit.RepelledByCrosses:
                return result;
            case DefaultMerit.CantCrossRunningWater:
                return result;
            case DefaultMerit.Haunted:
                return result;
            case DefaultMerit.GripOfTheDamned:
                return result;
            case DefaultMerit.DarkFate:
                result.MeritDicepoolEffect = -1;
                return result;
            case DefaultMerit.LightSensitive:
                return result;
            default:
                return result;
        }
    }
}
