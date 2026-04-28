using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;
    public float forwardSpeed = 8f;
    public float jumpForce = 5.5f;

    private Rigidbody rb;
    private Animator animator;
    private int currentLane = 1;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane--;
            currentLane = Mathf.Clamp(currentLane, 0, 2);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane++;
            currentLane = Mathf.Clamp(currentLane, 0, 2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float targetX = (currentLane - 1) * laneDistance;

        Vector3 velocity = rb.linearVelocity;
        velocity.z = forwardSpeed;
        rb.linearVelocity = velocity;

        Vector3 targetPosition = new Vector3(targetX, rb.position.y, rb.position.z);
        Vector3 newPosition = Vector3.Lerp(rb.position, targetPosition, laneChangeSpeed * Time.fixedDeltaTime);

        rb.MovePosition(new Vector3(newPosition.x, rb.position.y, rb.position.z));
    }

    void Jump()
    {
        isGrounded = false;

        if (animator != null)
        {
            animator.SetBool("IsGrounded", false);
            animator.ResetTrigger("Jump");
            animator.SetTrigger("Jump");
        }

        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0f;
        rb.linearVelocity = velocity;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void SpeedBoost(float amount, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(amount, duration));
    }

    public void JumpBoost(float amount, float duration)
    {
        StartCoroutine(JumpBoostRoutine(amount, duration));
    }

    System.Collections.IEnumerator SpeedBoostRoutine(float amount, float duration)
    {
        forwardSpeed += amount;
        yield return new WaitForSeconds(duration);
        forwardSpeed -= amount;
    }

    System.Collections.IEnumerator JumpBoostRoutine(float amount, float duration)
    {
        jumpForce += amount;
        yield return new WaitForSeconds(duration);
        jumpForce -= amount;
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