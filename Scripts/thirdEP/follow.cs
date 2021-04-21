using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follow : MonoBehaviour
{
    [SerializeField] GameObject[] patrols;
    [SerializeField] GameObject gor;
    [SerializeField] AudioSource chase;

    Queue<GameObject> patrolWay;

    bool played;
    NavMeshAgent AI;
    private void Start()
    {
        patrolWay = new Queue<GameObject>();
        AI = gor.GetComponent<NavMeshAgent>();
        for (int i = 0; i < patrols.Length; i++)
        {
            patrolWay.Enqueue(patrols[i]);
            Debug.Log("ENQUE");
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && played==false)
        {
            StartCoroutine(FindPlayer());
            played = true;
        }
    }


    IEnumerator FindPlayer()
    {
        chase.Play();
        AI.Warp(patrolWay.Dequeue().transform.position);
        Debug.Log(patrolWay.Count);
        while (patrolWay.Count != 0)
        {
            AI.SetDestination(patrolWay.Dequeue().transform.position);
            yield return Yielder.CustomWaitForSeconds(5f);
        }
    }


}
