using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Asigna el TextMeshProUGUI desde el Inspector
    public int totalCoins = 30; // Total de monedas en el nivel
    private int currentCoins = 0; // Monedas recolectadas

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
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = $"Monedas {currentCoins}/{totalCoins}";
    }
}
