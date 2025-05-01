using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Threading.Tasks;

public class SessionAnalyticsTracker : MonoBehaviour
{
    private float sessionStartTime;

    async void Start()
    {
        sessionStartTime = Time.realtimeSinceStartup;

        // Initialize Unity Services
        await InitializeUnityServices();
    }

    private async Task InitializeUnityServices()
    {
        try
        {
            await UnityServices.InitializeAsync();
            AnalyticsService.Instance.StartDataCollection();
            Debug.Log("Unity Services initialized.");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to initialize Unity Services: {e.Message}");
        }
    }

    void OnApplicationQuit()
    {
        float playTimeSec = Time.realtimeSinceStartup - sessionStartTime;

        // ✅ ใช้ชื่อ event ใหม่ที่ปลอดภัย
        CustomEvent quitEvent = new CustomEvent("player_quit_game");
        quitEvent["play_time_sec"] = Mathf.RoundToInt(playTimeSec);

        AnalyticsService.Instance.RecordEvent(quitEvent);
        Debug.Log($"📤 Sent 'player_quit_game' event with play_time_sec = {playTimeSec}");

        // Optional: Force send immediately
        AnalyticsService.Instance.Flush();
    }
}