using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GwangminAttack : MonoBehaviour
{
    [SerializeField] AudioSource laugh;

    float timer;

    void Start()
    {
        StartCoroutine(Go());    
    }


    IEnumerator Go()
    {
        yield return Yielder.CustomWaitForSeconds(1f);
        laugh.Play();
        while (timer<5)
        {
            timer = Time.deltaTime;
            this.transform.position += this.transform.forward * timer * -90;
            yield return null;
        }
    }
}
