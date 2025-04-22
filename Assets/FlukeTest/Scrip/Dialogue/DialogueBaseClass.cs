using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; protected set; }

        protected IEnumerator WriteText(string input, TMP_Text textHolder/*, Color textColor, Font textFont*/, float delay, float delayBetweenLines)
        {
            //textHolder.color = textColor;
            //textHolder.font = textFont;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];

                //yield return new WaitForSeconds(0.1f);
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(delayBetweenLines);
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            finished = true;
        }
    }
}
