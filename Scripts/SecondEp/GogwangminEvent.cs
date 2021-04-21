using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogwangminEvent : MonoBehaviour
{
    [SerializeField] GameObject gogwangmin;

    private void OnTriggerEnter(Collider other)
    {
        gogwangmin.SetActive(true);
    }
}
