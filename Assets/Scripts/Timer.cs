using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Asigna el TextMeshProUGUI desde el Inspector
    private float timeElapsed = 0f; // Tiempo transcurrido

    public GameObject gameOverScreen;

    private float timeLimit = 180f;
    private bool isGameOver = false;


    void Start()
    {
         
            gameOverScreen.SetActive(false); // Ensure the game over screen is hidden at the start

    } 

    void Update()
    {
        
     if (!isGameOver)
        {
            if (timeElapsed < timeLimit)
            {
                timeElapsed += Time.deltaTime; // Incrementa el tiempo con el tiempo real
                UpdateTimerText();
            }
            else
            {
                ShowGameOverScreen();
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                ReloadLevel();
            }
        }
    }


    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60); // Calcula los minutos
        int seconds = Mathf.FloorToInt(timeElapsed % 60); // Calcula los segundos
        int milliseconds = Mathf.FloorToInt((timeElapsed * 100) % 100); // Calcula los milisegundos

        // Actualiza el texto con el formato: 0:00:00
        timerText.text = $"{minutes}:{seconds:00}:{milliseconds:00}";
    }

     private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        // Disable player movement
        isGameOver = true;
        this.enabled = false; // Disable this script to stop the timer
    }

     private void ReloadLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

