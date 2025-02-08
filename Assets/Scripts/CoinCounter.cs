using UnityEngine;
using TMPro;


public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Asigna el TextMeshProUGUI desde el Inspector
    public int totalCoins = 30; // Total de monedas en el nivel
    private int currentCoins = 0; // Monedas recolectadas

    public WinScreen victoryScreen;

    public TextMeshPro VictoryText;

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
                var playerController = Object.FindFirstObjectByType<Movimiento>();
                if (playerController != null)
                {
                    playerController.enabled = false;
                }
            }
      
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = $"Monedas {currentCoins}/{totalCoins}";
    }
}
