using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlighter : MonoBehaviour
{
    public List<GameObject> allObjects;
    private HashSet<GameObject> seenObjects = new HashSet<GameObject>();

    public void CheckSeenObjects(List<Vector3> eyeTrackingData)
    {
        foreach (var gazePosition in eyeTrackingData)
        {
            RaycastHit hit;
            if (Physics.Raycast(gazePosition, Vector3.forward, out hit))
            {
                seenObjects.Add(hit.collider.gameObject);
            }
        }
    }

    public void HighlightMissedObjects()
    {
        foreach (var obj in allObjects)
        {
            if (!seenObjects.Contains(obj))
            {
                // Highlight the object, e.g., by changing its material color to red.
                obj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
