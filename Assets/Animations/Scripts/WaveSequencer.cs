using UnityEngine;

public class WaveSequencer : MonoBehaviour
{
    public GameObject[] waveParts; // Array für Wave01 bis Wave07
    public float interval = 0.2f;  // Zeit zwischen Umschalten

    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        // Deaktiviere alle zu Beginn
        foreach (GameObject part in waveParts)
        {
            if (part != null)
                part.SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            // Alle deaktivieren
            for (int i = 0; i < waveParts.Length; i++)
            {
                if (waveParts[i] != null)
                    waveParts[i].SetActive(false);
            }

            // Aktuelles aktivieren
            if (waveParts[currentIndex] != null)
                waveParts[currentIndex].SetActive(true);

            // Zum nächsten Element
            currentIndex = (currentIndex + 1) % waveParts.Length;
        }
    }
}
