using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtmRevisedCharacterListEntities
{
    public class CharacterUpdateResult
    {
        public required Guid CharacterUuid { get; set; }

        public required Character UpdatedCharacter { get; set; }

        public string ChangeLog { get; set; } = string.Empty;
    }
}
