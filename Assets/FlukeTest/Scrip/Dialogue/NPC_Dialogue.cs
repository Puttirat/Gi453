using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    [SerializeField]private GameObject dialogue;

    public void ActiveDialogue()
    {
        dialogue.SetActive(true);
    }
    public bool dialogueActive()
    {
        return dialogue.activeInHierarchy;
    }
}
