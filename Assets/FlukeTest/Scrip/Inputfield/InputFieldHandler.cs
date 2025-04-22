using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InputFieldHandler : MonoBehaviour
{
    public InputField inputField;
    public string targetText = "TargetText"; // ข้อความที่คุณต้องการให้ Input Field ตรง

    public UnityEvent onTextMatch; // Event ที่จะเกิดขึ้นเมื่อข้อความตรงกับ targetText

    private void Start()
    {
        // เชื่อมโยงฟังก์ชัน HandleEndEdit() เข้ากับอีเวนต์ onEndEdit ของ Input Field
        inputField.onEndEdit.AddListener(HandleEndEdit);
    }

    // ฟังก์ชันที่เรียกเมื่อผู้เล่นป้อนข้อความและกด Enter (หรืออื่น ๆ ตามการกำหนด)
    private void HandleEndEdit(string userInput)
    {
        if (userInput == targetText)
        {
            // เมื่อข้อความตรงกับ targetText
            // เรียกเหตุการณ์ onTextMatch
            onTextMatch.Invoke();
        }
    }
}
