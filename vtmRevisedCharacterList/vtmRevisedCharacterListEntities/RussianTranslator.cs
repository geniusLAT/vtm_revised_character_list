namespace vtmRevisedCharacterListEntities;

public static class RussianTranslator
{
    #region changeLogWording

    public const string IncreasedWord = " повышается до";

    public const string DecreasedWord = " понижается до";

    public const string ChangedWord = " меняется на";

    #endregion

    public static string TranslateOther(OtherRollable? other)
    {
        return other switch
        {
            OtherRollable.ConstWillpower => "Постоянная сила воли",
            OtherRollable.TempWillpower => "Временная сила воли",
            OtherRollable.ConscienceConviction => "Совесть/убеждённость",
            OtherRollable.SelfControlInstinct => "Самоконтроль/Инстинкты",
            OtherRollable.Courage => "Храбрость",
            null => throw new NotImplementedException(),
            _ => "Неназванный аттрибут",
        };
    }

    public static string TranslateAttribute(AttributeVtm? attribute)
    {
        return attribute switch
        {
            AttributeVtm.Strenght => "Сила",
            AttributeVtm.Dexterity => "Ловкость",
            AttributeVtm.Stamina => "Выносливость",
            AttributeVtm.Charisma => "Обаяние",
            AttributeVtm.Manipulation => "Манипулирование",
            AttributeVtm.Appearance => "Внешность",
            AttributeVtm.Perception => "Восприятие",
            AttributeVtm.Intelligance => "Интеллект",
            AttributeVtm.Wits => "Сообразительность",
            _ => "Неназванный аттрибут",
        };
    }

    public static string TranslateAbility(Ability? ability)
    {
        return ability switch
        {
            Ability.Alertness => "Бдительность",
            Ability.Athletics => "Атлетика",
            Ability.Brawl => "Рукопашный бой",
            Ability.Dodge => "Уклонение",
            Ability.Empathy => "Эмпатия",
            Ability.Expression => "Убеждение",
            Ability.Intimidation => "Запугивание",
            Ability.Leadership => "Лидерство",
            Ability.Streetwise => "Уличные порядки",
            Ability.Subterfuge => "Хитрость",
            Ability.AnimalKen => "Понимание зверей",
            Ability.Crafts => "Ремесло",
            Ability.Drive => "Вождение",
            Ability.Etiquette => "Этикет",
            Ability.Firearms => "Огнестрельное оружие",
            Ability.Melee => "Холодное оружие",
            Ability.Perfomance => "Исполнение",
            Ability.Security => "Безопасность",
            Ability.Stealth => "Скрытность",
            Ability.Survival => "Выживание",
            Ability.Academics => "Гуманитарные науки",
            Ability.Computer => "Компьютеры",
            Ability.Finance => "Финансы",
            Ability.Investigation => "Расследование",
            Ability.Law => "Закон",
            Ability.Linguistics => "Языки",
            Ability.Medicine => "Медицина",
            Ability.Occult => "Оккультизм",
            Ability.Politics => "Политика",
            Ability.Science => "Естественные науки",
            _ => "Неназванная способность",
        };
    }
}