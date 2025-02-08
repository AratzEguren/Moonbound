using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Asigna el TextMeshProUGUI desde el Inspector
    private float timeElapsed = 0f; // Tiempo transcurrido

    public GameObject gameOverScreen;

    private float timeLimit = 180f;

    void Start()
    {
         
            gameOverScreen.SetActive(false); // Ensure the game over screen is hidden at the start

    } 

    void Update()
    {
        if (timeElapsed < timeLimit)
        {
        timeElapsed += Time.deltaTime; // Incrementa el tiempo con el tiempo real
        UpdateTimerText();
        }else{
            ShowGameOverScreen();
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
        this.enabled = false; // Disable this script to stop the timer
    }
}

