using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    [SerializeField] Material afternoon;
    [SerializeField] Material skyNight;
    [SerializeField] private AudioSource soundNight;
    [SerializeField] private AudioSource soundWood;
    private bool day;


    private void Start()
    {
        soundNight.Stop();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            if(!day)
            {
                DayTime();
            }
            else
            {
                NightTime();
            }
            
        }*/
    }

    public void AfternoonTime()
    {
        RenderSettings.skybox = afternoon;
        day = true;
        Debug.Log("Afternoon Time");
    }
    public void NightTime()
    {
        soundNight.Play();
        soundWood.Pause();
        RenderSettings.skybox = skyNight;
        RenderSettings.fog = true;
        day = false;
        Debug.Log("Night Time");
    }
}
