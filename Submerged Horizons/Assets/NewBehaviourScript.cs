using UnityEngine;

public class UnderwaterFog : MonoBehaviour
{
    public float waterHeight = 0;
    public Color underwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
    public float underwaterDensity = 0.1f;

    void Update()
    {
        if (transform.position.y < waterHeight)
        {
            RenderSettings.fogColor = underwaterColor;
            RenderSettings.fogDensity = underwaterDensity;
        }
        else
        {
            RenderSettings.fogColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            RenderSettings.fogDensity = 0.01f;
        }
    }
}