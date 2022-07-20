using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjectAsCommandToInterpreterDemo : MonoBehaviour
{

    public ObjectAsCommandAuctionMono m_auctionHouse;
    public string m_whatToPushAsLog;
    public string m_warningMessage;
    public string m_erroMessage;
    public string m_jokeMessage;
    public enum LogType { Log, Warning, Error}
    public LogType m_logType;
   
    [ContextMenu("Push Log  in Queue")]
    public void PushInspectorValueInQueue()
    {
        if (m_logType == LogType.Log)
            m_auctionHouse.m_auction.AddToPushInNextBatch(new PointAtAbstractObjectAsCommand(new DisplayDebugLogInfo() { m_message = m_whatToPushAsLog })); ;
        if (m_logType == LogType.Warning)
            m_auctionHouse.m_auction.AddToPushInNextBatch(new PointAtAbstractObjectAsCommand(new DisplayDebugWarningInfo() { m_message = m_whatToPushAsLog , m_warningInfo= m_warningMessage })); ;
        if (m_logType == LogType.Error)
            m_auctionHouse.m_auction.AddToPushInNextBatch(new PointAtAbstractObjectAsCommand(new DisplayDebugErrorInfo() { m_message = m_whatToPushAsLog, m_errorInfo = m_erroMessage })); ;
    }

    [ContextMenu("Push Joke  in Queue")]
    public void PushJokeInQueue() {
        m_auctionHouse.m_auction.AddToPushInNextBatch(new JokeInfo(m_jokeMessage));
    }

    public class DisplayDebugLogInfo
    {
        public string m_message;
    }

    public class DisplayDebugWarningInfo
    {
        public string m_message;
        public string m_warningInfo;
    }
    public class DisplayDebugErrorInfo
    {
        public string m_message;
        public string m_errorInfo;
    }

    public class JokeInfo : IsAbstractObjectAsCommand {
        public string m_jokeMessage;

        public JokeInfo(string jokeMessage)
        {
            m_jokeMessage = jokeMessage;
        }
    }

}
