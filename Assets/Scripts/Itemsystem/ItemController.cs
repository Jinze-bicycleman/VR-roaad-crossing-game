using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemInfo itemInfo;

    // Call this method when the item is interacted with
    public void OnInteract()
    {
        // You can add functionality here for what happens when the item is interacted with
        // For example, remove the item from the manager's list
        ItemManager.Instance.RemoveItem(itemInfo);
       // Destroy(gameObject);
    }
}
