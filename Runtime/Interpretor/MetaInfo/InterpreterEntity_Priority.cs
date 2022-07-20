using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script behind and Interpretor give him a priority in the translation queue. 0= In the first to check. Int.max= check interpretor in last if none interperted the message.
/// </summary>
public class InterpreterEntity_Priority :MonoBehaviour
{
    public int m_priorityValueInQueue=900;
    
}
