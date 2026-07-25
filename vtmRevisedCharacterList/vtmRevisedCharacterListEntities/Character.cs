namespace vtmRevisedCharacterListEntities;

public class Character
{
    public string CharacterName { get; set; } = string.Empty;

    public string PlayerName { get; set; } = string.Empty;

    public string ChronicleName { get; set; } = string.Empty;

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

    public uint GetAbility(Ability ability)
    {
        switch (ability)
        {
            case Ability.Alertness:
                return Alertness;
            case Ability.Athletics:
                return Athletics;
            case Ability.Brawl:
                return Brawl;
            case Ability.Dodge:
                return Dodge;
            case Ability.Empathy:
                return Empathy;
            case Ability.Expression:
                return Expression;
            case Ability.Intimidation:
                return Intimidation;
            case Ability.Leadership:
                return Leadership;
            case Ability.Streetwise:
                return Streetwise;
            case Ability.Subterfuge:
                return Subterfuge;
            case Ability.AnimalKen:
                return AnimalKen;
            case Ability.Crafts:
                return Crafts;
            case Ability.Drive:
                return Drive;
            case Ability.Etiquette:
                return Etiquette;
            case Ability.Firearms:
                return Firearms;
            case Ability.Melee:
                return Melee;
            case Ability.Perfomance:
                return Perfomance;
            case Ability.Security:
                return Security;
            case Ability.Stealth:
                return Stealth;
            case Ability.Survival:
                return Survival;
            case Ability.Academics:
                return Academics;
            case Ability.Computer:
                return Computer;
            case Ability.Finance:
                return Finance;
            case Ability.Investigation:
                return Investigation;
            case Ability.Law:
                return Law;
            case Ability.Linguistics:
                return Linguistics;
            case Ability.Medicine:
                return Medicine;
            case Ability.Occult:
                return Occult;
            case Ability.Politics:
                return Politics;
            case Ability.Science:
                return Science;
        }

        return 0;
    }
}