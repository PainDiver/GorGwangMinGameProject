using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundYou : MonoBehaviour
{
    [SerializeField] GameObject eventer;
    [SerializeField] AudioSource sound;

    bool isPlayed;

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        while (!isPlayed)
        {
            if (eventer.activeSelf == true)
            {
                sound.Play();
                isPlayed = true;
            }
            yield return Yielder.CustomWaitForSeconds(0.2f);
        }
    }


}
