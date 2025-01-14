using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float bounceForce = 10f; // Fuerza del rebote
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el tag "character" ha tocado el trampolín
        if (collision.gameObject.CompareTag("Character"))
        {
            // Obtener el Rigidbody del jugador
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Aplicar una fuerza hacia arriba al jugador
                playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
