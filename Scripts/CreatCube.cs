using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCube : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(CreateCoroutine());
    }

    IEnumerator CreateCoroutine() 
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject t_object = ObjectPoolingManager.instance.GetQueue();
            t_object.transform.position = Vector3.zero;

        }

    }

    
}
