using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntInterpreter_42 : AbstractGenericIntepreterMono<int>
{
    public override bool CanInterpreterUnderstand(in int shortcut)
    {
        return shortcut == 42;
    }

    public override void TryTranslate(out bool succedToTranslate, in int shortcut)
    {
        Debug.Log("H2G2");
        succedToTranslate = true;
    }
}
