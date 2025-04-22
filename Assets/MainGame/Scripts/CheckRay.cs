using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRay : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    [SerializeField] private float rangeRaycast = 7;
    [SerializeField] private GameObject Interac;



    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rangeRaycast))
        {bool hitGameObject = false;

            foreach (GameObject gameObjectToCheck in _gameObjects)
            {
                // กระทำที่ต้องการเมื่อ Ray ชนกับ GameObject ที่ต้องการ
                if (hit.collider.gameObject == gameObjectToCheck)
                {
                    Debug.Log("โดนชนกับ Object: " + gameObjectToCheck.name);
                    hitGameObject = true;
                    // มี GameObject ที่ต้องการ
                    break; // หยุดทำการตรวจสอบทันทีหลังจากพบ GameObject ที่ต้องการ
                }
            }

            if (hitGameObject)
            {
                // มี GameObject ที่ต้องการ, ทำตามที่ต้องการ เช่น
                Interac.SetActive(true);
            }
            else
            {
                // ไม่โดน GameObject ที่ต้องการ, ปิด Interac
                Interac.SetActive(false);
            }
            
           
        }
        else
        {
            // ถ้าไม่โดนอะไรเลย, ปิด Interac
            Interac.SetActive(false);
        }
    }
}
