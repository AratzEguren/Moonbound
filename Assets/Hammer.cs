using UnityEngine;

public class HammerPendulumZ : MonoBehaviour
{
    public float swingAngle = 45f; // Ángulo máximo de oscilación en grados
    public float swingSpeed = 4f; // Velocidad de oscilación

    private float currentAngle; // Ángulo actual del martillo
    private float time; // Tiempo para calcular la oscilación

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAngle = 0f; // Inicializar el ángulo actual
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular el tiempo
        time += Time.deltaTime * swingSpeed;

        // Calcular el nuevo ángulo usando la función seno para oscilación
        currentAngle = swingAngle * Mathf.Sin(time);

        // Aplicar la rotación al martillo alrededor del eje Z
        // Compensar la rotación inicial en el eje Y
        transform.rotation = Quaternion.Euler(currentAngle, 0f, 0f) * Quaternion.Euler(0f, 90f, 0f);
    }
}