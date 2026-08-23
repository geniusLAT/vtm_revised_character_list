namespace vtmRevisedCharacterListEntities;

public class Character
{
    public string CharacterName { get; set; } = string.Empty;

    public string PlayerName { get; set; } = string.Empty;

    public string ChronicleName { get; set; } = string.Empty;

    #region Attributes

    #region Physical

    public uint Strenght { get; set; }

    public uint Dexterity { get; set; }

    public uint Stamina { get; set; }

    #endregion

    #region Social

    public uint Charisma { get; set; }

    public uint Manipulation { get; set; }

    public uint Appearance { get; set; }

    #endregion

    #region Mental

    public uint Perception { get; set; }

    public uint Intellegence { get; set; }

    public uint Wits { get; set; }

    #endregion

    #endregion

    #region Abilities

    #region Talents

    public uint Alertness { get; set; }

    public uint Athletics { get; set; }

    public uint Brawl { get; set; }

    public uint Dodge { get; set; }

    public uint Empathy { get; set; }

    public uint Expression { get; set; }

    public uint Intimidation { get; set; }

    public uint Leadership { get; set; }

    public uint Streetwise { get; set; }

    public uint Subterfuge { get; set; }

    #endregion

    #region Skills

    public uint AnimalKen { get; set; }

    public uint Crafts { get; set; }

    public uint Drive { get; set; }

    public uint Etiquette { get; set; }

    public uint Firearms { get; set; }

    public uint Melee { get; set; }

    public uint Perfomance { get; set; }

    public uint Security { get; set; }

    public uint Stealth { get; set; }

    public uint Survival { get; set; }

    #endregion

    #region Knowledges

    public uint Academics { get; set; }

    public uint Computer { get; set; }

    public uint Finance { get; set; }

    public uint Investigation { get; set; }

    public uint Law { get; set; }

    public uint Linguistics { get; set; }

    public uint Medicine { get; set; }

    public uint Occult { get; set; }

    public uint Politics { get; set; }

    public uint Science { get; set; }

    #endregion

    #endregion

    #region Advantages

    #region Disciplines



    #endregion

    #region Backgrounds



    #endregion

    #region Virtues

    public uint ConscienceConviction { get; set; }

    public uint SelfControlInstincts { get; set; }

    public uint Courage { get; set; }

    #endregion

    #endregion

    #region Other

    public uint HumanityPath { get; set; }

    public uint WillpowerMax { get; set; }

    public uint Willpower { get; set; }

    public uint Bloodpool { get; set; }

    public uint Damage { get
        {
            return CommonDamage + AggravatedDamage;
        }
    }
    public uint CommonDamage { get; set; }
    
    public uint AggravatedDamage { get; set; }



    #endregion

    public HealthCondition GetHealthCondition()
    {
        if (Damage == 0) return HealthCondition.Ok;
        if (BonusHealth())
        {
            return (HealthCondition)Damage;
        }
        return (HealthCondition)(1+Damage);
    }

    public uint SetOther(OtherRollable other, uint value)
    {
        switch (other)
        {
            case OtherRollable.ConstWillpower:
                return WillpowerMax = value;
            case OtherRollable.TempWillpower:
                return Willpower = value;
            case OtherRollable.ConscienceConviction:
                return ConscienceConviction = value;
            case OtherRollable.SelfControlInstinct:
                return SelfControlInstincts = value;
            case OtherRollable.Courage:
                return Courage = value;
            case OtherRollable.HumanityPath:
                return HumanityPath = value;
        }

        return value;
    }

    public uint GetOther(OtherRollable other)
    {
        switch (other)
        {
            case OtherRollable.ConstWillpower:
                return WillpowerMax;
            case OtherRollable.TempWillpower:
                return Willpower;
            case OtherRollable.ConscienceConviction:
                return ConscienceConviction;
            case OtherRollable.SelfControlInstinct:
                return SelfControlInstincts;
            case OtherRollable.Courage:
                return Courage;
            case OtherRollable.HumanityPath:
                return HumanityPath;
        }

        return 0;
    }
    public uint SetAttribute(AttributeVtm attribute, uint value)
    {
        switch (attribute)
        {
            case AttributeVtm.Strenght:
                return Strenght = value;
            case AttributeVtm.Dexterity:
                return Dexterity = value;
            case AttributeVtm.Stamina:
                return Stamina = value;
            case AttributeVtm.Charisma:
                return Charisma = value;
            case AttributeVtm.Manipulation:
                return Manipulation = value;
            case AttributeVtm.Appearance:
                return Appearance = value;
            case AttributeVtm.Perception:
                return Perception = value;
            case AttributeVtm.Intelligance:
                return Intellegence = value;
            case AttributeVtm.Wits:
                return Wits = value;
        }

        return value;
    }

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
    public uint SetAbility(Ability ability, uint value)
    {
        switch (ability)
        {
            case Ability.Alertness:
                return Alertness = value;
            case Ability.Athletics:
                return Athletics = value;
            case Ability.Brawl:
                return Brawl = value;
            case Ability.Dodge:
                return Dodge = value;
            case Ability.Empathy:
                return Empathy = value;
            case Ability.Expression:
                return Expression = value;
            case Ability.Intimidation:
                return Intimidation = value;
            case Ability.Leadership:
                return Leadership = value;
            case Ability.Streetwise:
                return Streetwise = value;
            case Ability.Subterfuge:
                return Subterfuge = value;
            case Ability.AnimalKen:
                return AnimalKen = value;
            case Ability.Crafts:
                return Crafts = value;
            case Ability.Drive:
                return Drive = value;
            case Ability.Etiquette:
                return Etiquette = value;
            case Ability.Firearms:
                return Firearms = value;
            case Ability.Melee:
                return Melee = value;
            case Ability.Perfomance:
                return Perfomance = value;
            case Ability.Security:
                return Security = value;
            case Ability.Stealth:
                return Stealth = value;
            case Ability.Survival:
                return Survival = value;
            case Ability.Academics:
                return Academics = value;
            case Ability.Computer:
                return Computer = value;
            case Ability.Finance:
                return Finance = value;
            case Ability.Investigation:
                return Investigation = value;
            case Ability.Law:
                return Law = value;
            case Ability.Linguistics:
                return Linguistics = value;
            case Ability.Medicine:
                return Medicine = value;
            case Ability.Occult:
                return Occult = value;
            case Ability.Politics:
                return Politics = value;
            case Ability.Science:
                return Science = value;
        }

        return value;
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

    public bool BonusHealth()
    {
        return false;
    }
}