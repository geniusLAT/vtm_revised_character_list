using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtmRevisedCharacterListEntities
{
    public class CharacterListMember
    {
        public Guid CharacterUuid {  get; set; }

        public string CharacterName { get; set; } = string.Empty;
    }
}
