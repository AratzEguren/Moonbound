using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip mainMenuMusic; // Reference to the main menu music clip
    public AudioClip gameMusic; // Reference to the game music clip

    private bool isMuted = false; // Track if the audio is muted
    private AudioClip currentClip; // Track the current playing clip

    void Start()
    {
        PlayMusic(mainMenuMusic); // Play main menu music at the start
    }

    // Method to play a specific music clip
    public void PlayMusic(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            currentClip = clip;
            audioSource.clip = clip;
            audioSource.loop = true; // Loop the music
            if (!isMuted)
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not assigned");
        }
    }

    // Method to stop the current music
    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned");
        }
    }

    // Method to mute or unmute the audio
    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
    }

    // Method to toggle between main menu music and game music
    public void ToggleMusic()
    {
        if (currentClip == mainMenuMusic)
        {
            PlayMusic(gameMusic);
        }
        else
        {
            PlayMusic(mainMenuMusic);
        }
    }
}