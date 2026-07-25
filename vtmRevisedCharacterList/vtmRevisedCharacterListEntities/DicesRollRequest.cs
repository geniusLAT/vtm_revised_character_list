namespace vtmRevisedCharacterListEntities;

public class DicesRollRequest
{
    public uint DicesToRoll {  get; set; }

    public uint Difficulty {  get; set; }

    public string Comment { get; set; } = string.Empty;

    public uint AutoSuccesses { get; set; }

    public uint RemoveCriticalFailure { get; set; }

    public bool Specialization { get; set; }

    public RollResult Roll()
    {
        Random rnd = new Random();
        List<uint> rolls = new List<uint>();
        var DicesToRoll = this.DicesToRoll;
        var succeses = 0;
        var potentialCritical = AutoSuccesses < 1; //no critical with autosucceses
        var haveToRemoveValueOne = RemoveCriticalFailure;
        while (DicesToRoll > 0)
        {
            DicesToRoll--;
            uint num = (uint)rnd.Next(1, 11);
            rolls.Add(num);
            if (num >= Difficulty) 
            {
                succeses++;
                potentialCritical = false;
                if (Specialization && num == 10)
                {
                    DicesToRoll++;
                }
            }
            if (num == 1)
            {
                if (haveToRemoveValueOne > 0) //for daredevil case
                {
                    haveToRemoveValueOne--;
                }
                else
                {
                    succeses--;
                }
            }

        }
        succeses += (int)AutoSuccesses;
        var criticalFailed = potentialCritical && succeses < 0;

        return new()
        {
            Rolls = rolls.ToArray(),
            Succeses = succeses,
            CriticallyFailed = criticalFailed,
        };
    }
}