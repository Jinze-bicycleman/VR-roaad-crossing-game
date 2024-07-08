using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerRecorder playerRecorder;
    public ReplayManager replayManager;

    void Start()
    {
        playerRecorder = playerRecorder ?? GetComponent<PlayerRecorder>();
        replayManager = replayManager ?? FindObjectOfType<ReplayManager>();

        if (playerRecorder == null || replayManager == null)
        {
            Debug.LogError("PlayerRecorder or ReplayManager component is missing.");
            return;
        }

        playerRecorder.StartRecording();
    }

    void Update()
    {
        // Example: stop recording and start replay after 10 seconds
        if (Time.time > 60.0f)
        {
            playerRecorder.StopRecording();
            replayManager.StartReplay(playerRecorder.GetRecordedData());
        }
    }
}
