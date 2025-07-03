using UnityEngine;

public class Pulsate : MonoBehaviour
{
    public float pulseSpeed = 0.5f;         // Wie schnell das Pulsieren erfolgt
    public float pulseAmount = 0.1f;      // 20% größer

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        float scaleFactor = 1 + Mathf.Sin(Time.time * pulseSpeed) * (pulseAmount / 2f);
        transform.localScale = initialScale * scaleFactor;
    }
}
