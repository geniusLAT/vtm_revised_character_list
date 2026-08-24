using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
