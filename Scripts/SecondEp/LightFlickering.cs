using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    Light light;
    MeshRenderer color;

    private void Start()
    {
        color = this.GetComponent<MeshRenderer>();
        light = this.GetComponent<Light>();
        InvokeRepeating("Flicker",Random.Range(0,4),0.1f);
    }


    private void Flicker()
    {
        light.intensity = Random.Range(0.4f,1.5f);
        color.material.color = color.material.color * light.intensity;
    }


}
