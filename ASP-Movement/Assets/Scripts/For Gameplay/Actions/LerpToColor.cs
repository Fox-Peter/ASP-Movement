using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToColor : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] [Range(0f, 40f)] private float lerpTime;
    
    [SerializeField] private Color color;

    // Update is called once per frame
    void Update()
    {
        var colorModule = _particleSystem.colorOverLifetime;

        Gradient gradient = colorModule.color.gradient;

        GradientColorKey[] colorKeys = gradient.colorKeys;
        GradientAlphaKey[] alphaKeys = gradient.alphaKeys;

        colorKeys[0].color = Color.Lerp(colorKeys[0].color, color, lerpTime * Time.deltaTime);
        //colorKeys[0].color = Color.red;

        gradient.SetKeys(colorKeys, alphaKeys);

        colorModule.color = gradient;
    }
}
