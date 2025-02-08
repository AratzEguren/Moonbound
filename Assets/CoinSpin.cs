using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float spinSpeed = 125f; // Velocidad de rotación en grados por segundo
    public float oscillationAmplitude = 0.5f; // Amplitud del movimiento oscilante
    public float oscillationFrequency = 1f; // Frecuencia del movimiento oscilante

    private Vector3 initialPosition; // Posición inicial del objeto

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Guardar la posición inicial del objeto
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotar el objeto alrededor del eje Y
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

        // Calcular el movimiento oscilante
        float newY = initialPosition.y + Mathf.Sin(Time.time * oscillationFrequency) * oscillationAmplitude;

        // Aplicar la nueva posición
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    // Método que se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Destruir este objeto
            Destroy(gameObject);
        }
    }
}