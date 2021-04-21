using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProteinEvent : MonoBehaviour
{
    [SerializeField] GameObject mainEvent;
    [SerializeField] GameObject whey;
    [SerializeField] GameObject character;
    [SerializeField] GameObject gorGwangmin;
    [SerializeField] GameObject[] warpPoint;
    [SerializeField] GameObject face;
    [SerializeField] AudioSource bgm;

    NavMeshAgent nav;

    float timer;

    private void Start()
    {
        if (Observer.GetEventOp() != 0)
        {
            if ((Observer.GetEventOp() & (int)Events.Protein) == (int)Events.Protein)
                Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (!GorGwangminAI.isChasing)
        {
            if (other.transform.CompareTag("Player"))
            {
                TextEvent.func = ShowMonster;
                StartCoroutine(LookSlowly(character,whey));
                mainEvent.SetActive(true);
            }
        }
        
    }


    IEnumerator ShowMonster()
    {
        TextEvent.func -= ShowMonster;
        face.SetActive(true);
        Observer.SendEvent(Events.Protein);
        Observer.SendSpawnPos(3);
        Observer.SendItemNum(CharacterMove.item + 1);
        DataController._save();
        nav = gorGwangmin.GetComponent<NavMeshAgent>();
        Vector3 dir = face.transform.position - character.transform.position;
        StartCoroutine(LookSlowly(character,face));
        StartCoroutine(MoveSlowly(face));
        bgm.Play();
        yield return Yielder.CustomWaitForSeconds(1);
        nav.Warp(warpPoint[0].transform.position);
        nav.SetDestination(warpPoint[1].transform.position);
        this.gameObject.SetActive(false);
    }


    IEnumerator LookSlowly(GameObject subject,GameObject look)
    {
        Vector3 dir = look.transform.position - subject.transform.position;
        

        while (timer < 1)
        {
            timer += Time.deltaTime;
            subject.transform.rotation = Quaternion.Slerp(subject.transform.rotation, Quaternion.LookRotation(dir), timer * 3);
            yield return null;
        }
        timer = 0;
    }

    IEnumerator MoveSlowly(GameObject face)
    {
        while (timer < 3)
        {
            timer += Time.deltaTime;
            face.transform.position += Vector3.forward * 20f *Time.deltaTime;
            yield return null;
        }
        timer = 0;


    }


}
