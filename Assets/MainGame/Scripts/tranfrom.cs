using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tranfrom : MonoBehaviour
{
    public Transform objectToMove;  // กำหนดวัตถุที่จะถูกย้าย
    public Transform targetPosition; // กำหนดตำแหน่งที่ต้องการวางวัตถุ

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ตรวจสอบว่ากดปุ่ม Space
        {
            MoveObjectToTargetPosition(); // เรียกใช้ฟังก์ชันเพื่อย้ายวัตถุ
        }
    }

    void MoveObjectToTargetPosition()
    {
        objectToMove.position = targetPosition.position; // ย้ายวัตถุไปยังตำแหน่งที่กำหนด
    }
}
