using UnityEngine;
using System.Collections;

public class PlayerSlide : MonoBehaviour
{
    public Animator animator;
    public CapsuleCollider capsule;

    [Header("Slide Key")]
    public KeyCode slideKey = KeyCode.LeftControl;

    [Header("Slide Timing")]
    public float slideDuration = 0.8f;

    [Header("Standing Collider")]
    public float standingHeight = 2f;
    public Vector3 standingCenter = new Vector3(0f, 1f, 0f);

    [Header("Sliding Collider")]
    public float slidingHeight = 1f;
    public Vector3 slidingCenter = new Vector3(0f, 0.5f, 0f);

    private bool isSliding = false;

    void Update()
    {
        if (Input.GetKeyDown(slideKey) && !isSliding)
        {
            StartCoroutine(SlideRoutine());
        }
    }

    IEnumerator SlideRoutine()
    {
        isSliding = true;
        SoundManager.instance.PlaySlide();

        capsule.height = slidingHeight;
        capsule.center = slidingCenter;

        animator.SetTrigger("Slide");

        yield return new WaitForSeconds(slideDuration);

        capsule.height = standingHeight;
        capsule.center = standingCenter;

        isSliding = false;
    }
}