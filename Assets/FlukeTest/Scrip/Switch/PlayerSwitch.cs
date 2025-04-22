using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public PlayerMovement playerController;
    public PlayerMovement player2Controller;
    public bool player1Active = true;
    public SwitchCamera switchCamera;

    void Start()
    {
        playerController.enabled = true;
        player2Controller.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        if(player1Active)
        {
            playerController.enabled = false;
            player2Controller.enabled = true;
            player1Active = false;
        }
        else
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            player1Active = true;
        }
        switchCamera.ManagerCamera();
    }
}
