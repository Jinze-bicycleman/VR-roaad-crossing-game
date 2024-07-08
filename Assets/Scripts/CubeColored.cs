using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CubeColored : MonoBehaviour
{
    public bool IsHovered { get; set; }

 
    [SerializeField] private Material OnHoverActiveMaterial;
    [SerializeField] private Material OnHoverInactiveMaterial;
    [SerializeField] private float hoverDuration = 1f; // Duration in seconds for the color fill
    //public ItemController itemController;

    private MeshRenderer meshRenderer;
    private float hoverTimer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        hoverTimer = 0f;
    }

    void Update()
    {
        if (IsHovered)
        {
            hoverTimer += Time.deltaTime; // Increment the timer while hovered
            if (hoverTimer >= hoverDuration)
            {
               // itemController.OnInteract(); // Call the function when hover duration is reached
                FillColor(); // Call the FillColor method while hovered
                hoverTimer = 0f; // Reset the timer
            }

        }
        else
        {
            hoverTimer = 0f; // Reset the timer if not hovered
            meshRenderer.material = OnHoverInactiveMaterial;
            // NonObjectHover?.Invoke(meshRenderer);
        }
    }

    public void FillColor()
    {
        // Get MeshRenderers from the main object and all child objects
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        // Set the material color for each MeshRenderer
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.material = OnHoverActiveMaterial;
           
        }
    }
}
