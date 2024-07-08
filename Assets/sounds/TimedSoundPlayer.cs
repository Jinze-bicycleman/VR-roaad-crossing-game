using UnityEngine;

public class TimedSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private float lastPlayTime;

    public AudioClip soundClip;
    public float playInterval = 10f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPlayTime = -playInterval; // So that the sound can be played immediately at the start.
    }

    void Update()
    {
        // Check if the time since the last play is greater than the interval.
        if (Time.time - lastPlayTime >= playInterval)
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
            lastPlayTime = Time.time;
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not set.");
        }
    }
}
