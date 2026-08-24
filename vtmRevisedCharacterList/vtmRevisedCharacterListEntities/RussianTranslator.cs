namespace vtmRevisedCharacterListEntities;

public static class RussianTranslator
{
    #region changeLogWording

    public const string IncreasedWord = " повышается до";

    public const string DecreasedWord = " понижается до";

    public const string ChangedWord = " меняется на";

    #endregion

    #region ConstsTranslation

    public const string PlayerName = "Имя игрока ";

    public const string CharacterName = "Имя ";

    public const string ChronicleName = "Хроника ";

    public const string CommonDamage = "Число повреждений ";

    public const string AggravatedDamage = "Число аггравированных повреждений ";

    public const string Damage = "Общее число повреждений ";

    public const string Bloodpool = "Витэ ";

    public const string Lenght = "количество ";

    public const string Removed = "удален ";

    public const string Added = "добавлен ";

    public const string Backgrounds = "Детали биографии";

    public const string Disciplines = "Дисциплины";

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
            OtherRollable.HumanityPath => "Человечность/Путь",
            OtherRollable.Bloodpool => "Витэ",
            _ => "Неназванный аттрибут",
        };
    }

    public static string TranslateHealthCondition(HealthCondition? condition)
    {
        return condition switch
        {
            HealthCondition.Ok => "ОК",
            HealthCondition.Bruised => "Пустяк",
            HealthCondition.Hurt => "Боль",
            HealthCondition.Injured => "Лёгкие травмы",
            HealthCondition.Wounded => "Средние травмы",
            HealthCondition.Mauled => "Тяжёлые травмы",
            HealthCondition.Crippled => "Увечья",
            HealthCondition.Incapacitated => "Нокаут",
            HealthCondition.Dead => "Торпор/смерть",
            null => throw new NotImplementedException(),
            _ => "Неназванное состояние здоровья",
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

    public static string TranslateBackground(DefaultBackground? background)
    {
        return background switch
        {
            DefaultBackground.Allies => "Союзники",
            DefaultBackground.Contacts => "Контакты",
            DefaultBackground.Fame => "Слава",
            DefaultBackground.Generation => "Поколение",
            DefaultBackground.Herd => "Стадо",
            DefaultBackground.Influence => "Влияние",
            DefaultBackground.Mentor => "Наставник",
            DefaultBackground.Resources => "Ресурсы",
            DefaultBackground.Retainers => "Слуги",
            DefaultBackground.Status => "Статус",
            null => "Неназванная деталь биографии",
            _ => "Неназванная деталь биографии",
        };
    }

    public static string TranslateDiscipline(DefaultDiscipline? discipline)
    {
        return discipline switch
        {
            DefaultDiscipline.Animalism => "Анимализм",
            DefaultDiscipline.Auspex => "Прорицание",
            DefaultDiscipline.Celerity => "Стремительность",
            DefaultDiscipline.Chimerstry => "Химерия",
            DefaultDiscipline.Dementation => "Помешательство",
            DefaultDiscipline.Dominate => "Доминирование",
            DefaultDiscipline.Fortitude => "Стойкость",
            DefaultDiscipline.Obfuscate => "Затемнение",
            DefaultDiscipline.Obtenebration => "Власть над тенью",
            DefaultDiscipline.Potence => "Могущество",
            DefaultDiscipline.Presence => "Присутствие",
            DefaultDiscipline.Protean => "Превращение",
            DefaultDiscipline.Quietus => "Смертносность",
            DefaultDiscipline.Serpentis => "Серпентис",
            DefaultDiscipline.Vicissitude => "Изменчивость",
            DefaultDiscipline.NecromancySepulchrePath => "Некромантия, путь склепа",
            DefaultDiscipline.NecromancyAshPath => "Некромантия, путь праха",
            DefaultDiscipline.NecromancyBonePath => "Некромантия, путь кости",
            DefaultDiscipline.ThaumaturgyPathOfBlood => "Тауматургия, путь крови",
            DefaultDiscipline.ThaumaturgyLureOfFlames => "Туматургия, привлечение огней",
            DefaultDiscipline.ThaumaturgyMovementOfTheMind => "Тауматургия, движение разума",
            DefaultDiscipline.ThaumaturgyPathOfConjuring => "Тауматургия, путь создания",
            DefaultDiscipline.ThaumaturgyHandsOfDistraction => "Тауматургия, руки разрушения",
            null => "Неназванная дисциплина",
            _ => "Неназванная дисциплина",
        };
    }
}