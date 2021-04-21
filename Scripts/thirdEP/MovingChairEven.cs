using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChairEven : MonoBehaviour
{
    [SerializeField] GameObject chair;

    Rigidbody rigd;
    MovingChair gtg;

    private void Start()
    {

        gtg = chair.GetComponent<MovingChair>();
        rigd = chair.GetComponent<Rigidbody>();
        rigd.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            rigd.isKinematic = false;
            gtg.GTG = true;
            Destroy(this.gameObject);
        }
    }

}
