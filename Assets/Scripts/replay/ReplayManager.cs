using System.Collections.Generic;
using UnityEngine;

public class ReplayManager : MonoBehaviour
{
    public PlayerReplayer playerReplayer;
    public Camera mainCamera;
    public Camera replayCamera;

    public void StartReplay(List<PlayerRecorder.PlayerData> playerData)
    {
        if (playerReplayer == null)
        {
            Debug.LogError("PlayerReplayer is not assigned in ReplayManager.");
            return;
        }

        playerReplayer.SetPlayerData(playerData);

        // Switch to replay camera
        if (mainCamera != null) mainCamera.enabled = false;
        if (replayCamera != null) replayCamera.enabled = true;

        playerReplayer.enabled = true;
    }

    public void EndReplay()
    {
        // Switch back to main camera
        if (mainCamera != null) mainCamera.enabled = true;
        if (replayCamera != null) replayCamera.enabled = false;

        playerReplayer.enabled = false;
    }
}
