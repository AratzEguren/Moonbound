using UnityEngine;

public class Moneda : MonoBehaviour
{
    public AudioClip coinSound;

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
