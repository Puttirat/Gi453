using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    private bool isClicked = false;
    [SerializeField] private AudioClip clickSound;

    public void ToggleClick()
    {
        if (!isClicked)
        {
            GetComponent<AudioSource>().PlayOneShot(clickSound);
            GetComponent<Button>().interactable = false;
            isClicked = true;
        }  
    }
}
