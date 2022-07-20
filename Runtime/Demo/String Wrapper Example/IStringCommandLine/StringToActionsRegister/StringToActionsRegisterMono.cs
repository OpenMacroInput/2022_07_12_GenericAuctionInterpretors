using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringToActionsRegisterMono : MonoBehaviour
{

    [System.Serializable]
    public class StringToAction
    {
        public string m_stringToCheck;
        public bool m_useTrim=true;
        public bool m_useLowerCase=true;
        public UnityEvent m_toDo;
        public bool m_executeOnUnityThread;

        string m_stringWithModification;
        public void ApplyModificator() {
            m_stringWithModification = m_stringToCheck;
            if (m_useTrim)
                m_stringWithModification = m_stringWithModification.Trim();
            if (m_useLowerCase)
                m_stringWithModification = m_stringWithModification.ToLower();
        }
        public bool AreSame(in string text) {
            if (!m_useTrim && !m_useLowerCase)
                return m_stringToCheck == text;
            string s = text;
            if (m_useTrim)
                s = s.Trim();
            if (m_useLowerCase)
                s = s.ToLower();
            return m_stringWithModification == s;
        }
        public void TriggerActions() {
            m_toDo.Invoke();
        }

        public bool IsRequestingUnityThread() {
            return m_executeOnUnityThread;
        
        }
    }

    public List<StringToAction> m_actions = new List<StringToAction>();
    public List<StringToAction> m_actionsInUpdateQueue = new List<StringToAction>();

    public void Awake()
    {
        for (int i = 0; i < m_actions.Count; i++)
        {
            if (m_actions[i] != null)
            {
                m_actions[i].ApplyModificator();
            }
        }
    }

    public void Get(in string text, out bool found, out StringToAction value) {
        for (int i = 0; i < m_actions.Count; i++)
        {
            if (m_actions[i] != null && m_actions[i].AreSame(in text)) {
                found = true;
                value= m_actions[i];
                return;
            }
        }
        found = false;
        value = null;
    }
    public void ExecuteOnNextUpdate(in StringToAction action) {
        m_actionsInUpdateQueue.Insert(0,action);
    }
    public void Update()
    {
        for (int i = m_actionsInUpdateQueue.Count-1; i > -1; i--)
        {
            if (m_actionsInUpdateQueue[i]!=null)
                m_actionsInUpdateQueue[i].TriggerActions();
            m_actionsInUpdateQueue.RemoveAt(i);
        }
    }
}
