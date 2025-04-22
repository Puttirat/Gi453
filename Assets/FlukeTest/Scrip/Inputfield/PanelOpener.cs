using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
    public InputField inputField;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ตรวจสอบว่าผู้เล่นคลิกปุ่มเมาส์ (หรือใช้ Input อื่นๆ ตามความต้องการ)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // ตรวจสอบว่า Raycast ชนกับ GameObject ที่มี Collider ที่เป็นตัวกระตุ้น
                if (hit.collider.isTrigger)
                {
                    if (panel != null)
                    {
                        bool isActive = panel.activeSelf;
                        panel.SetActive(!isActive);

                        // ตรวจสอบว่า Panel ถูกเปิดขึ้นมาหรือไม่
                        if (!isActive && inputField != null)
                        {
                            inputField.Select(); // ทำให้ Input Field มีการโฟกัส
                        }
                    }
                }
            }
        }
    }
}
