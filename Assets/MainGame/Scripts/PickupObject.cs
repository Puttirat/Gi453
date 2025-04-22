using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private GameObject PickupText;
    


    private void Start()
    {
        flashlight.SetActive(false);
        PickupText.SetActive(false);
    }

    private void Update()
    {
        RaycastHit hitAuto;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitAuto, 5f))
        {
            if (hitAuto.transform.CompareTag("Flashlight"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    this.gameObject.SetActive(false);
                    flashlight.SetActive(true);
                    PickupText.SetActive(false);
                }
            }
            else
            {
                PickupText.SetActive(false);
            }
        }
        else
        {
            PickupText.SetActive(false);
        }
    }

    
}
