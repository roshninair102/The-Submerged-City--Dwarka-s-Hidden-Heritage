using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UnderwaterEffect : MonoBehaviour
{
    public Volume postProcessingVolume;   // Reference to the Post Processing Volume
    public Color underwaterColor = new Color(0.0f, 0.4f, 0.7f); // Bluish tint for underwater
    public float fogDensity = 0.04f;       // Density of fog underwater

    private bool isUnderwater = false;
    private Color originalFogColor;
    private float originalFogDensity;

    void Start()
    {
        // Save the initial fog settings
        originalFogColor = RenderSettings.fogColor;
        originalFogDensity = RenderSettings.fogDensity;

        // Initially disable the post-processing underwater effects
        if (postProcessingVolume != null)
        {
            postProcessingVolume.enabled = false;
        }
    }

    void Update()
    {
        // Example check for whether the player is underwater (y-coordinate threshold)
        if (transform.position.y < 0 && !isUnderwater)
        {
            EnterWater();
        }
        else if (transform.position.y >= 0 && isUnderwater)
        {
            ExitWater();
        }
    }

    void EnterWater()
    {
        isUnderwater = true;

        // Change fog settings to simulate underwater fog
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = fogDensity;

        // Enable underwater post-processing effects
        if (postProcessingVolume != null)
        {
            postProcessingVolume.enabled = true;
        }
    }

    void ExitWater()
    {
        isUnderwater = false;

        // Revert fog settings
        RenderSettings.fogColor = originalFogColor;
        RenderSettings.fogDensity = originalFogDensity;

        // Disable underwater post-processing effects
        if (postProcessingVolume != null)
        {
            postProcessingVolume.enabled = false;
        }
    }
}
