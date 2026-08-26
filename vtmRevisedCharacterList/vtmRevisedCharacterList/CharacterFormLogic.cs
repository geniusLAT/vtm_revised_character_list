using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using vtmRevisedCharacterList.AddFormHelper;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class CharacterForm : Form
{
    private static readonly HttpClientHandler handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    };
    private HttpClient? _httpClient;

    GuiConfig? _config;

    List<CharacterListMember> _avaliableCharacters = new List<CharacterListMember>();

    AttributeVtm? _chosenAttribute;

    Ability? _chosenAbility;

    OtherRollable? _otherRollable;

    RatingGuiPanel? _chosenRatingGuiPanel;

    Character? _chosenCharacter;

    private bool _unsavedChangesExist = false;

    #region diceRolling

    int _dicesToRoll = 0;

    uint _extraDicePool = 0;

    uint _debuffDicePool = 0;

    uint _difficulty = 6;

    uint _additionalAutoSuccess = 0;

    bool _daredevil = false;

    bool _specialization = false;

    bool _ignoreHealthCondition = false;

    string _rollComment = string.Empty;

    #endregion

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

    #region Abilities
    #region Talents
    RadioButton[] AlertnessButtons = [];
    RadioButton[] AthleticsButtons = [];
    RadioButton[] BrawlButtons = [];
    RadioButton[] DodgeButtons = [];
    RadioButton[] EmpathyButtons = [];
    RadioButton[] ExpressionButtons = [];
    RadioButton[] IntimidationButtons = [];
    RadioButton[] LeadershipButtons = [];
    RadioButton[] StreetwiseButtons = [];
    RadioButton[] SubterfugeButtons = [];
    #endregion

    #region Skills
    RadioButton[] AnimalKenButtons = [];
    RadioButton[] CraftsButtons = [];
    RadioButton[] DriveButtons = [];
    RadioButton[] EtiquetteButtons = [];
    RadioButton[] FirearmsButtons = [];
    RadioButton[] MeleeButtons = [];
    RadioButton[] PerfomanceButtons = [];
    RadioButton[] SecurityButtons = [];
    RadioButton[] StealthButtons = [];
    RadioButton[] SurvivalButtons = [];
    #endregion

    #region Knowledges
    RadioButton[] AcademicsButtons = [];
    RadioButton[] ComputerButtons = [];
    RadioButton[] FinanceButtons = [];
    RadioButton[] InvestigationButtons = [];
    RadioButton[] LawButtons = [];
    RadioButton[] LinguisticsButtons = [];
    RadioButton[] MedicineButtons = [];
    RadioButton[] OccultButtons = [];
    RadioButton[] PoliticsButtons = [];
    RadioButton[] ScienceButtons = [];
    #endregion
    #endregion

    #region OtherButtons
    RadioButton[] HumanityPathButtons = [];
    RadioButton[] ConstWillpowerButtons = [];
    RadioButton[] TempWillpowerButtons = [];
    RadioButton[] ConscienceConvictionButtons = [];
    RadioButton[] SelfControlInstinctButtons = [];
    RadioButton[] CourageButtons = [];

    RadioButton[] HealthButtons = [];
    RadioButton[] BloodpoolButtons = [];
    #endregion

    #endregion

    #region abstractRatingPanels

    internal List<RatingGuiPanel> ratingGuiPanels = new List<RatingGuiPanel>();

    internal List<MeritGuiPanel> meritGuiPanels = new List<MeritGuiPanel>();

    #endregion

    void FindButtonsForOthers()
    {
        BloodpoolButtons = [BloodpoolButton1, BloodpoolButton2, BloodpoolButton3, BloodpoolButton4, BloodpoolButton5,
        BloodpoolButton6, BloodpoolButton7, BloodpoolButton8, BloodpoolButton9, BloodpoolButton10, BloodpoolButton11,
        BloodpoolButton12, BloodpoolButton13, BloodpoolButton14, BloodpoolButton15, BloodpoolButton16, BloodpoolButton17,
        BloodpoolButton18, BloodpoolButton19, BloodpoolButton20];

        HumanityPathButtons = [HumanityPathButton1, HumanityPathButton2, HumanityPathButton3, HumanityPathButton4, HumanityPathButton5,
        HumanityPathButton6, HumanityPathButton7, HumanityPathButton8, HumanityPathButton9, HumanityPathButton10];
        ConstWillpowerButtons = [constWillpowerButton1, constWillpowerButton2, constWillpowerButton3, constWillpowerButton4, constWillpowerButton5,
        constWillpowerButton6, constWillpowerButton7, constWillpowerButton8, constWillpowerButton9, constWillpowerButton10];
        TempWillpowerButtons = [TempWillpowerButton1, TempWillpowerButton2, TempWillpowerButton3, TempWillpowerButton4, TempWillpowerButton5,
        TempWillpowerButton6, TempWillpowerButton7, TempWillpowerButton8, TempWillpowerButton9, TempWillpowerButton10];

        ConscienceConvictionButtons = [ConscienceConvictionButton1, ConscienceConvictionButton2, ConscienceConvictionButton3, ConscienceConvictionButton4, ConscienceConvictionButton5];
        SelfControlInstinctButtons = [SelfControlInstinctButton1, SelfControlInstinctButton2, SelfControlInstinctButton3, SelfControlInstinctButton4, SelfControlInstinctButton5];
        CourageButtons = [CourageButton1, CourageButton2, CourageButton3, CourageButton4, CourageButton5];

        HealthButtons = [HealthButton1, HealthButton2, HealthButton3, HealthButton4, HealthButton5,
        HealthButton6, HealthButton7, HealthButton8, HealthButton9];
    }

    void FindButtonsForAttributes()
    {
        StrenghtButtons = [SButton, SButton2, SButton3, SButton4, SButton5];
        DexterityButtons = [DexterityButton1, DexterityButton2, DexterityButton3, DexterityButton4, DexterityButton5];
        StaminaButtons = [StaminaButton1, StaminaButton2, StaminaButton3, StaminaButton4, StaminaButton5];
        CharismaButtons = [CharismaButton1, CharismaButton2, CharismaButton3, CharismaButton4, CharismaButton5];
        ManipulationButtons = [ManupulationButton1, ManupulationButton2, ManupulationButton3, ManupulationButton4, ManupulationButton5];
        AppearanceButtons = [AppearanceButton1, AppearanceButton2, AppearanceButton3, AppearanceButton4, AppearanceButton5];
        PerceptionButtons = [PerceptionButton1, PerceptionButton2, PerceptionButton3, PerceptionButton4, PerceptionButton5];
        IntelligeceButtons = [IntelligeceButton1, IntelligeceButton2, IntelligeceButton3, IntelligeceButton4, IntelligeceButton5];
        WitsButtons = [WitsButton1, WitsButton2, WitsButton3, WitsButton4, WitsButton5];
    }

    void FindButtonsForAbilities()
    {
        // Talents
        AlertnessButtons = [AlertnessButton1, AlertnessButton2, AlertnessButton3, AlertnessButton4, AlertnessButton5];
        AthleticsButtons = [AthleticsButton1, AthleticsButton2, AthleticsButton3, AthleticsButton4, AthleticsButton5];
        BrawlButtons = [BrawlButton1, BrawlButton2, BrawlButton3, BrawlButton4, BrawlButton5];
        DodgeButtons = [DodgeButton1, DodgeButton2, DodgeButton3, DodgeButton4, DodgeButton5];
        EmpathyButtons = [EmpathyButton1, EmpathyButton2, EmpathyButton3, EmpathyButton4, EmpathyButton5];
        ExpressionButtons = [ExpressionButton1, ExpressionButton2, ExpressionButton3, ExpressionButton4, ExpressionButton5];
        IntimidationButtons = [IntimidationButton1, IntimidationButton2, IntimidationButton3, IntimidationButton4, IntimidationButton5];
        LeadershipButtons = [LeadershipButton1, LeadershipButton2, LeadershipButton3, LeadershipButton4, LeadershipButton5];
        StreetwiseButtons = [StreetwiseButton1, StreetwiseButton2, StreetwiseButton3, StreetwiseButton4, StreetwiseButton5];
        SubterfugeButtons = [SubterfugeButton1, SubterfugeButton2, SubterfugeButton3, SubterfugeButton4, SubterfugeButton5];

        // Skills
        AnimalKenButtons = [AnimalKenButton1, AnimalKenButton2, AnimalKenButton3, AnimalKenButton4, AnimalKenButton5];
        CraftsButtons = [CraftsButton1, CraftsButton2, CraftsButton3, CraftsButton4, CraftsButton5];
        DriveButtons = [DriveButton1, DriveButton2, DriveButton3, DriveButton4, DriveButton5];
        EtiquetteButtons = [EtiquetteButton1, EtiquetteButton2, EtiquetteButton3, EtiquetteButton4, EtiquetteButton5];
        FirearmsButtons = [FirearmsButton1, FirearmsButton2, FirearmsButton3, FirearmsButton4, FirearmsButton5];
        MeleeButtons = [MeleeButton1, MeleeButton2, MeleeButton3, MeleeButton4, MeleeButton5];
        PerfomanceButtons = [PerfomanceButton1, PerfomanceButton2, PerfomanceButton3, PerfomanceButton4, PerfomanceButton5];
        SecurityButtons = [SecurityButton1, SecurityButton2, SecurityButton3, SecurityButton4, SecurityButton5];
        StealthButtons = [StealthButton1, StealthButton2, StealthButton3, StealthButton4, StealthButton5];
        SurvivalButtons = [SurvivalButton1, SurvivalButton2, SurvivalButton3, SurvivalButton4, SurvivalButton5];

        // Knowledges
        AcademicsButtons = [AcademicsButton1, AcademicsButton2, AcademicsButton3, AcademicsButton4, AcademicsButton5];
        ComputerButtons = [ComputerButton1, ComputerButton2, ComputerButton3, ComputerButton4, ComputerButton5];
        FinanceButtons = [FinanceButton1, FinanceButton2, FinanceButton3, FinanceButton4, FinanceButton5];
        InvestigationButtons = [InvestigationButton1, InvestigationButton2, InvestigationButton3, InvestigationButton4, InvestigationButton5];
        LawButtons = [LawButton1, LawButton2, LawButton3, LawButton4, LawButton5];
        LinguisticsButtons = [LinguisticsButton1, LinguisticsButton2, LinguisticsButton3, LinguisticsButton4, LinguisticsButton5];
        MedicineButtons = [MedicineButton1, MedicineButton2, MedicineButton3, MedicineButton4, MedicineButton5];
        OccultButtons = [OccultButton1, OccultButton2, OccultButton3, OccultButton4, OccultButton5];
        PoliticsButtons = [PoliticsButton1, PoliticsButton2, PoliticsButton3, PoliticsButton4, PoliticsButton5];
        ScienceButtons = [ScienceButton1, ScienceButton2, ScienceButton3, ScienceButton4, ScienceButton5];
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

    void ClearAbilityChoice()
    {
        _chosenAbility = null;
        for (int i = 0; i < 30; i++)
        {
            Ability ability = (Ability)i;
            var panel = GetAbilityPanel(ability);
            if (panel != null)
            {
                panel.BackColor = Color.White;
            }
        }
    }

    void ClearRatingPanelChoice()
    {
        _chosenRatingGuiPanel = null;
        foreach (var ratingPanel in ratingGuiPanels)
        {
            ratingPanel.Panel.BackColor = Color.White;
        }
    }

    void ClearOtherRollableChoice()
    {
        _otherRollable = null;
        for (int i = 0; i < 7; i++)
        {
            OtherRollable rollable = (OtherRollable)i;
            var panel = GetOtherRollablePanel(rollable);
            if (panel != null)
            {
                panel.BackColor = Color.White;
            }
        }
    }

    void SetButtonsForNum(RadioButton[] buttons, uint numToSet)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < numToSet)
            {
                buttons[i].Checked = true;
            }
            else
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

    Panel? GetOtherRollablePanel(OtherRollable? rollable)
    {
        switch (rollable)
        {
            case OtherRollable.ConstWillpower:
                return ConstWillpowerPanel;
            case OtherRollable.TempWillpower:
                return TempWillpowerPanel;
            case OtherRollable.ConscienceConviction:
                return ConscienceConvictionPanel;
            case OtherRollable.SelfControlInstinct:
                return SelfControlInstinctPanel;
            case OtherRollable.Courage:
                return CouragePanel;
            case OtherRollable.HumanityPath:
                return HumanityPathPanel;
            case OtherRollable.Bloodpool:
                return BloodpoolPanel;
            case null:
            default:
                return null;
        }
    }

    Panel? GetAbilityPanel(Ability? ability)
    {
        switch (ability)
        {
            case Ability.Alertness:
                return AlertnessPanel;
            case Ability.Athletics:
                return AthleticsPanel;
            case Ability.Brawl:
                return BrawlPanel;
            case Ability.Dodge:
                return DodgePanel;
            case Ability.Empathy:
                return EmpathyPanel;
            case Ability.Expression:
                return ExpressionPanel;
            case Ability.Intimidation:
                return IntimidationPanel;
            case Ability.Leadership:
                return LeadershipPanel;
            case Ability.Streetwise:
                return StreetwisePanel;
            case Ability.Subterfuge:
                return SubterfugePanel;
            case Ability.AnimalKen:
                return AnimalKenPanel;
            case Ability.Crafts:
                return CraftsPanel;
            case Ability.Drive:
                return DrivePanel;
            case Ability.Etiquette:
                return EtiquettePanel;
            case Ability.Firearms:
                return FirearmsPanel;
            case Ability.Melee:
                return MeleePanel;
            case Ability.Perfomance:
                return PerfomancePanel;
            case Ability.Security:
                return SecurityPanel;
            case Ability.Stealth:
                return StealthPanel;
            case Ability.Survival:
                return SurvivalPanel;
            case Ability.Academics:
                return AcademicsPanel;
            case Ability.Computer:
                return ComputerPanel;
            case Ability.Finance:
                return FinancePanel;
            case Ability.Investigation:
                return InvestigationPanel;
            case Ability.Law:
                return LawPanel;
            case Ability.Linguistics:
                return LinguisticsPanel;
            case Ability.Medicine:
                return MedicinePanel;
            case Ability.Occult:
                return OccultPanel;
            case Ability.Politics:
                return PoliticsPanel;
            case Ability.Science:
                return SciencePanel;
            case null:
            default:
                return null;
        }
    }

    RadioButton[]? GetOtherButtons(OtherRollable? other) => other switch
    {
        OtherRollable.ConstWillpower => ConstWillpowerButtons,
        OtherRollable.TempWillpower => TempWillpowerButtons,
        OtherRollable.ConscienceConviction => ConscienceConvictionButtons,
        OtherRollable.SelfControlInstinct => SelfControlInstinctButtons,
        OtherRollable.Courage => CourageButtons,
        null => throw new NotImplementedException(),
        OtherRollable.HumanityPath => HumanityPathButtons,
        OtherRollable.Bloodpool => BloodpoolButtons,
        _ => null
    };

    RadioButton[]? GetAttributeButtons(AttributeVtm? attribute) => attribute switch
    {
        AttributeVtm.Strenght => StrenghtButtons,
        AttributeVtm.Dexterity => DexterityButtons,
        AttributeVtm.Stamina => StaminaButtons,
        AttributeVtm.Charisma => CharismaButtons,
        AttributeVtm.Manipulation => ManipulationButtons,
        AttributeVtm.Appearance => AppearanceButtons,
        AttributeVtm.Perception => PerceptionButtons,
        AttributeVtm.Intelligance => IntelligeceButtons,
        AttributeVtm.Wits => WitsButtons,
        _ => null
    };

    RadioButton[]? GetAbilityButtons(Ability? ability) => ability switch
    {
        Ability.Alertness => AlertnessButtons,
        Ability.Athletics => AthleticsButtons,
        Ability.Brawl => BrawlButtons,
        Ability.Dodge => DodgeButtons,
        Ability.Empathy => EmpathyButtons,
        Ability.Expression => ExpressionButtons,
        Ability.Intimidation => IntimidationButtons,
        Ability.Leadership => LeadershipButtons,
        Ability.Streetwise => StreetwiseButtons,
        Ability.Subterfuge => SubterfugeButtons,
        Ability.AnimalKen => AnimalKenButtons,
        Ability.Crafts => CraftsButtons,
        Ability.Drive => DriveButtons,
        Ability.Etiquette => EtiquetteButtons,
        Ability.Firearms => FirearmsButtons,
        Ability.Melee => MeleeButtons,
        Ability.Perfomance => PerfomanceButtons,
        Ability.Security => SecurityButtons,
        Ability.Stealth => StealthButtons,
        Ability.Survival => SurvivalButtons,
        Ability.Academics => AcademicsButtons,
        Ability.Computer => ComputerButtons,
        Ability.Finance => FinanceButtons,
        Ability.Investigation => InvestigationButtons,
        Ability.Law => LawButtons,
        Ability.Linguistics => LinguisticsButtons,
        Ability.Medicine => MedicineButtons,
        Ability.Occult => OccultButtons,
        Ability.Politics => PoliticsButtons,
        Ability.Science => ScienceButtons,
        _ => null
    };

    NumericUpDown? GetOtherNumeric(OtherRollable? other)
    {
        switch (other)
        {
            case OtherRollable.ConstWillpower:
                return ConstWillpowerNumeric;
            case OtherRollable.TempWillpower:
                return TempWillpowerNumeric;
            case OtherRollable.ConscienceConviction:
                return ConscienceConvictionNumeric;
            case OtherRollable.SelfControlInstinct:
                return SelfControlInstinctNumeric;
            case OtherRollable.Courage:
                return CourageNumeric;
            case OtherRollable.HumanityPath:
                return HumanityPathNumeric;
            case OtherRollable.Bloodpool:
                return BloodpoolNumeric;
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

    NumericUpDown? GetAbilityNumeric(Ability? ability)
    {
        switch (ability)
        {
            case Ability.Alertness:
                return AlertnessNumeric;
            case Ability.Athletics:
                return AthleticsNumeric;
            case Ability.Brawl:
                return BrawlNumeric;
            case Ability.Dodge:
                return DodgeNumeric;
            case Ability.Empathy:
                return EmpathyNumeric;
            case Ability.Expression:
                return ExpressionNumeric;
            case Ability.Intimidation:
                return IntimidationNumeric;
            case Ability.Leadership:
                return LeadershipNumeric;
            case Ability.Streetwise:
                return StreetwiseNumeric;
            case Ability.Subterfuge:
                return SubterfugeNumeric;
            case Ability.AnimalKen:
                return AnimalKenNumeric;
            case Ability.Crafts:
                return CraftsNumeric;
            case Ability.Drive:
                return DriveNumeric;
            case Ability.Etiquette:
                return EtiquetteNumeric;
            case Ability.Firearms:
                return FirearmsNumeric;
            case Ability.Melee:
                return MeleeNumeric;
            case Ability.Perfomance:
                return PerfomanceNumeric;
            case Ability.Security:
                return SecurityNumeric;
            case Ability.Stealth:
                return StealthNumeric;
            case Ability.Survival:
                return SurvivalNumeric;
            case Ability.Academics:
                return AcademicsNumeric;
            case Ability.Computer:
                return ComputerNumeric;
            case Ability.Finance:
                return FinanceNumeric;
            case Ability.Investigation:
                return InvestigationNumeric;
            case Ability.Law:
                return LawNumeric;
            case Ability.Linguistics:
                return LinguisticsNumeric;
            case Ability.Medicine:
                return MedicineNumeric;
            case Ability.Occult:
                return OccultNumeric;
            case Ability.Politics:
                return PoliticsNumeric;
            case Ability.Science:
                return ScienceNumeric;
            case null:
            default:
                return null;
        }
    }

    void ChooseAttribute(AttributeVtm attribute)
    {
        _chosenAttribute = attribute;
        _otherRollable = null;
        ClearAttributeChoice();
        ClearOtherRollableChoice();
        var panel = GetAttributePanel(_chosenAttribute);
        if (panel != null)
        {
            panel.BackColor = Color.Yellow;
        }
        CalculateDices();
    }

    void ChooseOther(OtherRollable rollable)
    {
        _chosenAbility = null;
        _chosenAttribute = null;
        ClearAbilityChoice();
        ClearAttributeChoice();

        ClearOtherRollableChoice();
        ClearRatingPanelChoice();

        _otherRollable = rollable;
        var panel = GetOtherRollablePanel(_otherRollable);
        if (panel != null)
        {
            panel.BackColor = Color.Yellow;
        }
        CalculateDices();
    }

    void ChooseAbility(Ability ability)
    {
       
        _otherRollable = null;
        ClearAbilityChoice();
        ClearOtherRollableChoice();
        ClearRatingPanelChoice();

        _chosenAbility = ability;
        var panel = GetAbilityPanel(_chosenAbility);
        if (panel != null)
        {
            panel.BackColor = Color.Yellow;
        }
        CalculateDices();
    }

    void CalculateDices()
    {
        _dicesToRoll = 0;
        StringBuilder sb = new StringBuilder();

        if (_otherRollable != null)
        {
            var other = _chosenCharacter?.GetOther((OtherRollable)_otherRollable) ?? 0;
            _dicesToRoll += (int)other;
            sb.Append($" {RussianTranslator.TranslateOther(_otherRollable)} {other.ToString()}");
        }

        if (_chosenAttribute != null)
        {
            var attribute = _chosenCharacter?.GetAttribute((AttributeVtm)_chosenAttribute) ?? 0;
            _dicesToRoll += (int)attribute;
            sb.Append($" {RussianTranslator.TranslateAttribute(_chosenAttribute)} {attribute.ToString()}");
        }
        if (_chosenAbility != null)
        {
            var ability = _chosenCharacter?.GetAbility((Ability)_chosenAbility) ?? 0;
            _dicesToRoll += (int)ability;
            if (sb.Length > 0)
            {
                sb.Append(" + ");
            }
            sb.Append($" {RussianTranslator.TranslateAbility(_chosenAbility)} {ability.ToString()}");

        }

        if (_chosenRatingGuiPanel != null)
        {
            var rating = _chosenRatingGuiPanel.rating.Rating;
            _dicesToRoll += (int)rating;
            if (sb.Length > 0)
            {
                sb.Append(" + ");
            }
            sb.Append($" {_chosenRatingGuiPanel.rating.Name} {rating.ToString()}");

        }

        if (_extraDicePool > 0)
        {
            _dicesToRoll += (int)_extraDicePool;
            if (sb.Length > 0)
            {
                sb.Append(" + ");
            }
            sb.Append($" доп кубы {_extraDicePool.ToString()}");

        }

        if (_debuffDicePool > 0)
        {
            _dicesToRoll -= (int)_debuffDicePool;
            sb.Append($" - штрафные кубы {_debuffDicePool.ToString()}");

        }

        if (!_ignoreHealthCondition)
        {
            var healthCondition = _chosenCharacter.GetHealthCondition();
            var healthConditionDebuff = 0;
            switch (healthCondition)
            {
                case HealthCondition.Ok:
                    break;
                case HealthCondition.BruisedBonused:
                    break;
                case HealthCondition.Bruised:
                    break;
                case HealthCondition.Hurt:
                    healthConditionDebuff = 1;
                    break;
                case HealthCondition.Injured:
                    healthConditionDebuff = 1;
                    break;
                case HealthCondition.Wounded:
                    healthConditionDebuff = 2;
                    break;
                case HealthCondition.Mauled:
                    healthConditionDebuff = 2;
                    break;
                case HealthCondition.Crippled:
                    healthConditionDebuff = 5;
                    break;
                case HealthCondition.Incapacitated:
                    healthConditionDebuff = 9999;
                    break;
                case HealthCondition.Dead:
                    healthConditionDebuff = 9999;
                    break;
            }

            _dicesToRoll -= (int)healthConditionDebuff;
            if (healthConditionDebuff > 0)
            {
                sb.Append($" - {RussianTranslator.TranslateHealthCondition(healthCondition)} {healthConditionDebuff.ToString()}");
            }
        }

        sb.Append($" = {_dicesToRoll}");
        var name = _chosenCharacter?.CharacterName ?? "Кто-то";
        var daredevilCommentary = _daredevil ? ",сорвиголова " : string.Empty;
        var specializationCommentary = _specialization ? ",специализация " : string.Empty;
        var autoSuccessCommentary = _additionalAutoSuccess > 0 ? $", {_additionalAutoSuccess} автоуспехов" : string.Empty;
        _rollComment = DiceLabel.Text = $"{name} {sb.ToString()} СЛ {_difficulty}{daredevilCommentary}{specializationCommentary}{autoSuccessCommentary}\n";
    }

    void RenderHealthCondition(Character character)
    {
        var bonusHealth = character.BonusHealth();

        HealthLabel1.Visible = HealthButton1.Visible = bonusHealth;

        for (int i = 0; i < 9; i++)
        {
            var currentButton = HealthButtons[i];
            if (character.Damage + (bonusHealth ? 0 : 1) > i)
            {
                currentButton.Checked = true;
            }
            else
            {
                currentButton.Checked = false;
            }
        }
    }
    public void RenderCharacter()
    {
        RenderCharacter(_chosenCharacter);
    }

    public void RenderCharacter(Character character)
    {
        _chosenCharacter = character;

        characterNameLabel.Text = character.CharacterName ?? "Новый персонаж";

        AggravatedDamageNumeric.Value = character.AggravatedDamage;
        AggravatedDamageNumeric.ValueChanged += CharacterNumeric_ValueChanged;
        CommonDamageNumeric.Value = character.CommonDamage;
        CommonDamageNumeric.ValueChanged += CharacterNumeric_ValueChanged;

        RenderHealthCondition(character);

        for (int i = 0; i < 9; i++)
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

            SetButtonsForNum(GetAttributeButtons(attribute), attributeValue);

        }

        for (int i = 0; i < 30; i++)
        {
            Ability ability = (Ability)i;
            uint abilityValue = character.GetAbility(ability);
            var numeric = GetAbilityNumeric(ability);
            if (numeric is not null)
            {
                numeric.Value = abilityValue;
                numeric.Enabled = true;
                numeric.ValueChanged += CharacterNumeric_ValueChanged;
            }
            SetButtonsForNum(GetAbilityButtons(ability), abilityValue);

        }

        for (int i = 0; i < 7; i++)
        {
            OtherRollable other = (OtherRollable)i;
            uint otherValue = character.GetOther(other);
            var numeric = GetOtherNumeric(other);
            if (numeric is not null)
            {
                numeric.Value = otherValue;
                numeric.Enabled = true;
                numeric.ValueChanged += CharacterNumeric_ValueChanged;
            }
            var buttons = GetOtherButtons(other);
            if (buttons is not null)
            {
                SetButtonsForNum(buttons, otherValue);
            }
            else
            {
                MessageBox.Show($"{other} {i}");
            }
        }

        ratingGuiPanels.Clear();
        RenderBackGrounds();
        RenderDisciplines();
        RenderMerits();

        MarkCharacterAsSaved();


        CalculateDices();

    }


    public async Task RollDiceAsync()
    {
        uint positiveDicesToRoll = _dicesToRoll < 0 ? 0 : (uint)_dicesToRoll;
        DicesRollRequest request = new DicesRollRequest()
        {
            AutoSuccesses = _additionalAutoSuccess,
            DicesToRoll = positiveDicesToRoll,
            Difficulty = _difficulty,
            Specialization = _specialization,
            RemoveCriticalFailure = (uint)(_daredevil ? 1 : 0),
            Comment = _rollComment
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("Dice", request);
            response.EnsureSuccessStatusCode();

            DicesRollRequest? responseRequest = await response.Content.ReadFromJsonAsync<DicesRollRequest>();

            if (responseRequest != null)
            {
                var result = responseRequest.RollResult;

                logLabel.Text += responseRequest.Comment + result.ToString() + '\n';
                ScrollLogToBottom();
            }
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка сети или сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ScrollLogToBottom()
    {
        LogPanel.PerformLayout();
        LogPanel.AutoScrollPosition = new Point(0, LogPanel.DisplayRectangle.Height);
    }

    private async Task ChooseAnotherCharacter(int characterIndex)
    {
        if (_config is null)
        {
            MessageBox.Show($"Ты куда его дел?", "А где config?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
            return;
        }

        var newCharacter = await GetCharacterAsync(_avaliableCharacters[characterIndex], _config.UserId);

        if (newCharacter is null)
        {
            MessageBox.Show($"А персонажа то как можно было потерять?", "Не знаю, что ты сделал - но больше так не делай...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        _chosenCharacter = newCharacter;
        RenderCharacter(_chosenCharacter);

        //_avaliableCharacters = await GetCharacterListAsync(_config.UserId);
    }

    #region firstInit

    public void StartIt()
    {
        _config = GetConfig();
        if (_config is null)
        {
            MessageBox.Show($"Ты куда его дел?", "А где config?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
            return;
        }
        UsernameLabel.Text = $"Игрок:{_config.UserName}";

        _httpClient = new HttpClient(handler)
        {
            //BaseAddress = new Uri("https://localhost:44320/")
            BaseAddress = new Uri(_config.Path)
        };

        var task = Task.Run(() => GetCharacterListAsync(_config.UserId));

        //while server thinks
        ClearAttributeChoice();
        ClearAbilityChoice();
        FindButtonsForAttributes();
        FindButtonsForAbilities();
        FindButtonsForOthers();

        task.Wait();

        _avaliableCharacters = task.Result;
        MessageBox.Show($"Найдено персонажей: {_avaliableCharacters.Count.ToString()}");

        if (_avaliableCharacters.Count > 0)
        {
            var task2 = Task.Run(() => GetCharacterAsync(_avaliableCharacters.First(), _config.UserId));

            //while server thinks
            characterComboBox.Items.Clear();
            foreach (var character in _avaliableCharacters)
            {
                characterComboBox.Items.Add(character.CharacterName);
            }
            characterComboBox.SelectedIndex = 0;
            task2.Wait();

            _chosenCharacter = task2.Result;
            RenderCharacter(_chosenCharacter);
        }

        //var character = new Character()
        //{
        //    CharacterName = "Марвин",

        //    Strenght = 1,
        //    Dexterity = 2,
        //    Stamina = 3,

        //    Charisma = 4,
        //    Manipulation = 5,
        //    Appearance = 1,
        //    Perception = 2,
        //    Intellegence = 3,
        //    Wits = 4,


        //    Drive = 5,
        //    Intimidation = 1,
        //    Firearms = 2,

        //    WillpowerMax = 7,
        //    Willpower = 2,

        //    ConscienceConviction = 3,
        //    SelfControlInstincts = 1,
        //    Courage = 5,
        //};
        //RenderCharacter(character);
    }

    public static GuiConfig? GetConfig()
    {
        string filePath = "config";

        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string content = File.ReadAllText(filePath);

            GuiConfig adminGuid = JsonSerializer.Deserialize<GuiConfig>(content);

            return adminGuid;
        }
        catch (Exception)
        {

            return null;
        }
    }

    public async Task<List<CharacterListMember>> GetCharacterListAsync(Guid userId)
    {
        CharacterListRequest request = new()
        {
            UserUuid = userId
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("/Character/GetCharacterList", request);
            response.EnsureSuccessStatusCode();

            var responseRequest = await response.Content.ReadFromJsonAsync<List<CharacterListMember>>();

            return responseRequest.ToList();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка сети или сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return [];
    }

    public async Task<Character?> GetCharacterAsync(CharacterListMember characterToRequest, Guid userId)
    {
        CharacterRequest request = new()
        {
            UserUuid = userId,
            CharacterUuid = characterToRequest.CharacterUuid
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("/Character/GetCharacter", request);
            response.EnsureSuccessStatusCode();

            var responseRequest = await response.Content.ReadFromJsonAsync<Character>();

            return responseRequest;
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка сети или сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        MessageBox.Show($"Какая-то шляпа на этапе серализации", "Как это вообще случилось?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return null;
    }

    #endregion

    #region UpdatingCharacter

    public void CancelUpdating()
    {
        RenderCharacter(_chosenCharacter);
    }

    public void MarkUnsavedChanges()
    {
        SetUnsavedStatus(true);
    }

    public void MarkCharacterAsSaved()
    {
        SetUnsavedStatus(false);
    }

    public void SetUnsavedStatus(bool unsavedChangesExist)
    {
        _unsavedChangesExist = unsavedChangesExist;

        AddBackgroundButton.Enabled 
            = AddDisciplineButton.Enabled 
            = RollDiceButton.Enabled 
            = !unsavedChangesExist;
        CancelUpdateButton.Enabled
            = CancelUpdateButton.Visible
            = UpdateCharacterButton.Enabled
            = UpdateCharacterButton.Visible
            = unsavedChangesExist;
    }

    public void UpdateCharacter()
    {
        var characterGuid = _avaliableCharacters[characterComboBox.SelectedIndex].CharacterUuid;

        var newCharacter = GenerateChangedCharacter();
        CharacterUpdateRequest request = new()
        {
            CharacterToUpdate = newCharacter,
            CharacterUuid = characterGuid,
            UserUuid = _config.UserId,
            Hidden = false
        };
        var task = Task.Run(() => UpdateCharacterAsync(request));
        task.Wait();
        _chosenCharacter = newCharacter;

        logLabel.Text += task.Result.ChangeLog + '\n';
        ScrollLogToBottom();

        RenderCharacter(_chosenCharacter);
    }

    public async Task<CharacterUpdateResult?> UpdateCharacterAsync(CharacterUpdateRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/Character/UpdateCharacter", request);
            response.EnsureSuccessStatusCode();

            var responseRequest = await response.Content.ReadFromJsonAsync<CharacterUpdateResult>();

            return responseRequest;
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ошибка сети или сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        MessageBox.Show($"Какая-то шляпа на этапе серализации", "Как это вообще случилось?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return null;
    }

    public Character GenerateChangedCharacter()
    {
        Character character = JsonSerializer.Deserialize<Character>(JsonSerializer.Serialize(_chosenCharacter));

        character.CommonDamage = (uint)CommonDamageNumeric.Value;
        character.AggravatedDamage = (uint)AggravatedDamageNumeric.Value;

        for (int i = 0; i < 9; i++)
        {
            AttributeVtm attribute = (AttributeVtm)i;

            var numeric = GetAttributeNumeric(attribute);
            if (numeric is not null)
            {
                uint attributeValue = character.SetAttribute(attribute, (uint)numeric.Value);
            }
        }

        for (int i = 0; i < 30; i++)
        {
            Ability ability = (Ability)i;

            var numeric = GetAbilityNumeric(ability);
            if (numeric is not null)
            {
                uint abilityValue = character.SetAbility(ability, (uint)numeric.Value);
            }
        }

        for (int i = 0; i < 7; i++)
        {
            OtherRollable other = (OtherRollable)i;

            var numeric = GetOtherNumeric(other);

            if (numeric is not null)
            {
                uint otherValue = character.SetOther(other, (uint)numeric.Value);
            }
        }

        foreach (var ratingPanel in ratingGuiPanels)
        {
            if (ratingPanel.Numeric.Value != ratingPanel.rating.Rating)
            {
                character.SetRating(new RatingDto()
                {
                    Name = ratingPanel.rating.Name,
                    Rating = (uint)ratingPanel.Numeric.Value,
                }
                    );
            }
        }

        //MessageBox.Show(ChangeLogGenerator.GenerateChangeLog(_chosenCharacter, character));

        return character;
    }

    #endregion

    #region abstractCollectionGuiManagment

    void ClickOnNumericOnRatingPanel(object sender)
    {
        MarkUnsavedChanges();
    }

    void ClickOnRatingPanel(object sender)
    {
        var ratingPanel = ratingGuiPanels.Where(panel => panel.Label == sender || panel.Panel == sender).FirstOrDefault();

        ClearRatingPanelChoice();
        ClearOtherRollableChoice();
        ClearAbilityChoice();

        _chosenRatingGuiPanel = ratingPanel;
        ratingPanel.Panel.BackColor = Color.Yellow;

        CalculateDices();
    }

    void RenderCollectionGui(Panel parentPanel, List<ARating> collection)
    {
        parentPanel.Controls.Clear();

        for (int i = 0; i < collection.Count; i++)
        {
            ARating? item = collection[i];
            var littlePanel = new Panel()
            { 
                Width =207,//227
                Height = 19,
                //BackColor = Color.Green,
                Location = new Point(3, 3 + i * 20)
            };
            littlePanel.Click += ExampleBackGroundPanel_Click;
            parentPanel.Controls.Add(littlePanel);
            //81, 10

            var label = new Label()
            {
                Width = 76,
                Height = 10,
                Text = item.Name,
                Font = new("Segoe UI", 7),
                Location = new Point(3, 4)
            };
            littlePanel.Controls.Add(label);
            label.Click += ExampleBackGroundPanel_Click;

            var numeric = new NumericUpDown()
            {
                Location = new Point(173, -2),
                Value = item.Rating,
                Increment = 1,
                Minimum = 0,
                Width = 44,
                Maximum = 5

            };
            littlePanel.Controls.Add(numeric);
            numeric.ValueChanged += RatingPanelNumeric_ValueChanged;

            RadioButton[] buttons = new RadioButton[5];
            for (int j = 0; j < 5; j++)
            {
                var radioButton = new RadioButton()
                {
                    Size = new Size(14, 13),
                    Location = new Point(80 + 20 * j, 6),//86
                    AutoCheck = false
                };
                littlePanel.Controls.Add(radioButton);

                if(item.Rating > j)
                {
                    radioButton.Checked = true;
                }
                buttons[j] = radioButton;
            }

            ratingGuiPanels.Add(new()
            {
                rating = item,
                Label = label,
                Numeric = numeric,
                RadioButtons = buttons,
                Panel = littlePanel
            }
                );
        }
    }

    #endregion

    #region BackgrounsManagment

    void OpenAddBackgroundWindow()
    {
        var addWindow = new AddARatingForm(
            this, 
            _chosenCharacter.Backgrounds, 
            typeof(Background),
            new BackGroundHelper()
            );
        addWindow.ShowDialog();
    }

    void RenderBackGrounds()
    {
        RenderCollectionGui(BackgroundsInnerPanel, _chosenCharacter.Backgrounds);
    }

    #endregion

    #region DisciplinesManagment

    void OpenAddDisciplineWindow()
    {
        var addWindow = new AddARatingForm(
            this,
            _chosenCharacter.Disciplines,
            typeof(Discipline),
            new DisciplineHelper()
            );
        addWindow.ShowDialog();
    }

    void RenderDisciplines()
    {
        RenderCollectionGui(DisciplinesInnerPanel, _chosenCharacter.Disciplines);
    }

    #endregion

    #region MeritsAndFlawManagment

    void OpenAddMeritWindow()
    {
        var addWindow = new AddARatingForm(
            this,
            _chosenCharacter.Merits,
            typeof(MeritEntity),
            new MeritHelper()
            );
        addWindow.ShowDialog();
    }

    void RenderMerits()
    {
        var parentPanel = MeritsInnerPanel;
        var collection = _chosenCharacter.Merits;

        meritGuiPanels.Clear();
        parentPanel.Controls.Clear();

        for (int i = 0; i < collection.Count; i++)
        {
            

            ARating? item = collection[i];
            MeritEntity? merit = item as MeritEntity;
            if ( merit is null )
            {
                MessageBox.Show($"{item.GetType()}\n {item.Name} не достоинство или недостаток");
                continue;
            }
            var littlePanel = new Panel()
            {
                Width = 207,//227
                Height = 19,
                //BackColor = Color.Green,
                Location = new Point(23, 3 + i * 20)
            };
            //littlePanel.Click += ExampleBackGroundPanel_Click;
            parentPanel.Controls.Add(littlePanel);
            //81, 10

            var label = new Label()
            {
                Width = 200,
                Height = 10,
                Text = item.Name,
                Font = new("Segoe UI", 7),
                Location = new Point(40, 4)
            };
            littlePanel.Controls.Add(label);

            var removeButton = new Button()
            {
                Location = Location = new Point(15, 4),
                Text = "-",

                Font = new("Segoe UI", 7),
                Width = 11
            };
            removeButton.Click += RemoveMeritButton_Click;
            littlePanel.Controls.Add(removeButton);

            CheckBox? checkbox = null;
            if (merit.CanBeActivated)
            {
                checkbox = new CheckBox()
                {
                    Checked = merit.Active
                };
                littlePanel.Controls.Add(checkbox);
                checkbox.CheckedChanged += ActivateMeritCheckBox_CheckedChanged;
                //MessageBox.Show($"+ {item.Name} can be activated");
            }
            else
            {
                //MessageBox.Show($"- {item.Name} can not be activated");
                //MessageBox.Show(JsonSerializer.Serialize(merit));
            }

            meritGuiPanels.Add(new() { 
                Button = removeButton, 
                Label = label, 
                Panel = littlePanel, 
                rating = merit, 
                CheckBox = checkbox }
            );
        }
    }

    private void RemoveMeritButton_Click(object sender, EventArgs e)
    {
        var meritGuiPanel  = meritGuiPanels.Where(panel => panel.Button == sender ).FirstOrDefault();
        if (meritGuiPanel is null)
        {
            return;
        }

        //MessageBox.Show(meritGuiPanel.rating.Name);
        _chosenCharacter.Merits.Remove(meritGuiPanel.rating);

        UpdateCharacter();
    }

    private void ActivateMeritCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        var meritGuiPanel = meritGuiPanels.Where(panel => panel.CheckBox == sender).FirstOrDefault();
        if (meritGuiPanel is null)
        {
            return;
        }

        //MessageBox.Show(meritGuiPanel.rating.Name);
        meritGuiPanel.rating.Active = meritGuiPanel.CheckBox.Checked;

        UpdateCharacter();
    }

    #endregion
}
