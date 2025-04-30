using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ItemPickupTracker : MonoBehaviour
{
    private bool hasPickedFirstItem = false;

    async void Start()
    {
        await InitializeServices();
    }

    private async Task InitializeServices()
    {
        try
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services initialized.");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to initialize Unity Services: {e.Message}");
        }
    }

    // เรียกฟังก์ชันนี้เมื่อผู้เล่นหยิบไอเทม
    public void PickItem(string itemId)
    {
        if (hasPickedFirstItem) return;

        hasPickedFirstItem = true;

        var eventParams = new Dictionary<string, object>
        {
            { "first_item_id", itemId }
        };

        object value = AnalyticsService.Instance.CustomEvent("first_item_picked", eventParams);
        Debug.Log($"Sent 'first_item_picked' event with item: {itemId}");
    }
}