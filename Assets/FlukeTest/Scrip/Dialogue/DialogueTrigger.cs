using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    [Header("Input Key")]
    [SerializeField] private KeyCode interact;

    public Dialogue dialogue;
    private bool talk = false;

    [Header("UI")]
    public GameObject dialogueCanva;
    public Text nametext;
    public Text dialogueText;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void TriggerDialogue()
    {
        StartDialogue(dialogue);
    }
    private void Update()
    {
        if (talk == true)
        {
            if (Input.GetKeyDown(interact))
            {
                DisplayNextSentence();
            }
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {

        dialogueCanva.SetActive(true);
        talk = true;
        Debug.Log("Starting conversation with" + dialogue.name);

        nametext.text = dialogue.name;

        sentences.Clear();

        foreach (string sectences in dialogue.senences)
        {
            sentences.Enqueue(sectences);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log("sentence");
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        talk = false;
        dialogueCanva.SetActive(false);
    }
}
