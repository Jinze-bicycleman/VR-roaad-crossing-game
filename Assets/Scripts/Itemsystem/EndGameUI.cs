using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    public Transform itemsParent; // Parent object to hold item UI elements
    public GameObject[] itemUIPrefabs; // Prefabs for individual item UI elements
    public KeyCode toggleKey = KeyCode.U; // Key to toggle the UI display
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    private void Start()
    {
        DisableAllSlots();
        FillEmptySlots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey) || OVRInput.GetDown(OVRInput.Button.One)|| OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) // Check for the A button on the right controller
        {
            ToggleUI();
        }
    }

    void DisableAllSlots()
    {
        foreach (var itemUI in itemUIPrefabs)
        {
            if (itemUI != null)
            {
                itemUI.SetActive(false); // Disable all item UI prefabs initially
            }
        }
    }

    void FillEmptySlots()
    {
        var items = DataHolder.Instance.GetCollectedItems();
        int itemCount = Mathf.Min(items.Count, itemUIPrefabs.Length);

        for (int i = 0; i < itemCount; i++)
        {
            var itemUI = itemUIPrefabs[i];
            if (itemUI != null)
            {
                itemUI.SetActive(true); // Enable the slot for the current item
                var itemInfo = items[i];
                SetItemUI(itemUI, itemInfo);
            }
            else
            {
                Debug.LogError("Item UI prefab is not assigned.");
            }
        }
    }

    void SetItemUI(GameObject itemUI, ItemInfo item)
    {
        // Set UI elements based on item data
        itemUI.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>().text = item.itemName;
        itemUI.transform.Find("Description").GetComponent<TMPro.TextMeshProUGUI>().text = item.description;
        itemUI.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().sprite = item.icon;
    }

    void ToggleUI()
    {
        if (canvasGroup.alpha == 1)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
