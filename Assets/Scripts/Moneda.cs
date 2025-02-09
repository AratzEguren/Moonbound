using UnityEngine;

public class Moneda : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

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
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Destruye la moneda después de que se reproduzca el sonido
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
