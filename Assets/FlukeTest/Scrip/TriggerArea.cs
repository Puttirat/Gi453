using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField]private int id;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบถ้าเป็น Collider ของ Player
        {
            GameEvent.current.EventTriggerEnter(id); // เรียกใช้งานอีเว้นเมื่อ Player เข้ามาใน Collider
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameEvent.current.EventTriggerExit(id);
        }
    }
}
