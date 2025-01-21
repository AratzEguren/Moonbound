using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Vector3 puntoA; // Punto inicial
    public Vector3 puntoB; // Punto final
    public float velocidad = 2f; // Velocidad de movimiento
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
}

