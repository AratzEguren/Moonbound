using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float rotationSpeed = 360f;
    public float jumpForce = 5f;
    private float moveTimer;

    private AudioSource audioSource;
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
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
            moveDirection = transform.forward;
            moveSpeed = walkSpeed;

            animator.SetBool("isMoving", true);
            animator.SetBool("isStillMoving", false);
            animator.SetBool("isWalkingBackwards", false);
            animator.SetBool("isRunningBackWards", false);

            moveTimer += Time.deltaTime;

            if (moveTimer >= 2f) // Después de 2 segundos andando, corre
            {
                moveSpeed = runSpeed;
                animator.SetBool("isMoving", false);
                animator.SetBool("isRunningBackWards", false);
                animator.SetBool("isStillMoving", true);
                animator.SetBool("isWalkingBackwards", false);
            }
        }
        else if (moveInput < 0) // Retrocediendo
        {
            moveDirection = -transform.forward;
            moveSpeed = walkSpeed;

            animator.SetBool("isMoving", false);
            animator.SetBool("isStillMoving", false);
            animator.SetBool("isRunningBackWards", false);
            animator.SetBool("isWalkingBackwards", true);
        }
        else // Sin movimiento
        {
            moveDirection = Vector3.zero;
            animator.SetBool("isMoving", false);
            animator.SetBool("isStillMoving", false);
            animator.SetBool("isWalkingBackwards", false);
            animator.SetBool("isRunningBackWards", false);

            moveTimer = 0f; // Reset the move timer when not moving
        }

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

            if (Input.GetButtonDown("Jump")) // Espacio por defecto
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetBool("isJumping", true);
                animator.SetBool("isLanding", false);
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
    }

    void UpdateAnimatorParameters()
    {
        animator.SetFloat("VelocityY", rb.linearVelocity.y); // Ensure this parameter exists in Animator
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto tocado tiene la etiqueta "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isLanding", true);
            Debug.Log("Landing detected. isGrounded set to true.");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando el objeto deja de tocar el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Left ground. isGrounded set to false.");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isLanding", false);
        }
    }
}