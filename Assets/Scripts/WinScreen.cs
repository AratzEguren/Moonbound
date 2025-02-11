using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScreen : MonoBehaviour
{
    public GameObject Canvas_VictoryScreen; // The UI element that will be shown when the player wins
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI CountdownText; // The text element to display the winning message

    private AudioSource audioSource;

    private void Start()
    {
        // Ensure the win screen is hidden at the start
        Canvas_VictoryScreen.SetActive(false);
        CountdownText.gameObject.SetActive(false);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Call this method when the player wins the level
    public void ShowWinScreen()
    {
        Canvas_VictoryScreen.SetActive(true);

        // Play the win screen sound
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void UpdateWinText(float timeElapsed)
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(timeElapsed % 60); // Calculate seconds
        int milliseconds = Mathf.FloorToInt((timeElapsed * 100) % 100); // Calculate milliseconds

        WinText.text = $"Congratulations! You win!\nTime: {minutes}:{seconds:00}:{milliseconds:00}";
    }

    // Handle the countdown and load the next scene
    public IEnumerator CountdownAndLoadScene(float delay)
    {
        CountdownText.gameObject.SetActive(true);

        for (int i = (int)delay; i > 0; i--)
        {
            CountdownText.text = $"Next level in: {i}";
            yield return new WaitForSeconds(1f);
        }

        CountdownText.text = "Next level in: 0";
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("CiudadLevel2"); // Replace "NextSceneName" with the name of your next scene
    }
}