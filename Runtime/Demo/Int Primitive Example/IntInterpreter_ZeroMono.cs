using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntInterpreter_ZeroMono : AbstractGenericIntepreterMono<int>
{
    public override bool CanInterpreterUnderstand(in int shortcut)
    {
        return shortcut == 0;
    }

    public override void TryTranslate(out bool succedToTranslate, in int shortcut)
    {
        Debug.Log("Zeroooooo !!!");
        succedToTranslate = true;
    }
}
