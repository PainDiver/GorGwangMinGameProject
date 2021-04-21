using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    Light light;
    AudioSource audio;
    float timer=0;

    IEnumerator Lightening()
    {
        while (true)
        {
            while (timer < 2)
            {
                timer += 0.05f;
                light.intensity = Random.Range(0.3f, 2f);
                yield return new WaitForSeconds(0.05f);
            }
            audio.Play();
            timer = 0;
            light.intensity = 0.3f;
            yield return new WaitForSeconds(12f);
        }
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        light = GetComponent<Light>();
        StartCoroutine("Lightening");
    }




}
