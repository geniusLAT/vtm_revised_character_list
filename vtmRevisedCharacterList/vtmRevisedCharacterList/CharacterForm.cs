using System;
using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList;

public partial class CharacterForm : Form
{
    public CharacterForm()
    {
        InitializeComponent();
        ClearAttributeChoice();

        FindButtonsForAttributes();

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
}
