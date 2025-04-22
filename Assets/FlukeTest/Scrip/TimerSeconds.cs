using UnityEngine;
using System.Collections;

public class TimerSeconds : MonoBehaviour
{
    public int id;
    public float countdownTime; // เวลาที่จะถอยหลัง
    public GameObject eventObject; // อ็อบเจกต์ที่จะเกิดเหตุการณ์

    private bool isInsideArea = false;
    private bool isTiming = false;
    private float startTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ให้เช็คหากผู้เล่นเข้ามาในพื้นที่
        {
            isInsideArea = true;
        }
    }

    private void Update()
    {
        // ตรวจสอบถ้าผู้เล่นยังอยู่ในพื้นที่และยังไม่ได้เริ่มจับเวลา
        if (isInsideArea && !isTiming)
        {
            StartTimer();
        }

        // ตรวจสอบถ้าเวลาถอยหลังหมดลงและเกิดเหตุการณ์
        if (isTiming && Time.time >= (startTime + countdownTime))
        {
            // เกิดเหตุการณ์
            if (eventObject != null)
            {
                eventObject.SendMessage("OnTimerComplete", SendMessageOptions.DontRequireReceiver);
            }
            Debug.Log("เหตุการณ์เกิดขึ้นหลังจากหมดเวลา!");
            GameEvent.current.EventTriggerEnter(id);
            // สามารถทำอะไรก็ตามที่คุณต้องการเมื่อเกิดเหตุการณ์

            // หยุดจับเวลา
            isTiming = false;
            isInsideArea = false;
        }
    }

    private void StartTimer()
    {
        isTiming = true;
        startTime = Time.time;
        Debug.Log("เริ่มจับเวลา");
    }
}
