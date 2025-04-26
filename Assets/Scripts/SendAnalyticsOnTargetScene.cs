using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SendAnalyticsOnTargetScene : MonoBehaviour
{
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AnalyticsService.Instance.StartDataCollection();

        if (GameTimer.Instance != null)
        {
            float timeSpent = GameTimer.Instance.GetElapsedTime();

            var customEvent = new CustomEvent("time_spent_to_target_scene")
            {
                { "time_spent_seconds", timeSpent },
                { "scene_name", SceneManager.GetActiveScene().name }
            };

            AnalyticsService.Instance.RecordEvent(customEvent);

            Debug.Log($"✅ [UGS Analytics] Event sent! Time spent = {timeSpent} seconds");
        }
        else
        {
            Debug.LogWarning("❗ GameTimer.Instance is NULL");
        }
    }
}