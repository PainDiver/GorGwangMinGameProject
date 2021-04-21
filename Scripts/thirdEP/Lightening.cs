using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightening : MonoBehaviour
{
    [SerializeField] GameObject lightening;
    Light thunderLight;
    [SerializeField] AudioSource thunder;
    [SerializeField] GameObject[] ghost;
    [SerializeField] GameObject character;

    int thunderStrike;
    float timer;

    void Start()
    {
        thunderLight = lightening.GetComponent<Light>();
        StartCoroutine(Lighten());
    }


    IEnumerator Lighten()
    {
        while (true)
        {
            thunderStrike = Random.Range(0, 7);
            if (thunderStrike == 6)
            {
                while (timer < 2)
                {
                    for (int i = 0; i < ghost.Length; i++)
                    {
                        ghost[i].SetActive(true);
                        ghost[i].transform.LookAt(character.transform.position);
                    }
                    if (!thunder.isPlaying)
                        thunder.Play();
                    timer += Time.deltaTime;
                    thunderLight.intensity = Random.Range(0, 3);
                    yield return null;
                }
                thunderLight.intensity = 0;
                for (int i = 0; i < ghost.Length; i++)
                {
                    ghost[i].SetActive(false);
                    ghost[i].transform.LookAt(character.transform.position);
                }
                timer = 0;
            }
            yield return Yielder.CustomWaitForSeconds(3f);
        }
    }

}
