using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushIntToInterpretorDemo : MonoBehaviour
{
    public IntInterpreterAuctionHouseMono m_auctionHouse;
    public int m_whatToPush;
    [ContextMenu("Push Inspector Value")]
    public void PushInspectorValue()
    {
        m_auctionHouse.m_auction.PushToAuction(m_whatToPush);
    }

    [ContextMenu("Push Inspector Value in Queue")]
    public void PushInspectorValueInQueue()
    {
        m_auctionHouse.m_auction.AddToPushInNextBatch(m_whatToPush);
    }
}
