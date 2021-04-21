using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicDoor : MonoBehaviour
{
    [SerializeField] GameObject secondGor;

    private void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        while (true)
        {
            if (CharacterMove.item == 3)
            {
                secondGor.SetActive(true);
                Destroy(this.gameObject);
                yield break;
            }
            yield return Yielder.CustomWaitForSeconds(4f);
        }
    }
}
