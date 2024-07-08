using UnityEngine;
using TMPro;

public class Bubble : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Reference to the TextMeshProUGUI element

    // Method to be called when the event is triggered
    public void OnEventTriggered(string newText)
    {
        if (displayText != null)
        {
            displayText.text = newText; // Update the text property with the new text
        }
    }

    // Method to remove the text when the event is not triggered
    public void RemoveText()
    {
        if (displayText != null)
        {
            displayText.text = ""; // Set the text property to an empty string
        }
    }
}
