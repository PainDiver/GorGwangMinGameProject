using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    Rigidbody m_myrigid = null;

    private void OnEnable()
    {
        if (m_myrigid == null)
        {
            m_myrigid = GetComponent<Rigidbody>();
        }

        m_myrigid.velocity = Vector3.zero;
        m_myrigid.AddExplosionForce(200, transform.position+ new Vector3(Random.Range(0,1f), -1f, Random.Range(0, 1f)), 5f);

        StartCoroutine(DestroyCube());
       
    }

   

    IEnumerator DestroyCube()
    {
        yield return new WaitForSeconds(5f);
        ObjectPoolingManager.instance.InsertQueue(gameObject);
    }

    public void RotateCube()
    {
        this.transform.RotateAround(new Vector3(-Time.deltaTime * Random.Range(-100,-300), 0, 0), Vector3.up, 1f);
    }

}
