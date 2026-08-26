using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace vtmRevisedCharacterListEntities;

public class MeritEffect
{
    public int MeritDifficultyEffect { get; set; }

    public int MeritDicepoolEffect { get; set; }

    public bool DaredevilRemoveOne { get; set; }

    public bool ExtraHealth { get; set; }

    //Can not be activated, no mechanical effect. Only narrative
    public bool Narrative { get
        {
            return MeritDifficultyEffect == 0 && MeritDicepoolEffect == 0 && !DaredevilRemoveOne && !ExtraHealth;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        var otherMeritEffect = obj as MeritEffect;
        if (otherMeritEffect is null)
            return false;

        if (MeritDifficultyEffect != otherMeritEffect.MeritDifficultyEffect) return false;
        if (MeritDicepoolEffect != otherMeritEffect.MeritDicepoolEffect) return false;
        if (DaredevilRemoveOne != otherMeritEffect.DaredevilRemoveOne) return false;
        if (ExtraHealth != otherMeritEffect.ExtraHealth) return false;
      

        return true;

    }
}
