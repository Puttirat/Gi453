using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDoor : MonoBehaviour
{
    [SerializeField] private GameObject lookDoor;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraCutScene;
    [SerializeField] private GameObject closeText;
    [SerializeField] private GameObject closeCheckTag;


    public void ToggleDoor()
    {
        StartCoroutine(CutSceneDoor());
    }

    IEnumerator CutSceneDoor()
    {
        lookDoor.SetActive(true);
        player.SetActive(false);
        cameraCutScene.SetActive(true);
        closeText.SetActive(false);
        yield return new WaitForSeconds(4);
        lookDoor.SetActive(false);
        player.SetActive(true); 
        cameraCutScene.SetActive(false);
        
        
        
    }
    
}
