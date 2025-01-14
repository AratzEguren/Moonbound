using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float rotationSpeed = 360f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;
    private float moveTimer;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
HandleMovement();
        HandleRotation();
        HandleJump();
        UpdateAnimatorParameters();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Vertical"); // W/S o flechas arriba/abajo
        float moveSpeed = walkSpeed;
        if (moveInput > 0) // Avanzando
        {
            animator.SetBool("isMoving", true);
            moveDirection = transform.forward;
            moveTimer += Time.deltaTime;

            if (moveTimer >= 1f) // Después de 1 segundo corriendo
            {
                moveSpeed = runSpeed;
                animator.SetBool("isStillMoving", true);
            }
        }
        else if (moveInput < 0) // Retrocediendo
        {
            moveDirection = -transform.forward;
            moveSpeed = walkSpeed;

            animator.SetBool("isWalkingBackwards", true);
            animator.SetBool("isMoving", false);
            animator.SetBool("isStillMoving", false);
        }
        else // Sin movimiento
        {
            moveDirection = Vector3.zero;
            moveTimer = 0;

            animator.SetBool("isMoving", false);
            animator.SetBool("isStillMoving", false);
            animator.SetBool("isWalkingBackwards", false);
        }

        // Aplicar la velocidad de movimiento al Rigidbody
        Vector3 velocity = moveDirection * moveSpeed;
        velocity.y = rb.linearVelocity.y; // Mantener la velocidad vertical (gravedad)
        rb.linearVelocity = velocity;
    }


    void HandleRotation()
    {
        float turnInput = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        if (turnInput != 0)
        {
            float turn = turnInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, turn, 0);
        }
    }

    void HandleJump()
    {
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isLanding", true);

            if (Input.GetButtonDown("Jump")) // Espacio por defecto
            {
		animator.SetBool("isWalkingBackwards", false);

                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetBool("isJumping", true);
                animator.SetBool("isLanding", false);
            }
        }
        else
        {
            animator.SetBool("isLanding", false);
        }
    }

    void UpdateAnimatorParameters()
    {
        animator.SetFloat("VelocityY", rb.linearVelocity.y);
    }

    private void OnCollisionStay(Collision collision)
    {
        // Verificar si el objeto tocado tiene la etiqueta "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando el objeto deja de tocar el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
