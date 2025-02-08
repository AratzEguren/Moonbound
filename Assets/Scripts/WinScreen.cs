using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public GameObject Canvas_VictoryScreen; // The UI element that will be shown when the player wins
    public TextMeshPro WinText; // The text element to display the winning message

    private void Start()
    {
        // Ensure the win screen is hidden at the start
        Canvas_VictoryScreen.SetActive(false);
    }

    // Call this method when the player wins the level
    public void ShowWinScreen()
    {
        Canvas_VictoryScreen.SetActive(true);
        WinText.text = "Congratulations! You win!";
    }
}
