using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public List<ItemInfo> items = new List<ItemInfo>();

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

    public void RemoveItem(ItemInfo item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Manager Item removed: {item.itemName}");
        }
    }

    public List<ItemInfo> GetItems()
    {
        Debug.Log($"Manager Getting items: {items.Count} items");
        return items;
    }
}
