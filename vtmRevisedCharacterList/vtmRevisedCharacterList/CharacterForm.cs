using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class CharacterForm : Form
{
    public CharacterForm()
    {
        InitializeComponent();
        StartIt();
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
    private void ExtraDicePoolLabel_Click(object sender, EventArgs e)
    {
        _extraDicePool = (uint)(ExtraDicePoolNumeric.Value = 0);
        CalculateDices();
    }

    private void ExtraDicePoolNumeric_ValueChanged(object sender, EventArgs e)
    {
        _extraDicePool = (uint)(ExtraDicePoolNumeric.Value);
        if (_extraDicePool != 0)
        {
            ExtraDicePoolLabel.ForeColor = Color.Red;
        }else
        {
            ExtraDicePoolLabel.ForeColor = Color.Black;
        }
        CalculateDices();
    }

    private void label84_Click(object sender, EventArgs e)
    {
        _baseDifficulty = (uint)(DifficultyNumeric.Value = 6);
        CalculateDices();
    }

    private void DifficultyNumeric_ValueChanged(object sender, EventArgs e)
    {
        _baseDifficulty = (uint)(DifficultyNumeric.Value);
        CalculateDices();
    }

    private void additionalAutoSuccessNumeric_ValueChanged(object sender, EventArgs e)
    {
        _additionalAutoSuccess = (uint)(additionalAutoSuccessNumeric.Value);
        CalculateDices();
    }

    private void AdditionalAutoSuccessLabel_Click(object sender, EventArgs e)
    {
        _additionalAutoSuccess = (uint)(additionalAutoSuccessNumeric.Value = 0);
        CalculateDices();
    }

    private async void RollDiceButton_Click(object sender, EventArgs e)
    {
        //RollDice();
        RollDiceButton.Enabled = false;

        await RollDiceAsync();

        RollDiceButton.Enabled = true;
    }

    private void SpecializationCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _specialization = SpecializationCheckBox.Checked;
    }

    private void ConstWillpowerPanel_Click(object sender, EventArgs e)
    {
        ChooseOther(OtherRollable.ConstWillpower);
    }

    private void ConscienceConvictionPanel_Click(object sender, EventArgs e)
    {
        ChooseOther(OtherRollable.ConscienceConviction);
    }

    private void SelfControlInstinctPanel_Click(object sender, EventArgs e)
    {
        ChooseOther(OtherRollable.SelfControlInstinct);
    }

    private void CouragePanel_Click(object sender, EventArgs e)
    {
        ChooseOther(OtherRollable.Courage);
    }

    private void TempWillpowerPanel_Click(object sender, EventArgs e)
    {
        ChooseOther(OtherRollable.TempWillpower);
    }

    private void HumanityPathPanel_Click(object sender, EventArgs e)
    {
        ChooseOther(OtherRollable.HumanityPath);
    }

    private void HumanityPathLabel_Click(object sender, EventArgs e)
    {
        ChooseOther(OtherRollable.HumanityPath);
    }
    private void BloodpoolLabel_Click(object sender, EventArgs e)
    {
        ChooseOther(OtherRollable.Bloodpool);
    }

    private void debuffDicePoolNumeric_ValueChanged(object sender, EventArgs e)
    {
        _debuffDicePool = (uint)debuffDicePoolNumeric.Value;
        CalculateDices();
    }

    private void debuffDicePoolLabel_Click(object sender, EventArgs e)
    {
        _debuffDicePool = (uint)(debuffDicePoolNumeric.Value = 0);
        CalculateDices();
    }

    private async void characterComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var characterClickedIndex = characterComboBox.SelectedIndex;
        await ChooseAnotherCharacter(characterClickedIndex);
    }

    private void UpdateCharacterButton_Click(object sender, EventArgs e)
    {
        UpdateCharacter();
    }

    private void CharacterNumeric_ValueChanged(object sender, EventArgs e)
    {
        MarkUnsavedChanges();
    }

    private void CancelUpdateButton_Click(object sender, EventArgs e)
    {
        CancelUpdating();
    }

    private void IgnoreHealthConditionCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _ignoreHealthCondition = IgnoreHealthConditionCheckBox.Checked;
        CalculateDices();
    }

    private void AddBackgroundButton_Click(object sender, EventArgs e)
    {
        OpenAddBackgroundWindow();
    }

    private void ExampleBackGroundPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void ExampleBackGroundPanel_Click(object sender, EventArgs e)
    {
        ClickOnRatingPanel(sender);
    }

    private void RatingPanelNumeric_ValueChanged(object sender, EventArgs e)
    {
        ClickOnNumericOnRatingPanel(sender);
    }

    private void AddDisciplineButton_Click(object sender, EventArgs e)
    {
        OpenAddDisciplineWindow();
    }

    private void AddMeritButton_Click(object sender, EventArgs e)
    {
        OpenAddMeritWindow();
    }

    private void HiddenMessage_CheckedChanged(object sender, EventArgs e)
    {
        _hiddenMessage = HiddenMessage.Checked;
    }

    private void CharacterManagmentButton_Click(object sender, EventArgs e)
    {
        OpenCharacterManagmentWindow();
    }

    private void BloodBuffMode_CheckedChanged(object sender, EventArgs e)
    {
        _useBloodBuffs = BloodBuffMode.Checked;

        RenderCharacter();
    }

    private void OpenBloodBuffWindowButton_Click(object sender, EventArgs e)
    {
        OpenBloodBuffForm();
    }
}
