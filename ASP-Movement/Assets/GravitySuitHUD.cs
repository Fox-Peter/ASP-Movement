using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GravitySuitHUD : MonoBehaviour
{
    [SerializeField] private GameObject visionVFX;
    [SerializeField] private VisualEffect electricityVFX;

    [SerializeField] [Range(0f, 100f)] 
    private float trailsSpawnRate;

    private float currentTrailsSpawnRate;

    [SerializeField] [Range(0f, 10f)] float lerpTime;

    private Color visionVFXColor;
    private bool state;

    private void Start()
    {
        visionVFXColor = visionVFX.GetComponentInChildren<ParticleSystemRenderer>().material.color;
        electricityVFX.SetFloat("TrailsSpawnRate", trailsSpawnRate);
        currentTrailsSpawnRate = trailsSpawnRate;

        state = true;
        Toggle();
    }


    private void Update()
    {
        var vision = visionVFX.GetComponentInChildren<ParticleSystemRenderer>();

        if (state)
        {
            vision.material.color = Color.Lerp(vision.material.color, Color.black, lerpTime * Time.deltaTime);
            currentTrailsSpawnRate = Mathf.Lerp(currentTrailsSpawnRate, 0, lerpTime * Time.deltaTime);
            electricityVFX.SetFloat("TrailsSpawnRate", currentTrailsSpawnRate);
        }
        else
        {
            vision.material.color = Color.Lerp(vision.material.color, visionVFXColor, lerpTime * Time.deltaTime);
            currentTrailsSpawnRate = Mathf.Lerp(currentTrailsSpawnRate, trailsSpawnRate, lerpTime * Time.deltaTime);
            electricityVFX.SetFloat("TrailsSpawnRate", currentTrailsSpawnRate);
        }
    }

    public void Toggle()
    {
        state = !state;
        Debug.Log("Toggle Gravity Suit HUD");
    }
}
