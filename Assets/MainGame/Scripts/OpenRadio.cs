using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRadio : MonoBehaviour
{

    [SerializeField] private float maxPickupDistance = 5f;
    [SerializeField] private AudioSource radio;
    [SerializeField] private GameObject interact;
    private bool open = false;
    

    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxPickupDistance))
        {
            
            if (hit.transform.CompareTag("Radio") && !open)
            {
                interact.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    radio.enabled = true;
                     open = true;
                }
                
            }

            if (hit.transform.CompareTag("Radio") && open)
            {
                interact.SetActive(false);
            }
        }
        else
        {
            interact.SetActive(false);
        }
    }
}
