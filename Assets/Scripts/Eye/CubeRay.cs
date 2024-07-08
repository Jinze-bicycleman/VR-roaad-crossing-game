using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CubeRay: MonoBehaviour
{
    [SerializeField]
    private float rayDistance = 1.0f;
    [SerializeField]
    private float rayWidth = 0.01f;
    [SerializeField]
    private LayerMask LayerToInclude;
    [SerializeField]
    private Color rayCollorDefaultState = Color.yellow;
    [SerializeField]
    private Color rayColorHoverState = Color.red;

    private LineRenderer lineRenderer;

    private List<Cube> cubes = new List<Cube>();
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupRay();


    }

    void SetupRay()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = rayWidth;
        lineRenderer.endWidth = rayWidth;
        lineRenderer.startColor = rayColorHoverState;
        lineRenderer.endColor = rayColorHoverState;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z + rayDistance));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 rayCastDirection = transform.TransformDirection(Vector3.forward) * rayDistance;
        if (Physics.Raycast(transform.position, rayCastDirection, out hit, Mathf.Infinity, LayerToInclude))
        {
            UnSelect();
            lineRenderer.startColor = rayColorHoverState;
            lineRenderer.endColor = rayColorHoverState;
            var cube = hit.transform.GetComponent<Cube>();
            if (cube != null)
            {
                cubes.Add(cube);
                cube.IsHovered = true;
            }
        }
        else
        {
            lineRenderer.startColor = rayCollorDefaultState;
            lineRenderer.endColor = rayCollorDefaultState;
            UnSelect(true);
        }

    }
    void UnSelect(bool clear = false)
    {
        cubes.RemoveAll(item => item == null);
        foreach (var interactable in cubes)
        {
            interactable.IsHovered = false;

        }
        if (clear)
        {
            cubes.Clear();
        }
    }
}
