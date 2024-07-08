using System.Collections.Generic;
using UnityEngine;

public class PlayerReplayer : MonoBehaviour
{
    public List<PlayerRecorder.PlayerData> playerData;
    private int currentIndex = 0;
    public float playbackSpeed = 1.0f;

    public void SetPlayerData(List<PlayerRecorder.PlayerData> data)
    {
        playerData = data;
        currentIndex = 0;
    }

    void Update()
    {
        if (playerData != null && currentIndex < playerData.Count)
        {
            transform.position = Vector3.Lerp(transform.position, playerData[currentIndex].position, Time.deltaTime * playbackSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerData[currentIndex].rotation, Time.deltaTime * playbackSpeed);
            currentIndex++;
        }
        else if (playerData != null && currentIndex >= playerData.Count)
        {
            // End of replay
            FindObjectOfType<ReplayManager>().EndReplay();
        }
    }
}
