using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sideSpeed = 6f;
    public float forwardSpeed = 8f;
    public float jumpForce = 2.5f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // stop tipping over
        rb.freezeRotation = true;
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
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}