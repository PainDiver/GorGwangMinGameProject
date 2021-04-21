using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EndEvent : MonoBehaviour
{
    [SerializeField] GameObject mainEvent;
    [SerializeField] GameObject character;
    [SerializeField] GameObject look;
    [SerializeField] GameObject gorGwangmin;
    [SerializeField] GameObject warpPoint;
    [SerializeField] AudioSource foundYou;
    float timer; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextEvent.func = AppearMonster;
            StartCoroutine(LookSlowly(look));
            mainEvent.SetActive(true);
        }
    }


    IEnumerator AppearMonster()
    {
        TextEvent.func -= AppearMonster;
        gorGwangmin.GetComponent<NavMeshAgent>().Warp(warpPoint.transform.position);
        yield return Yielder.CustomWaitForSeconds(1f);
        foundYou.Play();
        StartCoroutine(LookSlowly(gorGwangmin));
        gorGwangmin.transform.LookAt(character.transform.position);
        yield return Yielder.CustomWaitForSeconds(1f);
        StartCoroutine(KeepFollowing());
    }


    IEnumerator LookSlowly(GameObject Target)
    {
        while (timer < 2)
        {
            timer += Time.deltaTime;
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(Target.transform.position - character.transform.position), timer / 2);
            yield return null;
        }
        timer = 0;
    }

    IEnumerator KeepFollowing()
    {
        while (true)
        {
            gorGwangmin.GetComponent<NavMeshAgent>().SetDestination(character.transform.position);
            yield return Yielder.CustomWaitForSeconds(3f);
            if (Vector3.Distance(gorGwangmin.transform.position, character.transform.position) < 2f)
                yield break;
        }

    }



}
