using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtmRevisedCharacterListEntities
{
    public class CharacterUpdateRequest
    {
        public Guid UserUuid {  get; set; }

        public Guid CharacterUuid { get; set; }

        public required Character CharacterToUpdate { get; set; }

        public bool Hidden { get; set; }
    }
}
