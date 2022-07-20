using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGenericIntepreter<T> : I_Interpreter<T>
{

    public string m_interpreterId = Guid.NewGuid().ToString();
    public string m_interpreterName = "Unnamed Interperter ";

    [ContextMenu("Generate new id")]
    public void GenerateNewId() { m_interpreterId = Guid.NewGuid().ToString(); }
    public void GetInterpreterDescriptionName(out string interpreterName) => interpreterName = m_interpreterName;
    public void GetInterpreterUniqueID(out string uniqueId) => uniqueId = m_interpreterId;

    public bool TryTranslate(in T value)
    {
        TryTranslate(out bool result, in value); 
        return result;
    }
    public abstract bool CanInterpreterUnderstand(in T value);
    public abstract void TryTranslate(out bool succedToTranslate, in T value);

    public string GetInterpreterDescriptionName()
    {
        return m_interpreterName;
    }

    public string GetInterpreterUniqueID()
    {
        return m_interpreterId;
    }
}


public abstract class AbstractGenericIntepreterMono<T> : MonoBehaviour, I_Interpreter<T>
{

    public string m_interpreterId = Guid.NewGuid().ToString();
public string m_interpreterName = "Unnamed Interperter ";

[ContextMenu("Generate new id")]
public void GenerateNewId()
{ m_interpreterId = Guid.NewGuid().ToString(); }
public void GetInterpreterDescriptionName(out string interpreterName) => interpreterName = m_interpreterName;
public void GetInterpreterUniqueID(out string uniqueId) => uniqueId = m_interpreterId;

public bool TryTranslate(in T value)
{
    TryTranslate(out bool result, in value);
    return result;
}
public abstract bool CanInterpreterUnderstand(in T value);
public abstract void TryTranslate(out bool succedToTranslate, in T value);

public string GetInterpreterDescriptionName()
{
    return m_interpreterName;
}

public string GetInterpreterUniqueID()
{
    return m_interpreterId;
}
}