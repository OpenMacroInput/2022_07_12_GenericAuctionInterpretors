using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_InterpreterHolder<T, Y> where T : I_Interpreter<Y>
{
    T GetInterpreter();
    bool IsInterpreterDefined();
}
public interface I_IntepreterNameAndId {
    public void GetInterpreterDescriptionName(out string interpretorName);
    public string GetInterpreterDescriptionName();
    public void GetInterpreterUniqueID(out string uniqueId);
    public string GetInterpreterUniqueID();
}
public interface I_Interpreter<T> : I_IntepreterNameAndId
{
 
    public bool CanInterpreterUnderstand(in T value);
    public void TryTranslate(out bool succedToTransmit, in T value);
    public bool TryTranslate(in T value);
}