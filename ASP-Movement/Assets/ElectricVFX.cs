using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricVFX : MonoBehaviour
{
    [SerializeField] private Camera particleCamera;
    [SerializeField] private Vector2Int particleCameraResolution;
    [SerializeField] private RawImage targetImage;

    private RenderTexture renderTexture;

    // Start is called before the first frame update
    void Start()
    {
        renderTexture = new RenderTexture(particleCameraResolution.x, particleCameraResolution.y, 32);
        particleCamera.targetTexture = renderTexture;
        targetImage.texture = renderTexture;
    }

}
