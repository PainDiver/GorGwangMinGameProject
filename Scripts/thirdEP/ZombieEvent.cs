using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEvent : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] GameObject mainEvent;

    float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LookSlowly(this.gameObject));
            mainEvent.SetActive(true);
        }
    }



    IEnumerator LookSlowly(GameObject look)
    {
        Vector3 dir = look.transform.position - character.transform.position;

        while (timer < 1)
        {
            timer += Time.deltaTime;
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(dir), timer * 8);
            yield return null;
        }
    }


}
