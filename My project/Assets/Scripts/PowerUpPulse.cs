using UnityEngine;

public class PowerUpPulse : MonoBehaviour
{
    public float pulseSpeed = 4f;
    public float minScale = 2.1f;
    public float maxScale = 2.6f;

    void Update()
    {
        float scale = Mathf.Lerp(
            minScale,
            maxScale,
            (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f
        );

        transform.localScale = new Vector3(scale, scale, scale);
    }
}