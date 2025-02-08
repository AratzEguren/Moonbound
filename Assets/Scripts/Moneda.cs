using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Busca el CoinCounter en la escena y aumenta el contador
            CoinCounter coinCounter = FindObjectOfType<CoinCounter>();
            if (coinCounter != null)
            {
                coinCounter.AddCoin();
            }

            // Destruye la moneda
            Destroy(gameObject);
        }
    }
}
