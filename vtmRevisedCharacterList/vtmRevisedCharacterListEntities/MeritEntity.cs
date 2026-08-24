using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtmRevisedCharacterListEntities;

public class MeritEntity : ARating
{
    public DefaultMerit? DefaultMerit {  get; set; }

    public MeritEffect Effect { get; set; } = new MeritEffect();

    public bool CanBeActivated { get; set; } = true;

    public bool Active { get; set; }
}
