using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class GenericInterpreterAuctionHouseMonoWithCoroutine<T, Z> : GenericInterpreterAuctionHouseMono<T,Z> where T : I_Interpreter<Z> {

    public bool m_useCoroutineToFlushQueue;
    public float m_timebetweenFlush=0.01f;
    private bool m_keepAlive=true;
    private void Awake()
    {
        StartCoroutine(PushQueue());
    }
    private void OnDestroy()
    {
        m_keepAlive = false;
    }
    private IEnumerator PushQueue()
    {
        while (m_keepAlive) { 
        if (m_timebetweenFlush < 0.0001f)
            yield return new WaitForEndOfFrame();
        else 
            yield return new WaitForSeconds(m_timebetweenFlush);
            if (m_auction.GetQueueCount() > 0) {
                PushTheQueueToAuction();
            }
        }
    }

}


[System.Serializable]
public class GenericInterpreterAuctionHouseMono<T, Z> : MonoBehaviour where T : I_Interpreter<Z>
{
    public GenericInterpreterAuctionHouse<T, Z> m_auction = new GenericInterpreterAuctionHouse<T, Z>();
    public void AddToPushInNextBatch(in Z value)
    {
        m_auction.AddToPushInNextBatch(in value);
    }
    public void PushToAuction(in Z value)
    {
        m_auction.PushToAuction(in value);
    }
    public void PushTheQueueToAuction()
    {
        m_auction.PushTheQueueToAuction();
    }
    public void GetAllInterpretersFor(Z value, out bool found, out List<T> interpreters)
    {
        m_auction.GetAllInterpretersFor(value, out found, out interpreters);
    }
    public void GetFirstInterpreterFor(Z value, out bool found, out T interpreter)
    {

        m_auction.GetFirstInterpreterFor(value, out found, out interpreter);
    }
}


    [System.Serializable]
public class GenericInterpreterAuctionHouse<T,Z> where T : I_Interpreter<Z>
{

    public GenericInterpreterLoadedRegisterMono<T,Z> m_register;
    public GenericEvent m_received = new GenericEvent();
    public GenericEvent m_failToExecute = new GenericEvent();
    public GenericEvent m_exceptionHappened = new GenericEvent();
    public GenericEvent m_noInterpretor = new GenericEvent();
    public GenericEvent m_translated = new GenericEvent();

    [System.Serializable]
    public class GenericEvent : UnityEvent<Z> { }

    public Queue<Z> m_toPushWhenPossible = new Queue<Z>();


    public  int GetQueueCount()
    {
        return m_toPushWhenPossible.Count;
    }

    public void AddToPushInNextBatch(in Z value) {
        m_toPushWhenPossible.Enqueue(value);
    }

    public void PushTheQueueToAuction() {

        while (m_toPushWhenPossible.Count > 0) { 
            Z v = m_toPushWhenPossible.Dequeue();
            PushToAuction(v);
        }
    }
    public void PushToAuction(in Z value) {

        m_received.Invoke(value);
        T interpreter;
        List < GenericInterpreterPiorityEntry<T,Z>> sinter = m_register.GetInterpreters();
        for (int i = 0; i < sinter.Count; i++)
        {
            if (sinter[i] != null && sinter[i].IsDefined())
            {
                sinter[i].GetInterpreter(out interpreter);
                if (interpreter != null && interpreter.CanInterpreterUnderstand(value)) {
                    try
                    {
                       // Debug.Log("S: " + value.ToString() + "  I:"+ interpreter.GetInterpreterDescriptionName());
                        if (interpreter.TryTranslate(value))
                        {
                            m_translated.Invoke(value);
                        }
                        else { 
                            m_failToExecute.Invoke(value);
                        }
                        return;
                    }
                    catch (Exception e) {
                        Debug.Log("Exception in translation:"+ e.StackTrace);
                        m_exceptionHappened.Invoke(value);
                        return;
                    }
                }
            }
        }
        m_noInterpretor.Invoke(value);
    }
    public void GetAllInterpretersFor(Z shortcut, out bool found, out List<T> interpreters) 
    {
        T interpreter ;
        interpreters = new List<T>();
        List<GenericInterpreterPiorityEntry<T, Z>> sinter = m_register.GetInterpreters();
        for (int i = 0; i < sinter.Count; i++)
        {
            if (sinter[i] != null && sinter[i].IsDefined())
            {
                sinter[i].GetInterpreter(out interpreter);
                if (interpreter != null && interpreter.CanInterpreterUnderstand(shortcut))
                {
                    interpreters.Add(interpreter);
                }
            }
        }
        found = interpreters.Count>0;
    }
    private static T privateInterpreter;
    public void GetFirstInterpreterFor(Z shortcut, out bool found , out T interpreter)
    {

        List<GenericInterpreterPiorityEntry<T, Z>> sinter = m_register.GetInterpreters();
        for (int i = 0; i < sinter.Count; i++)
        {
            if (sinter[i] != null && sinter[i].IsDefined())
            {
                sinter[i].GetInterpreter(out interpreter);
                if (interpreter != null && interpreter.CanInterpreterUnderstand(shortcut))
                {
                    found = true;
                    return;
                }
            }
        }
        interpreter = privateInterpreter;
        found = false;
    }
}
