using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class ReviewSceneManager : MonoBehaviour
{
    public Material highlightMaterial;
    public GameObject uiPanel; // The UI Panel that will be shown
    public TextMeshProUGUI itemNameText;  // Text component for item name
    public TextMeshProUGUI itemDescriptionText; // Text component for item description

    private HoverUIManager hoverUIManager;

    private void Start()
    {
        // Reference the HoverUIManager component attached to the same GameObject
        hoverUIManager = GetComponent<HoverUIManager>();

        // Assign UI elements to the HoverUIManager
        hoverUIManager.uiPanel = uiPanel;
        hoverUIManager.itemNameText = itemNameText;
        hoverUIManager.itemDescriptionText = itemDescriptionText;

        StartCoroutine(DelayedHighlight());
        AssignHoverEvents();
    }

    private IEnumerator DelayedHighlight()
    {
        // Wait for end of frame to ensure all items are loaded
        yield return new WaitForEndOfFrame();
        HighlightNonInteractedItems();
    }

    void HighlightNonInteractedItems()
    {
        var items = DataHolder.Instance.collectedItems;
        foreach (var item in items)
        {
            Debug.Log($"Trying to highlight item: {item.itemName}");
            var itemObjects = GameObject.FindGameObjectsWithTag("HighlightItem");
            foreach (var itemObject in itemObjects)
            {
                if (itemObject.name == item.itemName)
                {
                    var renderers = itemObject.GetComponentsInChildren<Renderer>();
                    if (renderers.Length > 0)
                    {
                        foreach (var renderer in renderers)
                        {
                            renderer.material = highlightMaterial;
                            Debug.Log($"Child object highlighted: {renderer.gameObject.name}");
                        }
                        Debug.Log($"Item highlighted: {item.itemName}");
                    }
                    else
                    {
                        Debug.Log($"Renderer not found for item: {item.itemName}");
                    }
                }
            }
        }
    }

    void AssignHoverEvents()
    {
        EyeInteractable[] interactables = FindObjectsOfType<EyeInteractable>();
        foreach (var interactable in interactables)
        {
            interactable.OnObjectHover.AddListener(hoverUIManager.ShowItemInfo);
        }
    }
}
