using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerLevel3 : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign the TextMeshProUGUI from the Inspector
    private float timeElapsed = 0f; // Time elapsed

    public GameObject gameOverScreen;
    public GameObject winScreen; // Add a reference to the win screen

    private bool isGameOver = false;
    private bool isGamePaused = false; // To check if the game is paused (timer freeze)
    private bool hasWon = false; // To check if the player has won

    private float timeLimit = 600f;

    void Start()
    {
        gameOverScreen.SetActive(false); // Ensure the game over screen is hidden at the start
        winScreen.SetActive(false); // Ensure the win screen is hidden at the start
    }

    void Update()
    {
        if (!isGameOver && !isGamePaused)
        {
            if (timeElapsed < timeLimit)
            {
                timeElapsed += Time.deltaTime; // Increment the time with real time
                UpdateTimerText();
            }
            else
            {
                ShowGameOverScreen();
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(timeElapsed % 60); // Calculate seconds
        int milliseconds = Mathf.FloorToInt((timeElapsed * 100) % 100); // Calculate milliseconds

        // Update the text with the format: 0:00:00
        timerText.text = $"{minutes}:{seconds:00}:{milliseconds:00}";
    }

    private void ShowGameOverScreen()
    {
        if (!hasWon) // Only show the game over screen if the player hasn't won
        {
            gameOverScreen.SetActive(true);
            isGameOver = true; // Mark game over state
            this.enabled = false; // Disable this script to stop the timer
        }
    }

    public void FreezeTimer()
    {
        isGamePaused = true; // Freeze the timer
    }

    public void UnfreezeTimer()
    {
        isGamePaused = false; // Unfreeze the timer
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        hasWon = true; // Mark the win state
        FreezeTimer(); // Freeze the timer when the win screen is shown
    }

    public float GetElapsedTime()
    {
            return timeElapsed;
    }
}
