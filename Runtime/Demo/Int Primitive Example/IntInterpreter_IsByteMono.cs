using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntInterpreter_IsByteMono : AbstractGenericIntepreterMono<int>
{
    public override bool CanInterpreterUnderstand(in int shortcut)
    {
        return shortcut>-1 &&  shortcut <= byte.MaxValue;
    }

    public override void TryTranslate(out bool succedToTranslate, in int shortcut)
    {
        Debug.Log("Is byte "+shortcut);
        succedToTranslate = true;
    }
}
