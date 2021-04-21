using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    [SerializeField] AudioSource dropsound;
    Rigidbody rig;

    private void OnEnable()
    {
        rig = GetComponent<Rigidbody>();
        dropsound.Play();
        StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        rig.AddForce(this.transform.up * 200, ForceMode.Impulse);
        yield return Yielder.CustomWaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
