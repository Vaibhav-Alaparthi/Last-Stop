using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneDistance = 1f;
    public float laneChangeSpeed = 10f;
    public float forwardSpeed = 15f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private Animator animator;
    private int currentLane = 1;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;

        if (GameSettings.selectedLevel == 1)
        {
            forwardSpeed = 8f;
        }
        else if (GameSettings.selectedLevel == 2)
        {
            forwardSpeed = 13f;
        }
        else if (GameSettings.selectedLevel == 3)
        {
            forwardSpeed = 20f;
        }

        if (animator != null)
        {
            animator.SetBool("IsGrounded", true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane = Mathf.Clamp(currentLane - 1, 0, 2);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane = Mathf.Clamp(currentLane + 1, 0, 2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.z = forwardSpeed;
        rb.linearVelocity = velocity;

        float targetX = (currentLane - 1) * laneDistance;

        Vector3 targetPosition = new Vector3(
            targetX,
            rb.position.y,
            rb.position.z
        );

        Vector3 newPosition = Vector3.Lerp(
            rb.position,
            targetPosition,
            laneChangeSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(
            new Vector3(
                newPosition.x,
                rb.position.y,
                rb.position.z
            )
        );
    }

    void Jump()
    {
        SoundManager.instance.PlayJump();
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

        rb.AddForce(
            Vector3.up * jumpForce,
            ForceMode.Impulse
        );
    }

    public void SpeedBoost(float amount, float duration)
    {
        StartCoroutine(
            SpeedBoostRoutine(
                amount,
                duration
            )
        );
    }

    public void JumpBoost(float amount, float duration)
    {
        StartCoroutine(
            JumpBoostRoutine(
                amount,
                duration
            )
        );
    }

    System.Collections.IEnumerator SpeedBoostRoutine(
        float amount,
        float duration
    )
    {
        forwardSpeed += amount;

        yield return new WaitForSeconds(duration);

        forwardSpeed -= amount;
    }

    System.Collections.IEnumerator JumpBoostRoutine(
        float amount,
        float duration
    )
    {
        jumpForce += amount;

        yield return new WaitForSeconds(duration);

        jumpForce -= amount;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Land();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Land();
        }
    }

    void Land()
    {
        if (!isGrounded)
        {
            isGrounded = true;

            if (animator != null)
            {
                animator.SetBool("IsGrounded", true);
                animator.ResetTrigger("Jump");
            }
        }
        else
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