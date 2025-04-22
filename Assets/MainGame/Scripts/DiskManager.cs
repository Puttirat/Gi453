using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskManager : MonoBehaviour
{
    [Header("DiskUi")]
    [SerializeField] private GameObject doorUI;
    [SerializeField] private GameObject lighterUI;
    [SerializeField] private GameObject flashlightUI;
    [SerializeField] private GameObject bookshelfUI;
    [SerializeField] private GameObject deerUI;


    [Header("Disk")]
    [SerializeField] private GameObject doorDisk;
    [SerializeField] private GameObject lighterDisk;
    [SerializeField] private GameObject flashlightDisk;
    [SerializeField] private GameObject bookshelfDisk;
    [SerializeField] private GameObject deerDisk;
    
    [Header("Sound")] 
    [SerializeField] private AudioClip pickDisk;
    [SerializeField] private float rangeRaycast = 7f;
    
    
    void Start()
    {
        doorUI.SetActive(false);
        lighterUI.SetActive(false);
        flashlightUI.SetActive(false);
        doorDisk.SetActive(false);
        lighterDisk.SetActive(false);
        flashlightDisk.SetActive(false);
        bookshelfUI.SetActive(false);
        bookshelfDisk.SetActive(false);
        deerUI.SetActive(false);
        deerDisk.SetActive(false);
            
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rangeRaycast))
            {
                if (hit.transform.CompareTag("DiskDoor"))
                {
                    doorUI.SetActive(true);
                    doorDisk.SetActive(true);
                    GetComponent<AudioSource>().PlayOneShot(pickDisk);
                    Destroy(hit.transform.gameObject);
                }
                
                if (hit.transform.CompareTag("DiskFlashlight"))
                {
                    flashlightUI.SetActive(true);
                    flashlightDisk.SetActive(true);
                    GetComponent<AudioSource>().PlayOneShot(pickDisk);
                    Destroy(hit.transform.gameObject);
                }
                
                if (hit.transform.CompareTag("DiskLighter"))
                {
                    lighterUI.SetActive(true);
                    lighterDisk.SetActive(true);
                    GetComponent<AudioSource>().PlayOneShot(pickDisk);
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.CompareTag("DiskBookShelf"))
                {
                    bookshelfDisk.SetActive(true);
                    bookshelfUI.SetActive(true);
                    GetComponent<AudioSource>().PlayOneShot(pickDisk);
                    Destroy(hit.transform.gameObject);
                }
                
                if (hit.transform.CompareTag("DiskDeer"))
                {
                    deerDisk.SetActive(true);
                    deerUI.SetActive(true);
                    GetComponent<AudioSource>().PlayOneShot(pickDisk);
                    Destroy(hit.transform.gameObject);
                }

                

            }
        }
        
    }
}
