using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TMP_Text textHolder;
        [Header("Text Options")]
        [SerializeField] private string input;
        //[SerializeField] private Color textColor;
        //[SerializeField] private Font textFont;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        private IEnumerator lineAppear;

        private void Awake()
        {
            textHolder= GetComponent<TMP_Text>();
            textHolder.text = "";
            //StartCoroutine(WriteText(input, textHolder/*, textColor, textFont*/, delay));
        }
        private void OnEnable()
        {
            ResetLine();
            lineAppear = WriteText(input, textHolder/*, textColor, textFont*/, delay, delayBetweenLines);
            StartCoroutine(lineAppear);
        }
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if(textHolder.text != input)
                {
                    textHolder.text = input;
                    StopCoroutine(lineAppear);
                }
                else
                {
                    finished = true;
                }
            }
        }
        private void ResetLine()
        {
            textHolder = GetComponent<TMP_Text>();
            textHolder.text = "";
            finished = false;
        }
    }
}
