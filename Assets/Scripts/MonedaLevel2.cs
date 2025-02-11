using UnityEngine;

public class MonedaLevel2 : MonoBehaviour
{
    public AudioClip coinSound;

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Busca el CoinCounter en la escena y aumenta el contador
            CoinCounterLevel2 coinCounter = FindObjectOfType<CoinCounterLevel2>();
            if (coinCounter != null)
            {
                coinCounter.AddCoin();
            }

            // Play the coin collection sound
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }

            // Destroy the coin object instantly
            Destroy(gameObject);
        }
    }
}