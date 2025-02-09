using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;
    private bool isJumping;
    private float movementTimer = 0f; // Temporizador para el movimiento

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que el Rigidbody gire por la física
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimatorParameters();
    }

    void HandleMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Determinar la velocidad dependiendo de si está corriendo o caminando
        float speed = walkSpeed; // Comienza caminando

        // Movimiento del personaje
        Vector3 direction = transform.forward * vertical + transform.right * horizontal;

        if (direction.magnitude >= 0.1f)
        {
            movementTimer += Time.deltaTime; // Incrementar el temporizador

            // Cambiar a correr después de 1 segundo de movimiento
            if (movementTimer >= 1f)
            {
                speed = runSpeed; // Cambiar a velocidad de carrera
            }

            // Rotación suave hacia la dirección del movimiento
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 700 * Time.deltaTime);

            // Mover el personaje usando Rigidbody (sin interferir con la física)
            Vector3 velocity = direction.normalized * speed;
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
        else
        {
            movementTimer = 0f; // Reiniciar el temporizador si no se está moviendo
        }

        // Actualización de las animaciones según la entrada del jugador
        animator.SetBool("IsWalking", vertical > 0);
        animator.SetBool("IsWalkingBackwards", vertical < 0);
        animator.SetBool("IsRunning", movementTimer >= 1f);
    }

    void HandleJump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsLanded", false);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z); // Mantener la velocidad horizontal al saltar
        }

        if (rb.linearVelocity.y < 0)
        {
            animator.SetFloat("VelocityY", rb.linearVelocity.y);
        }

        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsLanded", true);
        }
    }

    void UpdateAnimatorParameters()
    {
        animator.SetFloat("VelocityY", rb.linearVelocity.y);
    }
}