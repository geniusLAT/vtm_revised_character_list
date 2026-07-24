using System;

namespace vtmRevisedCharacterList;

enum Attribute
{
    Strenght = 0,
    Dexterity = 1,
    Stamina = 2,
    Charisma = 3,
    Manipulation = 4,
    Appearance = 5,
    Perception = 6,
    Intelligance = 7,
    Wits = 8
}
 
public partial class CharacterForm : Form
{
    Attribute? _chosenAttribute;

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

    Panel? GetAttributePanel(Attribute? attribute)
    {
        switch (attribute)
        {
            case Attribute.Strenght:
                return StrenghtPanel;
            case Attribute.Dexterity:
                return DexterityPanel1;
            case Attribute.Stamina:
                return StaminaPanel;
            case Attribute.Charisma:
                return CharismaPanel;
            case Attribute.Manipulation:
                return ManipulationPanel;
            case Attribute.Appearance:
                return AppearancePanel;
            case Attribute.Perception:
                return PerceptionPanel;
            case Attribute.Intelligance:
                return IntelligecePanel;
            case Attribute.Wits:
                return WitsPanel;
            case null:
            default:
                return null;
        }
    }

    void ChooseAttribute(Attribute attribute)
    {
        _chosenAttribute = attribute;
        ClearAttributeChoice();
        var panel = GetAttributePanel(_chosenAttribute);
        if (panel != null)
        {
            panel.BackColor = Color.Yellow;
        }
    }


    public CharacterForm()
    {
        InitializeComponent();
        ClearAttributeChoice();
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
        ChooseAttribute(Attribute.Strenght);
    }

    private void panel13_Paint(object sender, PaintEventArgs e)
    {

    }

    private void StrenghtPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Strenght);
    }

    private void DexterityPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Dexterity);
    }

    private void StaminaPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Stamina);
    }

    private void PerceptionPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Perception);
    }

    private void IntelligecePanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Intelligance);
    }

    private void WitsPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Wits);
    }

    private void CharismaPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Charisma);
    }

    private void ManipulationPanel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Manipulation);
    }

    private void AppearanceLabel_Click(object sender, EventArgs e)
    {
        ChooseAttribute(Attribute.Appearance);
    }
}
