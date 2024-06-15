using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class VignetteIntensity : MonoBehaviour
{
    public VignetteIntensity intensity;
    public HealthScript healthScript;
    public float intensity1;

    private void Update()
    {
        intensity = GetComponent<VignetteIntensity>();
        
    }

}
