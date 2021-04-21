using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditLeft : MonoBehaviour
{
    float timer;

    void Start()
    {
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        while (timer < 5f)
        {
            timer += Time.deltaTime;
            this.transform.position += -this.transform.right * Time.deltaTime * 10;
            yield return null;
        }
    }
}
