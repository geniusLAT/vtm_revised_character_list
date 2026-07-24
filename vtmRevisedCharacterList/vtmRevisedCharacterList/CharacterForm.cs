using System;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class CharacterForm : Form
{
    public CharacterForm()
    {
        InitializeComponent();
        ClearAttributeChoice();
        ClearAbilityChoice();
        FindButtonsForAttributes();
        FindButtonsForAbilities();

        var character = new Character()
        {
            Strenght = 1,
            Dexterity = 2,
            Stamina = 3,

            Charisma = 4,
            Manipulation = 5,
            Appearance = 1,
            Perception = 2,
            Intellegence = 3,
            Wits = 4,


            Drive = 5,
            Intimidation = 1,
            Firearms = 2
        };
        RenderCharacter(character);
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void PhysicalAttributes_Paint(object sender, PaintEventArgs e)
    {

    }

    private void StrenghtPanel_Paint(object sender, PaintEventArgs e)
    {
        //StrenghtPanel.BackColor = Color.Yellow;
    }
    private void StrenghtPanel_Click(object sender, PaintEventArgs e)
    {
        ChooseAttribute(AttributeVtm.Strenght);
    }

    private void panel13_Paint(object sender, PaintEventArgs e)
    {

    }

    private void StrenghtPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Strenght);
    }

    private void DexterityPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Dexterity);
    }

    private void StaminaPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Stamina);
    }

    private void PerceptionPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Perception);
    }

    private void IntelligecePanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Intelligance);
    }

    private void WitsPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Wits);
    }

    private void CharismaPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Charisma);
    }

    private void ManipulationPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Manipulation);
    }

    private void AppearanceLabel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(AttributeVtm.Appearance);
    }

    private void label56_Click(object sender, EventArgs e)
    {

    }

    private void AlertnessPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Alertness);
    }

    private void AthleticsPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Athletics);
    }

    private void BrawlPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Brawl);
    }

    private void DodgePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Dodge);
    }

    private void EmpathyPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Empathy);
    }

    private void ExpressionPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Expression);
    }

    private void IntimidationPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Intimidation);
    }

    private void LeadershipPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Leadership);
    }

    private void StreetwisePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Streetwise);
    }

    private void SubterfugePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Subterfuge);
    }

    private void AnimalKenPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.AnimalKen);
    }

    private void CraftsPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Crafts);
    }

    private void DrivePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Drive);
    }

    private void EtiquettePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Etiquette);
    }

    private void FirearmsPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Firearms);
    }

    private void MeleePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Melee);
    }

    private void PerfomancePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Perfomance);
    }

    private void SecurityPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Security);
    }

    private void StealthPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Stealth);
    }

    private void SurvivalPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Survival);
    }

    private void AcademicsPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Academics);
    }

    private void ComputerPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Computer);
    }

    private void FinancePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Finance);
    }

    private void InvestigationPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Investigation);
    }

    private void LawPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Law);
    }

    private void LinguisticsPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Linguistics);
    }

    private void MedicinePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Medicine);
    }
    private void OccultPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Occult);
    }

    private void OccultPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void OccultPanel_Paint(object sender, EventArgs e)
    {

    }

    private void PoliticsPanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Politics);
    }

    private void SciencePanel_Click(object sender, EventArgs e)
    {
        ChooseAbility(Ability.Science);
    }

    private void label82_Click(object sender, EventArgs e)
    {

    }
}
