using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Vector3 puntoA; // Punto inicial
    public Vector3 puntoB; // Punto final
    public float velocidad = 10f; // Velocidad de movimiento
    private bool moviendoHaciaB = true;
    void Start()
    {
        transform.position = puntoA; // Posición inicial
    }
    void Update()
    {
    if (moviendoHaciaB)
    {
    transform.position = Vector3.MoveTowards(transform.position, puntoB, velocidad * Time.deltaTime);
        if (transform.position == puntoB)
            moviendoHaciaB = false; // Cambia dirección
    }
    else
    {
        transform.position = Vector3.MoveTowards(transform.position, puntoA, velocidad * Time.deltaTime);
            if (transform.position == puntoA)
                moviendoHaciaB = true; // Cambia dirección
        }   
    }

    
       private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            // Make the player a child of the platform
            collision.transform.SetParent(transform,true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the player left the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detach the player from the platform
            collision.transform.SetParent(null);
        }
    }
}

