using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntInterpreter_UnderZeroMono : AbstractGenericIntepreterMono<int>
{
    public override bool CanInterpreterUnderstand(in int shortcut)
{
    return shortcut < 0;
}

public override void TryTranslate(out bool succedToTranslate, in int value)
{
    Debug.Log("Negative Number "+ value);
    succedToTranslate = true;
}
}
