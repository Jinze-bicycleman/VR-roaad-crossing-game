
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    public bool isTriggered = false;
    public string endGameSceneName = "ReviewScene";
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the Player tag (adjust as needed)
        if (other.CompareTag("Player"))
        {
            EndLevel();
        }
    }
    public void EndLevel()
    {
        DataHolder.Instance.TransferItems(ItemManager.Instance.items);
        SceneManager.LoadScene("ReviewScene");
    }
    private void OnValidate()
    {
        // Check if the checkbox is checked
        if (isTriggered)
        {
            // Reset the checkbox to prevent multiple loads
            isTriggered = false;
            DataHolder.Instance.TransferItems(ItemManager.Instance.items);

            // Load the specified scene
            SceneManager.LoadScene("ReviewScene");
        }
    }
}
