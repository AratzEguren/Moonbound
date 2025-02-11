using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento
    public float distance = 10f; // Distancia máxima de ida y vuelta

    private Vector3 startPosition;
    private int direction = 1; // 1 para avanzar, -1 para retroceder

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(0, 0, speed * direction * Time.deltaTime);

        // Si el objeto supera la distancia máxima, cambia la dirección
        if (Mathf.Abs(transform.position.z - startPosition.z) >= distance)
        {
            direction *= -1;
        }
    }
}
