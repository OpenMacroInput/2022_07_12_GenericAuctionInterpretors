using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGenericInterpetersInSceneMono<I,V>  : MonoBehaviour where I : I_Interpreter<V> { 
    public GenericInterpreterLoadedRegisterMono<I,V> m_register;
    public List<MonoGenericInterpreterPiorityEntry<V>> m_interpretersInScene; 
    
    public void Awake()
    {
        foreach (var item in m_interpretersInScene)
        {
            item.Get(out I_Interpreter<V> interpreter);
            int priority = item.m_priorityPoint;
            InterpreterEntity_Priority p = item.m_interpretorInScene.GetComponent<InterpreterEntity_Priority>();
            if (p != null)
                priority = p.m_priorityValueInQueue;
            m_register.AddInterpreter(priority, item.m_isActive, (I) interpreter);
        }
        m_register.RemoveDoubleThenSort();
    }
}

[System.Serializable]
public class MonoGenericInterpreterPiorityEntry<V>
{
    public int m_priorityPoint = 500;
    public bool m_isActive = true;
    public MonoBehaviour m_interpretorInScene;
    public void Get(out I_IntepreterNameAndId nameId) { nameId = m_interpretorInScene.GetComponent< I_IntepreterNameAndId >(); }
    public void Get(out I_Interpreter<V> interpreter ) { interpreter = m_interpretorInScene.GetComponent< I_Interpreter<V> >(); }
    public bool HasInterfaces()
    {
        Get(out I_IntepreterNameAndId nameId);
        Get(out I_Interpreter<V> interpreter);
        return nameId != null && interpreter != null;
    }
    
}
