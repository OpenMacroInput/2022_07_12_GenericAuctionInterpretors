using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GenericInterpreterLoadedRegisterMono<I,V> : MonoBehaviour where I : I_Interpreter<V>
{

    public List<GenericInterpreterPiorityEntry<I,V>> m_interpretersUse= new List<GenericInterpreterPiorityEntry<I, V>>();
    public UnityEvent m_onInterpreterAdded;

    public void RemoveDoubleThenSort()
    {
        RemoveDouble();
        SortByPriorityPoints_0Hightest();
    }

    public void RemoveDouble()
    {
        m_interpretersUse = m_interpretersUse.GroupBy(x => x.m_interpretorLinked.GetInterpreterUniqueID()).Select(y => y.First()).ToList();
    }

    public List<GenericInterpreterPiorityEntry<I, V>> GetInterpreters() { return m_interpretersUse; }
    public void SortByPriorityPoints_0Hightest()
    {
        m_interpretersUse = m_interpretersUse.OrderBy(k=>k.m_priorityPoint).ToList();
    }


    public void AddInterpreter(int priorityPoint, bool isActivebyDefault, I shortcutInScene) {
        m_interpretersUse.Add(new GenericInterpreterPiorityEntry<I, V>(priorityPoint, isActivebyDefault, shortcutInScene));
        RemoveDoubleThenSort();
        m_onInterpreterAdded.Invoke();
    }

}


[System.Serializable]
public class GenericInterpreterPiorityEntry<I,V> where I: I_Interpreter<V>
{

    public string m_interpretName;
    public string m_interpretID;
    public int m_priorityPoint = 500;
    public bool m_isActive = true;
    public I m_interpretorLinked;
    public bool IsDefined() { return m_interpretorLinked != null; }
    public bool IsMonoInterpreter() { return m_interpretorLinked is MonoBehaviour; }

    public void GetInterpreter(out I interpreter)
    {
        interpreter = m_interpretorLinked;
    }
    public I GetInterpreter(){  return  m_interpretorLinked;  }

    public GenericInterpreterPiorityEntry(int priorityPoint, bool isActivebyDefault, I shortcutInScene)
    {
        m_priorityPoint = priorityPoint;
        m_isActive = isActivebyDefault;
        m_interpretorLinked = shortcutInScene;
        m_interpretorLinked.GetInterpreterDescriptionName(out m_interpretName);
        m_interpretorLinked.GetInterpreterUniqueID(out m_interpretID);
    }
}
