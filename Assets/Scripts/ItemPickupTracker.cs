using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
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
            AnalyticsService.Instance.StartDataCollection();
            Debug.Log("Unity Services initialized.");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to initialize Unity Services: {e.Message}");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable") && !hasPickedFirstItem)
        {
            string itemId = other.gameObject.name;
            PickItem(itemId);
            Destroy(other.gameObject);
        }
    }

    public void PickItem(string itemId)
    {
        if (hasPickedFirstItem)
        {
            Debug.Log("Already picked first item, skipping.");
            return;
        }

        hasPickedFirstItem = true;

        CustomEvent myEvent = new CustomEvent("first_item_picked");
        myEvent["first_item_id"] = itemId;

        AnalyticsService.Instance.RecordEvent(myEvent);
        Debug.Log($"✅ Sent 'first_item_picked' event with item: {itemId}");
    }
}