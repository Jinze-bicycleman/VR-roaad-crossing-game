using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool isTriggered = false;
    public string sceneName = "MainScene1";

    // This method is called whenever the script is loaded or a value is changed in the inspector
    private void OnValidate()
    {
        // Check if the checkbox is checked
        if (isTriggered)
        {
            // Reset the checkbox to prevent multiple loads
            isTriggered = false;

            // Load the specified scene
            LoadScene(sceneName);
        }
    }

    // Method to load the scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
