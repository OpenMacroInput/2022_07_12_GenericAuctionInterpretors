using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushStringWrapperToInterpreterDemo : MonoBehaviour
{
    public StringWrapperInterpreterAuctionMono m_auctionHouse;
    public string m_whatToPush;
    [ContextMenu("Push Inspector Value")]
    public void PushInspectorValue()
    {
        m_auctionHouse.m_auction.PushToAuction(new StringWrapper(m_whatToPush));
    }

    [ContextMenu("Push Inspector Value in Queue")]
    public void PushInspectorValueInQueue()
    {
        m_auctionHouse.m_auction.AddToPushInNextBatch(new StringWrapper(m_whatToPush));
    }
}
