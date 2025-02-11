using UnityEngine;
using TMPro;

public class CoinCounterLevel2 : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Assign the TextMeshProUGUI from the Inspector
    public int totalCoins = 30; // Total coins in the level
    private int currentCoins = 0; // Collected coins

    public WinScreenLevel2 victoryScreen;
    public TimerLevel2 timer; // Reference to the Timer script

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        if (currentCoins < totalCoins)
        {
            currentCoins++;
            UpdateCoinText();

            if (currentCoins >= totalCoins)
            {
                victoryScreen.ShowWinScreen();
                timer.FreezeTimer(); // Freeze the timer when all coins are collected
                var playerController = FindObjectOfType<Movimiento>();
                if (playerController != null)
                {
                    playerController.enabled = false;
                }
                float finalTime = timer.GetElapsedTime();
                victoryScreen.UpdateWinText(finalTime);
                StartCoroutine(victoryScreen.CountdownAndLoadScene(5f));
            }
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = $"Monedas {currentCoins}/{totalCoins}";
    }
}

