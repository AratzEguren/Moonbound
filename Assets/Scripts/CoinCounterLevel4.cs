using UnityEngine;
using TMPro;

public class CoinCounterLevel4 : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Assign the TextMeshProUGUI from the Inspector
    public int totalCoins = 10; // Total coins in the level
    private int currentCoins = 0; // Collected coins

    public WinScreenLevel4 victoryScreen;
    public TimerLevel4 timer; // Reference to the Timer script

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
                victoryScreen.ShowEndScreen();
                timer.FreezeTimer(); // Freeze the timer when all coins are collected
                var playerController = FindObjectOfType<Movimiento>();
                if (playerController != null)
                {
                    playerController.enabled = false;
                }
                StartCoroutine(victoryScreen.CountdownAndLoadScene(5f));
            }
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = $"Monedas {currentCoins}/{totalCoins}";
    }
}