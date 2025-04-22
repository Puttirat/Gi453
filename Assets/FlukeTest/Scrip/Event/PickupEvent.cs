using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEvent : MonoBehaviour
{
    public int id;

    public void HandlePickup()
    {
        // กำหนดข้อมูลเพิ่มเติมให้กับไอเทมตามความต้องการ
        GameEvent.current.EventTriggerEnter(id);

        Debug.Log("Item picked up");
    }
    public void DropItem()
    {
        GameEvent.current.EventTriggerExit(id);
        Debug.Log("Item drop");
    }
}
