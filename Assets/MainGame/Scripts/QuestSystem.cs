using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // เพิ่มไลบรารีนี้เพื่อใช้งาน UI

public class QuestSystem : MonoBehaviour
{
    public int requiredItemCount = 5;
    private int currentItemCount = 0;
    private bool questCompleted = false;
    public GameObject questUI;
    public Text itemCountText; // เพิ่ม Text UI สำหรับแสดงจำนวนไอเท็มที่ผู้เล่นเก็บได้

    private List<GameObject> pickableItems = new List<GameObject>();

    void Start()
    {
        GameObject[] pickables = GameObject.FindGameObjectsWithTag("pickable");
        foreach (GameObject pickable in pickables)
        {
            pickableItems.Add(pickable);
        }

        questUI.SetActive(false);
        UpdateItemCountText(); // เรียกใช้เมื่อเริ่มเกมเพื่อแสดงจำนวนไอเท็ม
    }

    void UpdateItemCountText()
    {
        itemCountText.text = "Items: " + currentItemCount + "/" + requiredItemCount;
    }

    void Update()
    {
        if (!questCompleted)
        {
            CheckQuestProgress();
            
        }
    }

    void CheckQuestProgress()
    {
        int collectedItemCount = requiredItemCount - pickableItems.Count;

        if (collectedItemCount > currentItemCount)
        {
            currentItemCount = collectedItemCount;
            UpdateItemCountText(); // ปรับปรุง UI เมื่อจำนวนไอเท็มเปลี่ยน

            if (currentItemCount == requiredItemCount)
            {
                questUI.SetActive(true);
                questCompleted = true;
            }
        }
    }
}