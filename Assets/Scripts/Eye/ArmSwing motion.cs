using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;
using UnityEngine.XR;

public class SwingingArmMotion : MonoBehaviour
{
    // Game Objects
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject ForwardDirection;
    [SerializeField] private GameObject Leye;
    [SerializeField] private GameObject Reye;

    // Vector3 Positions
    [SerializeField] private Vector3 PositionPreviousFrameLeftHand;
    [SerializeField] private Vector3 PositionPreviousFrameRightHand;
    [SerializeField] private Vector3 PlayerPositionPreviousFrame;
    [SerializeField] private Vector3 PlayerPositionCurrentFrame;
    [SerializeField] private Vector3 PositionCurrentFrameLeftHand;
    [SerializeField] private Vector3 PositionCurrentFrameRightHand;

    // Speed
    [SerializeField] private float Speed = 70;
    [SerializeField] private float HandSpeed;

    void Start()
    {
        PlayerPositionPreviousFrame = transform.position; // set current positions
        PositionPreviousFrameLeftHand = LeftHand.transform.position; // set previous positions
        PositionPreviousFrameRightHand = RightHand.transform.position;
    }

    void Update()
    {
        // Get forward direction from the center eye camera and set it to the forward direction object
        float yRotation = MainCamera.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        // Get positions of hands
        PositionCurrentFrameLeftHand = LeftHand.transform.position;
        PositionCurrentFrameRightHand = RightHand.transform.position;

        // Position of player
        PlayerPositionCurrentFrame = transform.position;

        // Get distance the hands and player have moved from last frame
        var playerDistanceMoved = Vector3.Distance(PlayerPositionCurrentFrame, PlayerPositionPreviousFrame);
        var leftHandDistanceMoved = Vector3.Distance(PositionPreviousFrameLeftHand, PositionCurrentFrameLeftHand);
        var rightHandDistanceMoved = Vector3.Distance(PositionPreviousFrameRightHand, PositionCurrentFrameRightHand);

        // Aggregate to get hand speed
       

        // Check if triggers are pressed
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1f || OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f)
        {
            HandSpeed = 0;
        }
        else
        {
            HandSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));
        }

        if (Time.timeSinceLevelLoad > 1f)
        {
            transform.position += ForwardDirection.transform.forward * HandSpeed * Speed * Time.deltaTime;
        }

        // Set previous position of hands for next frame
        PositionPreviousFrameLeftHand = PositionCurrentFrameLeftHand;
        PositionPreviousFrameRightHand = PositionCurrentFrameRightHand;
        // Set player position previous frame
        PlayerPositionPreviousFrame = PlayerPositionCurrentFrame;
    }
}
