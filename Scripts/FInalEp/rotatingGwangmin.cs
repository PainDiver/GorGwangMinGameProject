using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingGwangmin : MonoBehaviour
{
    float timer;
    Vector3 rot;
    void Start()
    {
        rot = this.transform.rotation.eulerAngles;
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        while (true)
        {
            timer += Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(rot.x,rot.y+timer*60,rot.z);
            yield return null;
        }
    }
}
