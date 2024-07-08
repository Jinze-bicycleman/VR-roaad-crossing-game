using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;

    public List<ItemInfo> collectedItems = new List<ItemInfo>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Transfer items from ItemManager to DataHolder
    public void TransferItems(List<ItemInfo> items)
    {
        collectedItems = new List<ItemInfo>(items);
        Debug.Log($"Items transferred: {collectedItems.Count} items");
    }

    // Method to retrieve the collected items from DataHolder
    public List<ItemInfo> GetCollectedItems()
    {
        return collectedItems;
    }
}
