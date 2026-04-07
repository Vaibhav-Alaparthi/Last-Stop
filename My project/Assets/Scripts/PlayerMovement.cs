using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sideSpeed = 6f;
    public float forwardSpeed = 8f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        rb.freezeRotation = true;

        if (animator != null)
        {
            animator.SetBool("IsGrounded", true);
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveX * sideSpeed;
        velocity.z = forwardSpeed;
        rb.linearVelocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;

            if (animator != null)
            {
                animator.SetBool("IsGrounded", false);
                animator.ResetTrigger("Jump");
                animator.SetTrigger("Jump");
            }

            velocity = rb.linearVelocity;
            velocity.y = 0f;
            rb.linearVelocity = velocity;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if (animator != null)
            {
                animator.SetBool("IsGrounded", true);
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if (animator != null)
            {
                animator.SetBool("IsGrounded", true);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

            if (animator != null)
            {
                animator.SetBool("IsGrounded", false);
            }
        }
    }
}