using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sideSpeed = 6f;
    public float forwardSpeed = 8f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;

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
        float moveX = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector3(
            moveX * sideSpeed,
            rb.linearVelocity.y,
            forwardSpeed
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;

            if (animator != null)
            {
                animator.SetBool("IsGrounded", false);
                animator.ResetTrigger("Jump");
                animator.SetTrigger("Jump");
            }

            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                0f,
                rb.linearVelocity.z
            );

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