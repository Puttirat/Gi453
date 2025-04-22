using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject uiPanel; // ระบุ GameObject UI ที่ต้องการเปิด/ปิดที่นี่
    [SerializeField] private GameObject CameraMainRoom;
    [SerializeField] private GameObject _cameraRoom;
    [SerializeField] private float rangeRaycast = 5f;
    [SerializeField] private GameObject closeText;
    [Header("Sound")] 
    [SerializeField] private AudioSource noiseCom;
    [SerializeField] private AudioSource walk;
    [SerializeField] private AudioSource clickClose;
    [SerializeField] EscMenu menuGame;

    private bool openCom;
    

    private void Start()
    {
        uiPanel.SetActive(false);
        _cameraRoom.SetActive(false);
        noiseCom.Stop();
        openCom = false;
        menuGame = FindObjectOfType<EscMenu>();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rangeRaycast))
            {
                if (hit.collider.CompareTag("Computer") && !openCom)
                {

                    uiPanel.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 0;
                    _cameraRoom.SetActive(true);
                    CameraMainRoom.SetActive(false);
                    noiseCom.Play();
                    walk.enabled = false;
                    menuGame.enabled = false;
                    //openCom = true;
                }

            }
        }

        /*if (Input.GetKeyDown(KeyCode.Escape) && openCom)
        {
            
            uiPanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            _cameraRoom.SetActive(false);
            CameraMainRoom.SetActive(true);
            noiseCom.playOnAwake = false;
            noiseCom.Stop();
            walk.enabled = true;
            openCom = false;
            
        }*/
    }

    public void ToggleClickClose()
    {
        uiPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        _cameraRoom.SetActive(false);
        CameraMainRoom.SetActive(true);
        noiseCom.playOnAwake = false;
        noiseCom.Stop();
        walk.enabled = true;
        openCom = false;
        clickClose.Play(); 
        closeText.SetActive(false);
        if (menuGame != null)
        {
            menuGame.enabled = true;
        }




    }
    
}
