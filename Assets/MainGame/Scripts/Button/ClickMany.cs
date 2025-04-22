using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMany : MonoBehaviour
{
    private bool isClicked = false;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioSource click;

    public void Close()
    {
        if (!isClicked)
        {
            //GetComponent<AudioSource>().PlayOneShot(clickSound);
            GetComponent<Button>().interactable = true;
            isClicked = false;
            click.PlayOneShot(clickSound);
        }  
    }
}
