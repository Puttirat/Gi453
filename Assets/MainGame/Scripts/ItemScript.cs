using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private float maxPickupDistance = 5;
    private GameObject itemCurrentlyHolding;
    private bool isHolding = false;
    [SerializeField] private GameObject chair;
    [SerializeField] private GameObject chair2;
    [SerializeField] private GameObject chairClone;
    [SerializeField] private GameObject chairClone2;
    [SerializeField] private GameObject openText;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject chairCar;
    
    

    [Header("Sound")] 
    [SerializeField] private AudioClip pickChair;

    private bool area1 = false;
    private bool area2 = false;


    private void Start()
    {
        chair.SetActive(false);
        chair2.SetActive(false);
        chairClone.SetActive(false);
        chairClone2.SetActive(false);
        openText.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
            
            //Drop();
        }

        /*if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }*/
        
        CheckText();
    }

    void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward,out hit, maxPickupDistance))
        {
            if (hit.transform.tag == "Item" && !isHolding)
            {
                itemCurrentlyHolding = hit.transform.gameObject;

                foreach (var c in hit.transform.GetComponentsInChildren<Collider>())
                    if (c != null)
                        c.enabled = false;

                foreach (var r in hit.transform.GetComponentsInChildren<Rigidbody>())
                    if (r != null)
                        r.isKinematic = true;

                itemCurrentlyHolding.transform.parent = transform;
                itemCurrentlyHolding.transform.localPosition = Vector3.zero;
                itemCurrentlyHolding.transform.localEulerAngles = Vector3.zero;

                isHolding = true;
                //chairClone.SetActive(true);
                //chairClone2.SetActive(true);
                GetComponent<AudioSource>().PlayOneShot(pickChair);
                if (!area1)
                {
                    chairClone.SetActive(true);
                    
                }

                if (!area2)
                {
                    chairClone2.SetActive(true);
                    
                }

            }

            if (hit.transform.tag == "Area" && isHolding)
            {
                Destroy(itemCurrentlyHolding);
                //Destroy(hit.transform.gameObject);
                chairClone.SetActive(false);
                chairClone2.SetActive(false);
                isHolding = false;
                chair.SetActive(true);
                area1 = true;
                StartCoroutine(Dialogue());
                
                

            }
            
            if (hit.transform.tag == "Area2" && isHolding)
            {
                Destroy(itemCurrentlyHolding);
                //Destroy(hit.transform.gameObject);
                chairClone2.SetActive(false);
                chairClone.SetActive(false);
                chair2.SetActive(true);
                isHolding = false;
                area2 = true;
                StartCoroutine(Dialogue());
                

            }
            
            
        }
        
    }

    void CheckText()
    {
        RaycastHit hitRay;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitRay, maxPickupDistance))
        {
            if (hitRay.transform.tag == "Area2" && isHolding)
            {
                openText.SetActive(true);
            }
            else if (hitRay.transform.tag == "Area" && isHolding)
            {
                openText.SetActive(true);
            }

            else
            {
                openText.SetActive(false);
            }
            
        }
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1);
        if (chairCar != null && !ReferenceEquals(chairCar, null))
        {
            if (chairCar.activeSelf)
            {
                dialogue.SetActive(true);
            }
            
        }
        
        
    }

    /*void Drop()
    {
        itemCurrentlyHolding.transform.parent = null;
        foreach (var c in itemCurrentlyHolding.transform.GetComponentsInChildren<Collider>())
            if (c != null)
                c.enabled = true;
                

        foreach (var r in itemCurrentlyHolding.transform.GetComponentsInChildren<Rigidbody>())
            if (r != null)
                r.isKinematic = false;

        isHolding = false;
        RaycastHit hitDown;
        Physics.Raycast(transform.position, -Vector3.up, out hitDown);

        itemCurrentlyHolding.transform.position =
            hitDown.point + new Vector3(transform.forward.x, 0, transform.forward.z);
        Destroy(chair);
        
    }*/

    /*public void Drop()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward,out hit, maxPickupDistance))
        {
            if (hit.transform.tag == "Area" && isHolding)
            {
                Destroy(chairClone);
                
            }
        }
    }*/
}
