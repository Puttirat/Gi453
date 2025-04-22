using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    
    [SerializeField] GameObject itemToToggle; // ระบุรายการที่ต้องการเปิด/ปิดที่นี่
    private bool isItemActive = false;

    public void ToggleItem()
    {
        //isItemActive = !isItemActive;
        itemToToggle.SetActive(true);
        isItemActive = true;
    }
}
