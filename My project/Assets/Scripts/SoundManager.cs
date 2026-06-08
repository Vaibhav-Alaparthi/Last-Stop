using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource sfxSource;

    public AudioClip jumpSound;
    public AudioClip slideSound;
    public AudioClip shieldSound;
    public AudioClip deathSound;

    void Awake()
    {
        instance = this;
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    public void PlaySlide()
    {
        sfxSource.PlayOneShot(slideSound);
    }

    public void PlayShield()
    {
        sfxSource.PlayOneShot(shieldSound);
    }

    public void PlayDeath()
    {
        sfxSource.PlayOneShot(deathSound);
    }
}