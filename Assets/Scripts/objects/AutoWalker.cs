using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalker : MonoBehaviour
{
    public Transform[] waypoints;  // Array of waypoints
    public float speed = 2.0f;     // Walking speed

    private int currentWaypointIndex = 0;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (waypoints.Length > 0)
        {
            currentWaypointIndex = FindNearestWaypointIndex();
        }
    }

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Rotate towards the target waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    int FindNearestWaypointIndex()
    {
        int nearestWaypointIndex = 0;
        float shortestDistance = Vector3.Distance(transform.position, waypoints[0].position);

        for (int i = 1; i < waypoints.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, waypoints[i].position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestWaypointIndex = i;
            }
        }

        return nearestWaypointIndex;
    }
}
