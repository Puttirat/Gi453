using DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("RayCast Features")]
    [SerializeField] private float rayLength = 5;
    private Camera _camera;

    private NoteController noteController;
    private NPC_Dialogue triggerdialogue;

    [Header("Input Key")]
    [SerializeField] private KeyCode interactKey;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f,0.5f)), transform.forward, out RaycastHit hit ,rayLength ))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            if (readableItem != null)
            {
                noteController = readableItem;
            }
            else
            {
                ClearNote();
            }
        }
        else
        {
            ClearNote();
        }

        if (noteController != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                noteController.ShowNote();
            }
        }
        //dialogue
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit check, rayLength))
        {
            var talkable = check.collider.GetComponent<NPC_Dialogue>();
            if (talkable != null)
            {
                triggerdialogue = talkable;
            }
            else
            {
                ClearDialogue();
            }
        }
        else
        {
            ClearDialogue();
        }

        if (triggerdialogue != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                triggerdialogue.ActiveDialogue();
            }
        }
    }

    void ClearNote()
    {
        if(noteController != null)
        {
            noteController = null;
        }
    }
    void ClearDialogue()
    {
        if (triggerdialogue != null)
        {
            triggerdialogue = null;
        }
    }
}
