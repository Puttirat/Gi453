using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAndHide : MonoBehaviour
{
    [SerializeField] private float rayDistance = 20f;
    [SerializeField] private GameObject mysteriosMan;
    [SerializeField] private AudioClip scared;
    [SerializeField] private AudioSource manSource;
    [SerializeField] private GameObject carJumpscare;
    [SerializeField] private GameObject murderCar;
    [SerializeField] private AudioSource manCarSource;
    [SerializeField] private GameObject whatIs;
    [SerializeField] private GameObject JGJumpScare;
    
    
    void Update()
    {
        LookMan();
    }

    void LookMan()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayDistance))
        {
            if (hit.transform.CompareTag("MysteriosMan"))
            {
                manSource.PlayOneShot(scared);
                Destroy(hit.collider);
                StartCoroutine(ManHide());
            }

            if (hit.transform.CompareTag("MurderCar"))
            {
                manCarSource.PlayOneShot(scared);
                Destroy(hit.collider);
                StartCoroutine(CarScare());
            }
        }
    }

    IEnumerator ManHide()
    {
        JGJumpScare.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(mysteriosMan);
        whatIs.SetActive(true);
        JGJumpScare.SetActive(false);
    }
    
    IEnumerator CarScare()
    {
        
        carJumpscare.SetActive(true);
        yield return new WaitForSeconds(1);
        carJumpscare.SetActive(false);
        murderCar.SetActive(false);
        whatIs.SetActive(true);
        
    }
}
