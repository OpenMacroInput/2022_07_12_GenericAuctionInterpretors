using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringWrapperInterpreterAuctionDebugMono : MonoBehaviour
{
    public StringWrapperInterpreterAuctionMono m_target;


    public string m_exceptionHappened;
    public string m_failToExecute;
    public string m_noInterpretor;
    public string m_received;
    public string m_translated;

    public void Awake()
    {
        m_target.m_auction.m_exceptionHappened.AddListener(ExceptionHappened);
        m_target.m_auction.m_failToExecute.AddListener(FailToExecute);
        m_target.m_auction.m_noInterpretor.AddListener(NoInterpreter);
        m_target.m_auction.m_received.AddListener(Received);
        m_target.m_auction.m_translated.AddListener(Translated);
    }
    public void OnDestroy()
    {
        m_target.m_auction.m_exceptionHappened.RemoveListener(ExceptionHappened);
        m_target.m_auction.m_failToExecute.RemoveListener(FailToExecute);
        m_target.m_auction.m_noInterpretor.RemoveListener(NoInterpreter);
        m_target.m_auction.m_received.RemoveListener(Received);
        m_target.m_auction.m_translated.RemoveListener(Translated);
    }

    private void Translated(IStringWrapperGet arg0) => m_translated = arg0.GetString();
    private void Received(IStringWrapperGet arg0) => m_received = arg0.GetString();
    private void NoInterpreter(IStringWrapperGet arg0) => m_noInterpretor = arg0.GetString();
    private void FailToExecute(IStringWrapperGet arg0) => m_failToExecute = arg0.GetString();
    private void ExceptionHappened(IStringWrapperGet arg0) => m_exceptionHappened = arg0.GetString();
}
