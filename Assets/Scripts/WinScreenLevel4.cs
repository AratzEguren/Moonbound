using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScreenLevel4 : MonoBehaviour
{
    public GameObject Canvas_EndScreen; // The UI element that will be shown when the game ends
    public TextMeshProUGUI EndText; // The text element to display "The end"
    public TextMeshProUGUI CountdownText; // The text element to display the countdown

    private AudioSource audioSource;

    private void Start()
    {
        // Ensure the end screen is hidden at the start
        Canvas_EndScreen.SetActive(false);
        CountdownText.gameObject.SetActive(false);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Call this method when the player finishes the game
    public void ShowEndScreen()
    {
        Canvas_EndScreen.SetActive(true);

        // Play the end screen sound
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Update the end text to display "The end"
        EndText.text = "The end";

        // Start the countdown to load the main menu
        StartCoroutine(CountdownAndLoadScene(5f)); // Adjust the delay as needed
    }

    // Handle the countdown and load the main menu
    public IEnumerator CountdownAndLoadScene(float delay)
    {
        CountdownText.gameObject.SetActive(true);

        for (int i = (int)delay; i > 0; i--)
        {
            CountdownText.text = $"Returning to main menu in: {i}";
            yield return new WaitForSeconds(1f);
        }

        CountdownText.text = "Returning to main menu in: 0";
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the name of your main menu scene
    }
}