using System.Text;

namespace vtmRevisedCharacterListEntities
{
    public class RollResult
    {
        public required uint[] Rolls { get; set; }

        public int Succeses { get; set; }

        public bool CriticallyFailed { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var roll in Rolls)
            {
                sb.Append($"{roll} ");
            }
            sb.Append($"\nУспехов: {Succeses}");
            if (CriticallyFailed)
            {
                sb.Append($"\nКритический провал");
            }
            return sb.ToString();
        }
    }
}
