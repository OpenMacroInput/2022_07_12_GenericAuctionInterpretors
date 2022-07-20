using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterpreterSW_ExactlyEqualsToActions : AbstractGenericIntepreterMono<IStringWrapperGet>
{
    public StringToActionsRegisterMono m_stringToActionRegister;
    public char[] m_starWith = { '=', '=' };
    public char[] m_endWith = { '=', '=' };
    public string m_lastReceived;
    public string m_lastReceivedNoId;
    public override bool CanInterpreterUnderstand(in IStringWrapperGet value)
    {

        if (m_stringToActionRegister == null)
            return false ;
        int l = value.Lenght();
        if (l <= m_starWith.Length+ m_endWith.Length)
            return false;
        for (int i = 0; i < m_starWith.Length; i++)
        {
            if (value.GetCharAt(i) != m_starWith[i])
                return false;
        }
        for (int i = 0; i < m_endWith.Length; i++)
        {
            if (value.GetCharAt((l-m_endWith.Length)+i) != m_endWith[i])
                return false;
        }
        return true;
    }

    public override void TryTranslate(out bool succedToTranslate, in IStringWrapperGet value)
    {
        m_lastReceived = value.GetString();
        string text = value.GetString().Substring(m_starWith.Length, value.GetString().Length - (m_starWith.Length+ m_endWith.Length));
        m_lastReceivedNoId = text;
        m_stringToActionRegister.Get(text, out bool found, out var itemFound);
        if (found)
        {
            if (itemFound.IsRequestingUnityThread())
                m_stringToActionRegister.ExecuteOnNextUpdate(in itemFound);
            else 
                itemFound.TriggerActions();
            succedToTranslate= true;
            return;
        }
        succedToTranslate= false;
    }
}
