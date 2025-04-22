using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float sensitivity = 2.0f; // ความไวในการหมุนของกล้อง
    private Transform playerTransform;
    private float XRotate = 0f;
    private bool isInMainMenu = false;

    /*[Header("Camera Look")] 
    [SerializeField] private Transform lookTarget;
    [SerializeField] private float turnSpeed = 0.1f;
    private Quaternion rotGoal;
    private Vector3 direction;*/
    

    private void Start()
    {
        playerTransform = transform.parent; // รับ Transform ของผู้เล่น (สมมุติว่ากล้องอยู่ใน GameObject แม่ของผู้เล่น)
        Cursor.lockState = CursorLockMode.Locked; // ล็อกตำแหน่งเมาส์ที่ศูนย์กลาง
        Cursor.visible = false; // ซ่อนเมาส์
        isInMainMenu = false;
    }

    private void Update()
    {
        if (!isInMainMenu)
        {
            
            // รับค่าเมาส์แนวนอนและแนวตั้ง
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // หมุนกล้องตามการเคลื่อนที่ของเมาส์
            Vector3 rotation = transform.localEulerAngles;
            rotation.y += mouseX * sensitivity;
            XRotate -= mouseY * sensitivity;
            XRotate = Mathf.Clamp(XRotate, -90f, 90f);
            rotation.x = XRotate;
            transform.localRotation = Quaternion.Euler(rotation);

            // หมุนตัวละครตามการเคลื่อนที่ของเมาส์
            if (playerTransform != null)
            {
                Vector3 playerRotation = playerTransform.localEulerAngles;
                playerRotation.y += mouseX * sensitivity;
                // ปรับตัวละครให้หมุนทรงตัวตามการหมุนของกล้อง
                playerTransform.localEulerAngles = new Vector3(0f, playerRotation.y, 0f);
            }
            

            
            
        }
    }
    
    public void SetInMainMenu(bool inMainMenu)
    {
        isInMainMenu = inMainMenu;
    }

    /*public void LookAtTarget()
    {
        direction = (lookTarget.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal,turnSpeed);
    }*/
}
