using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen; // Reference to the game over UI panel
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            ReloadLevel();
        }
    }

    public void GameOver()
    {
        // Call this method when game over condition is met
        isGameOver = true;
        gameOverScreen.SetActive(true); // Show the game over screen
    }

    private void ReloadLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
