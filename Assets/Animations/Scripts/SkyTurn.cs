using UnityEngine;

public class SkyTurn : MonoBehaviour
{
    
    // Rotationsgeschwindigkeit in Grad pro Sekunde
    public float rotationSpeed = 3f;

    void Update()
    {
        // Drehung um die Y-Achse (nach oben)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
