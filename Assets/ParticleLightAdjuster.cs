using UnityEngine;

public class ParticleLightAdjuster : MonoBehaviour
{
    public Light sceneLight; // Reference to the light affecting the scene
    public Material particleMaterial; // Material of the particle system

    [Range(0, 100)] public float transparency;
    
    private void Update()
    {
        if (sceneLight != null && particleMaterial != null)
        {
            float lightIntensity = sceneLight.intensity;
        }
    }
}