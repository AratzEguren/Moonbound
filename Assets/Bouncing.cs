using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public float bounceForce = 10f; // Fuerza con la que el personaje será lanzado hacia el lado contrario

    private Rigidbody rb;

    void Start()
    {
        // Obtener el componente Rigidbody para aplicar la fuerza
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene el tag "Bounce"
        if (collision.gameObject.CompareTag("Bounce"))
        {
            // Calcular la dirección opuesta a la colisión
            Vector3 bounceDirection = transform.position - collision.contacts[0].point;

            // Normalizar la dirección para asegurarse de que la fuerza se aplique en una dirección correcta
            bounceDirection.Normalize();

            // Aplicar la fuerza al Rigidbody en la dirección opuesta a la colisión
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
