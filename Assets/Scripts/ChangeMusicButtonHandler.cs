using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicButtonHandler : MonoBehaviour
{
    public MusicManager musicManager; // Reference to the MusicManager script

    public void ChangeMusic()
    {
        if (musicManager != null)
        {
            musicManager.ToggleMusic();
        }
        else
        {
            Debug.LogWarning("MusicManager is not assigned");
        }
    }

    public void MuteMusic()
    {
        if (musicManager != null)
        {
            musicManager.ToggleMute();
        }
        else
        {
            Debug.LogWarning("MusicManager is not assigned");
        }
    }
}