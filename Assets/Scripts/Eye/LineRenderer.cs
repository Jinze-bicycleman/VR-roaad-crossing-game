using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLineRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform startPoint; // This could be the position of the eyeball

    void Update()
    {
        // Example: Get eye tracking data (direction or position)
        Vector3 eyeDirection = Camera.main.transform.forward; // Use your actual eye tracking data here

        // Set the line renderer positions
        lineRenderer.SetPosition(0, startPoint.position); // Start point is the eyeball position
        lineRenderer.SetPosition(1, startPoint.position + eyeDirection * 10f); // Extend line in the direction of gaze
    }
}

