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

    public override bool Equals(object? obj)
    {
        if (obj == null)
        return false;

        var otherMerit = obj as MeritEntity;
        if (otherMerit is null)
            return false;

        if (Active != otherMerit.Active) return false;
        if (CanBeActivated != otherMerit.CanBeActivated) return false;
        if (DefaultMerit != otherMerit.DefaultMerit) return false;
        if (Name != otherMerit.Name) return false;
        if (Rating != otherMerit.Rating) return false;
        if (Effect != otherMerit.Effect) return false;

        return true;
    }
}
