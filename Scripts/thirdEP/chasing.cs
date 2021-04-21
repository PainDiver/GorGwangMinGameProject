using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasing : MonoBehaviour
{
    [SerializeField] AudioSource laugh;
    [SerializeField] GameObject warpPos;
    [SerializeField] GameObject character;

    Vector3 pos;

    private void OnEnable()
    {
        pos = this.transform.position;
        StartCoroutine(StartChasing());
    }



    IEnumerator StartChasing()
    {
        while (true)
        {
            this.transform.position = new Vector3(character.transform.position.x + 25f, pos.y, pos.z);
            this.transform.LookAt(character.transform.position);
            yield return null;
        }
    }

}
