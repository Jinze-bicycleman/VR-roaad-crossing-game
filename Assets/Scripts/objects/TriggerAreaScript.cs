using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaScript : MonoBehaviour
{
    public SpecialAutoWalker[] specialAutoWalkers;  // Array of SpecialAutoWalker scripts to start walking
    public bool isTriggerEnabled = true;  // Check box to enable/disable the trigger
    public bool startWalkingManually = false;  // Check box to start walking manually

    void Update()
    {
        if (startWalkingManually)
        {
            StartSpecialAutoWalkers();
            startWalkingManually = false;  // Reset the flag after starting
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isTriggerEnabled && other.CompareTag("Player"))  // Check if the trigger is enabled
        {
            StartSpecialAutoWalkers();
        }
    }

    void StartSpecialAutoWalkers()
    {
        foreach (SpecialAutoWalker walker in specialAutoWalkers)
        {
            walker.StartWalking();
        }
    }
}
