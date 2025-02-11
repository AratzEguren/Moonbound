using UnityEngine;

public class RespawnLevel4 : MonoBehaviour
{
    private Vector3 initialPosition; // Guarda la posici�n inicial del personaje
    private Quaternion initialRotation; // Guarda la rotaci�n inicial del personaje

    void Start()
    {
        // Guarda la posici�n y rotaci�n inicial del personaje
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que colision� tiene la etiqueta "Water"
        if (other.CompareTag("Water"))
        {
            RespawnCharacter();
        }
    }

    public void RespawnCharacter()
    {
        // Mueve al personaje a su posici�n inicial y reinicia su rotaci�n
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Opcionalmente, si tiene un Rigidbody, reiniciar la velocidad para evitar efectos raros
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
