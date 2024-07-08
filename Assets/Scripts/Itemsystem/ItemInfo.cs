using UnityEngine;

[CreateAssetMenu (fileName="New Item",menuName="Item/Create New Item")]
public class ItemInfo: ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
}
