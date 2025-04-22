using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    [SerializeField] private KeyCode closeKey;

    [Space(10)]
    [SerializeField] private PlayerMovement player;

    [Header("Note")]
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private Text noteTextUI;

    [Space(10)]
    [SerializeField] [TextArea] private string noteText;

    [Space(10)]
    [SerializeField] private UnityEvent openEvent;
    private bool isOpen = false;

    public void ShowNote()
    {
        noteTextUI.text = noteText;
        noteCanvas.SetActive(true);
        openEvent.Invoke();

        isOpen = true;
    }

    void DisableNote()
    {
        noteCanvas.SetActive(false);

        isOpen = false;
    }

    void DisablePlayer(bool disable)
    {
        player.enabled = !disable;
    }

    private void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(closeKey))
            {
                DisableNote();
            }
        }
    }
}
