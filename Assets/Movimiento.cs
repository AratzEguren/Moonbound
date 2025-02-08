using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;

    private Animator animator;
    private Rigidbody rb;
    private float speed;
    private bool isGrounded;
    private bool isJumping;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
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

        // Calcular velocidad
        if (vertical > 0)
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsWalkingBackwards", false);
        }
        else if (vertical < 0)
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsWalkingBackwards", true);
        }
        else
        {
            speed = 0f;
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsWalkingBackwards", false);
        }

        if (speed > walkSpeed)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        // Movimiento del personaje
        Vector3 direction = transform.forward * vertical + transform.right * horizontal;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // Rotación del personaje
        if (horizontal != 0)
        {
            transform.Rotate(0, horizontal * 100 * Time.deltaTime, 0);
        }
    }

    void HandleJump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsLanded", false);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetFloat("VelocityY", rb.velocity.y);
        }

        if (isGrounded && rb.velocity.y <= 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsLanded", true);
        }
    }

    void UpdateAnimatorParameters()
    {
        animator.SetFloat("VelocityY", rb.velocity.y);
        animator.SetFloat("Speed", speed);
    }


}
