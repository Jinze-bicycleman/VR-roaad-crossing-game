using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerData
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    private List<PlayerData> recordedData = new List<PlayerData>();
    private bool isRecording = false;

    public void StartRecording()
    {
        recordedData.Clear();
        isRecording = true;
    }

    public void StopRecording()
    {
        isRecording = false;
    }

    public List<PlayerData> GetRecordedData()
    {
        return recordedData;
    }

    void Update()
    {
        if (isRecording)
        {
            recordedData.Add(new PlayerData { position = transform.position, rotation = transform.rotation });
        }
    }
}
