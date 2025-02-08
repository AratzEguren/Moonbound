using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public GameObject Canvas_VictoryScreen; // The UI element that will be shown when the player wins

    private void Start()
    {
        // Ensure the win screen is hidden at the start
        Canvas_VictoryScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the player
        if (other.CompareTag("Player"))
        {
            ShowWinScreen();
        }
    }

    // Call this method when the player wins the level
    public void ShowWinScreen()
    {
        Canvas_VictoryScreen.SetActive(true);
    }
}
