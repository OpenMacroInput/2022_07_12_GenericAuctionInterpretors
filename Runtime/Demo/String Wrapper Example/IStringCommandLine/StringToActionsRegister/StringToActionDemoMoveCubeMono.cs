using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringToActionDemoMoveCubeMono : MonoBehaviour
{
    public Transform m_target;
    public float m_distance = 1;

    public void MoveLeft() { m_target.Translate(Vector3.left * m_distance, Space.Self); }
    public void MoveRight() { m_target.Translate(Vector3.right * m_distance, Space.Self); }
    public void MoveForward() { m_target.Translate(Vector3.forward * m_distance, Space.Self); }
    public void MoveBackward() { m_target.Translate(Vector3.back * m_distance, Space.Self); }
}
