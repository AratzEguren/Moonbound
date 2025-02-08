using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float bounceForce = 10f; // Fuerza del rebote
    public float moveUpDistance = 1.5f; // Distancia que sube el trampol�n en Y
    public float moveDuration = 1f; // Duraci�n del ascenso y descenso

    private Vector3 originalPosition; // Posici�n inicial del trampol�n
    private bool isMoving = false; // Controla si el trampol�n est� en movimiento

    private void Start()
    {
        // Almacenar la posici�n inicial
        originalPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el tag "Character" ha tocado el trampol�n
        if (collision.gameObject.CompareTag("Player") && !isMoving)
        {
            // Obtener el Rigidbody del jugador
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Aplicar una fuerza hacia arriba al jugador
                playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }

            // Activar el movimiento suave del trampol�n
            StartCoroutine(SmoothMoveTrampoline());
        }
    }

    private System.Collections.IEnumerator SmoothMoveTrampoline()
    {
        isMoving = true;

        // Calcular la posici�n de destino hacia arriba
        Vector3 targetPosition = originalPosition + new Vector3(0, moveUpDistance, 0);

        // Movimiento hacia arriba
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Esperar al siguiente frame
        }
        transform.position = targetPosition;

        // Pausa opcional antes de regresar
        yield return new WaitForSeconds(0.5f);

        // Movimiento hacia abajo
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;

        isMoving = false;
    }
}