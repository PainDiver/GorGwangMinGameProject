using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChair : MonoBehaviour
{
    [SerializeField] AudioSource chairs;
    [SerializeField] GameObject character;

    public bool GTG;
    float timer;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (timer > 15f || Vector3.Distance(this.transform.position, character.transform.position) < 10f)
            {
                GTG = false;
                yield break;
            }
            if (GTG)
            {
                timer += Time.deltaTime;
                if (!chairs.isPlaying)
                    chairs.Play();
                this.transform.position += -this.transform.forward * 50f * Time.deltaTime;
            }
            yield return null;
        }
    }
}
