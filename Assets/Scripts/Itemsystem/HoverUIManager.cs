using UnityEngine;
using TMPro;

public class HoverUIManager : MonoBehaviour
{
    public GameObject uiPanel; // The UI Panel that will be shown
    public TextMeshProUGUI itemNameText;  // Text component for item name
    public TextMeshProUGUI itemDescriptionText; // Text component for item description

    private void Start()
    {
        uiPanel.SetActive(false); // Hide the panel at start
    }

    public void ShowItemInfo(MeshRenderer meshRenderer)
    {
        var item = DataHolder.Instance.collectedItems.Find(i => i.itemName == meshRenderer.gameObject.name);
        if (item != null)
        {
            itemNameText.text = item.itemName;
            itemDescriptionText.text = item.description;
            uiPanel.transform.position = Input.mousePosition; // Move the panel to the mouse position
            uiPanel.SetActive(true);
        }
    }

    public void HideItemInfo()
    {
        uiPanel.SetActive(false);
    }
}
