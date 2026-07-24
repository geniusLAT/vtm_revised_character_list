namespace vtmRevisedCharacterListEntities;

public class CubeRollRequest
{
    public uint CubesToRoll {  get; set; }

    public uint Difficulty {  get; set; }

    public string Comment { get; set; } = string.Empty;
}