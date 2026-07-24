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
    Ability? _chosenAbility;

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

        for (int i = 0; i < 30; i++)
        {
            Ability ability = (Ability)i;
            var panel = GetAbilityPanel(ability);
            if (panel != null)
            {
                panel.BackColor = Color.White;
            }
        }

            //return AlertnessPanel;
        
            //return AthleticsPanel;
        
            //return BrawlPanel;
        
            //return DodgePanel;
        
            //return EmpathyPanel;
        
            //return ExpressionPanel;
        
            //return IntimidationPanel;
        
            //return LeadershipPanel;
        
            //return StreetwisePanel;
        
            //return SubterfugePanel;
        
            //return AnimalKenPanel;
        
            //return CraftsPanel;
        
            //return DrivePanel;
        
            //return EtiquettePanel;
        
            //return FirearmsPanel;
        
            //return MeleePanel;
        
            //return PerfomancePanel;
        
            //return SecurityPanel;
        
            //return StealthPanel;
        
            //return SurvivalPanel;
        
            //return AcademicsPanel;
        
            //return ComputerPanel;
        
            //return FinancePanel;
        
            //return InvestigationPanel;
        
            //return LawPanel;
        
            //return LinguisticsPanel;
        
            //return MedicinePanel;
        
            //return OccultPanel;
        
            //return PoliticsPanel;
        
            //return SciencePanel;

            //StrenghtPanel.BackColor =
            //DexterityPanel1.BackColor =
            //StaminaPanel.BackColor =
            //CharismaPanel.BackColor =
            //ManipulationPanel.BackColor =
            //AppearancePanel.BackColor =
            //PerceptionPanel.BackColor =
            //IntelligecePanel.BackColor =
            //WitsPanel.BackColor =
            //Color.White;
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
        ClearAttributeChoice();
        var panel = GetAttributePanel(_chosenAttribute);
        if (panel != null)
        {
            panel.BackColor = Color.Yellow;
        }
    }

    void ChooseAbility(Ability ability)
    {
        _chosenAbility = ability;
        ClearAbilityChoice();
        var panel = GetAbilityPanel(_chosenAbility);
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

        for (int i = 0; i < 30; i++)
        {
            Ability ability = (Ability)i;
            uint attributeValue = character.GetAbility(ability);
            GetAbilityNumeric(ability)!.Value = attributeValue;
            SetButtonsForNum(GetAbilityButtons(ability), attributeValue);

        }
    }
}
