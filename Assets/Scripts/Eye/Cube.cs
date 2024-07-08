using UnityEngine;
using UnityEngine.Events;
using System.Collections; // Add this for IEnumerator

[RequireComponent(typeof(Collider))]
public class Cube : MonoBehaviour
{
    public bool IsHovered { get; set; }

    [SerializeField] public UnityEvent<MeshRenderer> OnObjectHover;
    [SerializeField] private Material OnHoverActiveMaterial;
    [SerializeField] private Material OnHoverInactiveMaterial;
    [SerializeField] private float hoverDuration = 1f; // Duration in seconds for the color fill
    [SerializeField] private float invokeInterval = 2f; // Interval in seconds for event invocation
    public ItemController itemController;

    private MeshRenderer meshRenderer;
    private float hoverTimer;
    private float lastInvokeTime;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        hoverTimer = 0f;
        lastInvokeTime = -invokeInterval; // Initialize to allow immediate invocation
    }

    void Update()
    {
        if (IsHovered)
        {
            hoverTimer += Time.deltaTime; // Increment the timer while hovered
            if (hoverTimer >= hoverDuration)
            {
                itemController.OnInteract(); // Call the function when hover duration is reached
                FillColor(); // Call the FillColor method while hovered
                hoverTimer = 0f; // Reset the timer
            }
        }
        else
        {
            hoverTimer = 0f; // Reset the timer if not hovered
            meshRenderer.material.Lerp(meshRenderer.material, OnHoverInactiveMaterial, Time.deltaTime / hoverDuration);
        }
    }

    void FillColor()
    {
        // Get MeshRenderer from the current object only
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        // Set the material color for the MeshRenderer with a fading effect
        if (renderer != null)
        {
            float timeSinceLastInvoke = Time.time - lastInvokeTime;
            if (timeSinceLastInvoke >= invokeInterval)
            {
                StartCoroutine(FadeToColor(renderer, OnHoverActiveMaterial.color));
                OnObjectHover?.Invoke(renderer);
                lastInvokeTime = Time.time;
            }
        }
    }

    private IEnumerator FadeToColor(MeshRenderer renderer, Color targetColor)
    {
        Color startColor = renderer.material.color;
        float elapsedTime = 0f;

        while (elapsedTime < hoverDuration)
        {
            renderer.material.color = Color.Lerp(startColor, targetColor, elapsedTime / hoverDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        renderer.material.color = targetColor; // Ensure the target color is set at the end
    }
}
