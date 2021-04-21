using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorGwangmin : MonoBehaviour
{
    [SerializeField] GameObject Character;
    [SerializeField] GameObject eventPoint3;

    float timer;


    private void Start()
    {
        
        StartCoroutine(Appear());
    }


    IEnumerator Appear()
    {
        yield return Yielder.CustomWaitForSeconds(2f);
        while (true)
        {
            timer += Time.deltaTime;
            this.transform.position += Vector3.right * Time.deltaTime * 80f;
            if (timer > 1)
            {
                yield break;
            }
            yield return null;
        }
    }

}
