using UnityEngine;

public class ParticleLightAdjuster : MonoBehaviour
{
    public Light sceneLight;  // Reference to the light affecting the scene
    public Material particleMaterial;  // Material of the particle system

    void Start()
    {

    }

    void Update()
    {
        if (sceneLight != null && particleMaterial != null)
        {
            float lightIntensity = sceneLight.intensity;
            Color baseColor = particleMaterial.GetColor("_BaseColor");
            particleMaterial.SetColor("_BaseColor", baseColor * lightIntensity);
        }
    }
}
