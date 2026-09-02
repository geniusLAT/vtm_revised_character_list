using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtmRevisedCharacterListEntities;

public class UserEntity
{
    public string Name { get; set; } = string.Empty;

    public List<Guid> AccessedCharacters { get; set; } = [];
}
