using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAllGenericInterpetersInResourcesFolderMono<T,Z> : MonoBehaviour where T: I_Interpreter<Z>
{


    public GenericInterpreterLoadedRegisterMono<T, Z> m_register;
    public string m_relativePathFolder= "OMI/Interpreter";
    public int m_defaultPriority = 400;
    public Transform m_parent;

    public bool m_loadAtAwake=true;
    private void Awake()
    {
        if (m_loadAtAwake)
            LoadAllPrefabInterpreterinResources();
    }

    public void LoadAllPrefabInterpreterinResources() {
        GameObject[] prefabs = Resources.LoadAll<GameObject>(m_relativePathFolder);
        for (int i = 0; i < prefabs.Length; i++)
        {
            T inter = prefabs[i].GetComponentInChildren<T>();
            if (inter!=null) {
                inter.GetInterpreterUniqueID(out string id);
                inter.GetInterpreterDescriptionName(out string name);
                    GameObject g = GameObject.Instantiate(prefabs[i]);
                inter = g.GetComponentInChildren<T>();
                int priority = m_defaultPriority;

                    InterpreterEntity_Priority p = prefabs[i].GetComponentInChildren<InterpreterEntity_Priority>();
                    if (p)priority = p.m_priorityValueInQueue;  
                    m_register.AddInterpreter(priority, true, inter);
                    g.transform.parent = m_parent;
                    g.name = "Short Interpreter|"+ name + "|" + id;
                    
                
            }
        }
    }
}
