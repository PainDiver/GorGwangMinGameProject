using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{


    private void Start()
    {
        StartCoroutine(Disappear());
    }


    IEnumerator Disappear()
    {
        while (true)
        {
            if (CharacterMove.item == 4)
            {
                Destroy(this.gameObject);
                yield break;
            }
            yield return new WaitForSeconds(8f);
        }
    }

}
