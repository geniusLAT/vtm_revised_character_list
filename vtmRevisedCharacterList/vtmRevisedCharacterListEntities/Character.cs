namespace vtmRevisedCharacterListEntities;

public class Character
{
    #region Attributes

    #region Physical

    public uint Strenght;

    public uint Dexterity;

    public uint Stamina;

    #endregion

    #region Social

    public uint Charisma;

    public uint Manipulation;

    public uint Appearance;

    #endregion

    #region Mental

    public uint Perception;

    public uint Intellegence;

    public uint Wits;

    #endregion

    #endregion

    #region Abilities

    #region Talents

    public uint Alertness;

    public uint Athletics;

    public uint Brawl;

    public uint Dodge;

    public uint Empathy;

    public uint Expression;

    public uint Intimidation;

    public uint Leadership;

    public uint Streetwise;

    public uint Subterfuge;

    #endregion

    #region Skills

    public uint AnimalKen;

    public uint Crafts;

    public uint Drive;

    public uint Etiquette;

    public uint Firearms;

    public uint Melee;

    public uint Perfomance;

    public uint Security;

    public uint Stealth;

    public uint Survival;

    #endregion

    #region Knowledges

    public uint Academics;

    public uint Computer;

    public uint Finance;

    public uint Investigation;

    public uint Law;

    public uint Linguistics;

    public uint Medicine;

    public uint Occult;

    public uint Politics;

    public uint Science;

    #endregion

    #endregion

    #region Advantages

    #region Disciplines



    #endregion

    #region Backgrounds



    #endregion

    #region Virtues

    public uint ConscienceConviction;

    public uint SelfControlInstincts;

    public uint Courage;

    #endregion

    #endregion

    #region Other

    public uint HumanityPath;

    public uint WillpowerMax;

    public uint Willpower;

    public uint Bloodpool;

    public uint Health;

    #endregion

    public uint GetAttribute(AttributeVtm attribute)
    {
        switch (attribute)
        {
            case AttributeVtm.Strenght:
                return Strenght;
            case AttributeVtm.Dexterity:
                return Dexterity;
            case AttributeVtm.Stamina:
                return Stamina;
            case AttributeVtm.Charisma:
                return Charisma;
            case AttributeVtm.Manipulation:
                return Manipulation;
            case AttributeVtm.Appearance:
                return Appearance;
            case AttributeVtm.Perception:
                return Perception;
            case AttributeVtm.Intelligance:
                return Intellegence;
            case AttributeVtm.Wits:
                return Wits;
        }

        return 0;
    }
}