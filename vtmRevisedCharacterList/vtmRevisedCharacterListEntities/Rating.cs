using System.Text.Json.Serialization;

namespace vtmRevisedCharacterListEntities;

[JsonDerivedType(typeof(MeritEntity), typeDiscriminator: "merit")]
[JsonDerivedType(typeof(Background), typeDiscriminator: "background")]
[JsonDerivedType(typeof(Discipline), typeDiscriminator: "discipline")]
[JsonDerivedType(typeof(RatingDto), typeDiscriminator: "ratingDto")]
public abstract class ARating
{
    public required string Name { get; set; }

    public required uint Rating { get; set; }
}
