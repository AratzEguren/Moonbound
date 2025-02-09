using UnityEngine;

public class RespawnOnGround : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody rb;

    void Start()
    {
        // Guardamos la posición y rotación inicial del objeto
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Obtenemos el componente Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto colisiona con algo que tenga la etiqueta "Ground"
        if (collision.gameObject.CompareTag("eliminar"))
        {
            // Respawn en la posición y rotación inicial
            transform.position = initialPosition;
            transform.rotation = initialRotation;

            // Restablecemos la velocidad y la rotación del Rigidbody
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // Velocidad lineal a cero
                rb.angularVelocity = Vector3.zero; // Velocidad angular a cero
            }
        }
    }
}