using UnityEngine;

public class WaterReflectionCapsule : MonoBehaviour
{
    private Vector3 initialScale;
    private float baseHeight;
    private float timeOffset;
    private float disappearTimer;
    private bool isVisible = true;

    public float minHeight = 0.1f;
    public float maxHeight = 1;
    public float speed = 2f;
    public float disappearChance = 0.01f; // 1% Chance pro Frame zu verschwinden
    public float disappearDuration = 0.5f;

    private Renderer capsuleRenderer;

    void Start()
    {
        initialScale = transform.localScale;
        baseHeight = initialScale.y;
        timeOffset = Random.Range(0f, 100f); // Asynchronität
        capsuleRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Verschwinden lassen
        if (isVisible && Random.value < disappearChance)
        {
            isVisible = false;
            disappearTimer = disappearDuration;
            capsuleRenderer.enabled = false;
        }

        if (!isVisible)
        {
            disappearTimer -= Time.deltaTime;
            if (disappearTimer <= 0f)
            {
                isVisible = true;
                capsuleRenderer.enabled = true;
            }
            return;
        }

        // Höhe animieren
        float scaleY = Mathf.Lerp(minHeight, maxHeight,
            (Mathf.Sin((Time.time + timeOffset) * speed) + 1f) / 2f);

        Vector3 scale = transform.localScale;
        scale.y = scaleY;
        transform.localScale = scale;
    }
}
