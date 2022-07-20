using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObjectInterpret_DisplayLog : AbstractGenericIntepreterMono<IAbstractObjectCommandToInterpret>
{
    public override bool CanInterpreterUnderstand(in IAbstractObjectCommandToInterpret value)
    {
        value.GetTypeOfClass(out System.Type t);
        if (t == typeof(PushObjectAsCommandToInterpreterDemo.DisplayDebugLogInfo))
        {
            return true;
        }
        if (t == typeof(PushObjectAsCommandToInterpreterDemo.DisplayDebugWarningInfo))
        {
            return true;
        }
        if (t == typeof(PushObjectAsCommandToInterpreterDemo.DisplayDebugErrorInfo))
        {
            return true;
        }
        return false;       
    }
    public override void TryTranslate(out bool succedToTranslate, in IAbstractObjectCommandToInterpret value)
    {
        value.GetTypeOfClass(out System.Type t);
        if (t == typeof(PushObjectAsCommandToInterpreterDemo.DisplayDebugLogInfo))
        {
            PushObjectAsCommandToInterpreterDemo.DisplayDebugLogInfo l = value.GetCastOfTheObjectAs<PushObjectAsCommandToInterpreterDemo.DisplayDebugLogInfo>();
            Debug.Log(l.m_message);
            succedToTranslate = true;
        }
        else if (t == typeof(PushObjectAsCommandToInterpreterDemo.DisplayDebugWarningInfo))
        {
            PushObjectAsCommandToInterpreterDemo.DisplayDebugWarningInfo l = value.GetCastOfTheObjectAs<PushObjectAsCommandToInterpreterDemo.DisplayDebugWarningInfo>();
            Debug.LogWarning(l.m_warningInfo + "\nFor| " + l.m_message);
            succedToTranslate = true;
        }
        else if (t == typeof(PushObjectAsCommandToInterpreterDemo.DisplayDebugErrorInfo))
        {
            PushObjectAsCommandToInterpreterDemo.DisplayDebugErrorInfo l = value.GetCastOfTheObjectAs<PushObjectAsCommandToInterpreterDemo.DisplayDebugErrorInfo>();
            Debug.LogWarning("ERROR:" + l.m_errorInfo + "\nFor| " + l.m_message);
            succedToTranslate = true;
        }
        else succedToTranslate = false;
    }
}
