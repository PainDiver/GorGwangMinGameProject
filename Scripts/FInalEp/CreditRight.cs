using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditRight : MonoBehaviour
{
    float timer;

    void Start()
    {
        StartCoroutine(MoveLeft());
    }

    IEnumerator MoveLeft()
    {
        while (timer < 5f)
        {
            timer += Time.deltaTime;
            this.transform.position += this.transform.right * Time.deltaTime*5;
            yield return null;
        }
    }
}
