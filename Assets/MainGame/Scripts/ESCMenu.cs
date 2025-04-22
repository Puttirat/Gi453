using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] Button goToMainMenuButton;
    [SerializeField] Button quitGameButton;
    [SerializeField] private GameObject menuGame;
    
    
    [SerializeField] private AudioSource walk;
    [SerializeField] private AudioSource walk2;
    [SerializeField] private AudioSource walk3;
    [SerializeField] private AudioClip click;
    [Header("PlayerControllers")]
    /*[SerializeField] PlayerMovement playerControllers;
    [SerializeField] PlayerMovement playerControllers2;
    [SerializeField] PlayerMovement playerControllers3;
    [Header("Camera Player")]
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] CameraFollow cameraFollow2;
    [SerializeField] CameraFollow cameraFollow3;*/
    [SerializeField] List<PlayerMovement> playerControllers;
    [SerializeField] List<CameraFollow> cameraFollows;

    

    void Start()
    {
        // เชื่อมต่อปุ่มกับฟังก์ชันที่ต้องการ
        continueButton.onClick.AddListener(ContinueGame);
        goToMainMenuButton.onClick.AddListener(GoToMainMenu);
        quitGameButton.onClick.AddListener(QuitGame);
        playerControllers = FindObjectsOfType<PlayerMovement>().ToList();
        cameraFollows = FindObjectsOfType<CameraFollow>().ToList();
        
    }

    private void Update()
    {
        
        if (menuGame.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuGame.SetActive(false);
                Time.timeScale = 1; 
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                walk.enabled = true;
                walk2.enabled = true;
                walk3.enabled = true;
                foreach (var playerController in playerControllers)
                {
                    // ทำสิ่งที่คุณต้องการกับแต่ละ PlayerMovement
                    playerController.enabled = true;
                }
                foreach (var camera in cameraFollows)
                {
                    // ทำสิ่งที่คุณต้องการกับแต่ละ PlayerMovement
                    camera.enabled = true;
                }
                
            }
        }
        else if (!menuGame.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuGame.SetActive(true);
                Time.timeScale = 0f; 
                Cursor.visible = true;
                walk.enabled = false;
                walk2.enabled = false;
                walk3.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                foreach (var playerController in playerControllers)
                {
                    // ทำสิ่งที่คุณต้องการกับแต่ละ PlayerMovement
                    playerController.enabled = false;
                }
                foreach (var camera in cameraFollows)
                {
                    // ทำสิ่งที่คุณต้องการกับแต่ละ PlayerMovement
                    camera.enabled = false;
                }

                
            }
        }
    }

    void ContinueGame()
    {
        // โค้ดสำหรับเล่นต่อ
        // ตัวอย่าง: ปิดหน้าเมนู ESC
        menuGame.SetActive(false);
        Time.timeScale = 1f; // เปลี่ยนค่า Time.timeScale เพื่อเริ่มเกมใหม่
        Cursor.visible = false;
        walk.enabled = true;
        walk2.enabled = true;
        walk3.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<AudioSource>().PlayOneShot(click);
        foreach (var playerController in playerControllers)
        {
            // ทำสิ่งที่คุณต้องการกับแต่ละ PlayerMovement
            playerController.enabled = true;
        }
        foreach (var camera in cameraFollows)
        {
            // ทำสิ่งที่คุณต้องการกับแต่ละ PlayerMovement
            camera.enabled = true;
        }

    }

    void GoToMainMenu()
    {
        // โค้ดสำหรับไปที่หน้าเข้าเกมหลัก
        SceneManager.LoadScene(0); // แทน "MainMenuScene" ด้วยชื่อ Scene หลักของคุณ
        Time.timeScale = 1f;
        GetComponent<AudioSource>().PlayOneShot(click);
    }
    
    

    void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
             Application.Quit();
        #endif
        GetComponent<AudioSource>().PlayOneShot(click);
    }
}