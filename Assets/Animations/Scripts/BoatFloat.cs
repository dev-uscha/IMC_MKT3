using UnityEngine;

public class BoatFloat : MonoBehaviour
{
    public float bobbingAmplitude = 0.2f;       // Höhe des Schaukelns (Rotation)
    public float bobbingFrequency = 1f;         // Geschwindigkeit des Schaukelns

    public float driftAmplitude = 0.5f;         // Seitliches Verschieben
    public float driftFrequency = 0.3f;         // Geschwindigkeit des Driftens

    private Vector3 startPos;
    private Quaternion startRot;
    private float timeOffset;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        timeOffset = Random.Range(0f, 100f); // Damit nicht alle gleich schaukeln
    }

    void Update()
    {
        float t = Time.time + timeOffset;

        // Sanftes Seitwärts-Driften (X-Achse)
        float xDrift = driftAmplitude * Mathf.Sin(t * driftFrequency);
        transform.position = startPos + new Vector3(xDrift, 0f, 0f);

        // Leichtes Schaukeln (Rotation um Z – für Kippbewegung)
        float zTilt = bobbingAmplitude * Mathf.Sin(t * bobbingFrequency);
        transform.rotation = startRot * Quaternion.Euler(0f, 0f, zTilt);
    }
}
