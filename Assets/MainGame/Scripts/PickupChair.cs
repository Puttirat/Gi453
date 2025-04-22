using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupChair : MonoBehaviour
{
    [SerializeField] private GameObject Chair;
    //[SerializeField] private GameObject PickupText;
    


    private void Start()
    {
        Chair.SetActive(false);
       // PickupText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //PickupText.SetActive(true);
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                Chair.SetActive(true);
                //PickupText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //PickupText.SetActive(false);
    }
}
