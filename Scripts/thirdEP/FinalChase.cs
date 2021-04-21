using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalChase : MonoBehaviour
{
    [SerializeField] GameObject gorGwangmin2;
    [SerializeField] GameObject warpPoint;
    [SerializeField] GameObject[] blocks;
    [SerializeField] GameObject character;
    [SerializeField] AudioSource bgm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && CharacterMove.item == 4)
        {
            bgm.Play();
            gorGwangmin2.GetComponent<NavMeshAgent>().Warp(warpPoint.transform.position);
            gorGwangmin2.GetComponent<NavMeshAgent>().SetDestination(character.transform.position);
            for(int i = 0; i < blocks.Length; i++)
                blocks[i].SetActive(true);
        }

    }



}
