using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtmRevisedCharacterListEntities
{
    public class CharacterRequest
    {
        public Guid UserUuid {  get; set; }

        public Guid CharacterUuid { get; set; }
    }
}
