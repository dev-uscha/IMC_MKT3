using UnityEngine;

public class BirdInfinityFlight : MonoBehaviour
{
    public float radius = 5f;
    public float speed = 1f;
    public float verticalAmplitude = 1f;
    public float verticalFrequency = 0.5f;
    public Transform centerObject; // <-- neu

    private float timeOffset;

    void Start()
    {
        timeOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float t = (Time.time + timeOffset) * speed;

        float x = radius * Mathf.Sin(t);
        float z = radius * Mathf.Sin(t) * Mathf.Cos(t);
        float y = verticalAmplitude * Mathf.Sin(t * verticalFrequency);

        Vector3 center = centerObject != null ? centerObject.position : Vector3.zero;

        transform.position = center + new Vector3(x, y, z);

        Vector3 direction = new Vector3(
            radius * Mathf.Cos(t),
            verticalAmplitude * verticalFrequency * Mathf.Cos(t * verticalFrequency),
            radius * (Mathf.Cos(t) * Mathf.Cos(t) - Mathf.Sin(t) * Mathf.Sin(t))
        ).normalized;

        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
