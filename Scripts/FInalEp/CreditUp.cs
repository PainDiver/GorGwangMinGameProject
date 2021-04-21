using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditUp : MonoBehaviour
{
    void Update()
    {
        this.transform.position += this.transform.up * 8 * Time.deltaTime;   
    }
}
