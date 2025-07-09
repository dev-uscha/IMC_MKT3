using UnityEngine;

public class EagleCircularFlight : MonoBehaviour
{
    public float radius = 10f;                // Kreisgröße
    public float speed = 1f;                  // Fluggeschwindigkeit
    public float verticalAmplitude = 2f;      // Auf/Ab-Bewegung
    public float verticalFrequency = 0.5f;    // Frequenz der Schwebebewegung
    public Transform centerObject;            // Zentrum des Kreises

    private float timeOffset;

    void Start()
    {
        timeOffset = Random.Range(0f, 100f); // für Asynchronität
    }

    void Update()
    {
        float t = (Time.time + timeOffset) * speed;

        // Kreisbahn um das Zentrum (XZ-Ebene)
        float x = radius * Mathf.Cos(t);
        float z = radius * Mathf.Sin(t);

        // Auf-/Ab-Bewegung (Y)
        float y = verticalAmplitude * Mathf.Sin(t * verticalFrequency);

        Vector3 center = centerObject != null ? centerObject.position : Vector3.zero;
        transform.position = center + new Vector3(x, y, z);

        // Flugrichtung (Tangente der Kreisbahn)
        Vector3 forward = new Vector3(-Mathf.Sin(t), 0f, Mathf.Cos(t));
        if (forward != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }
}
