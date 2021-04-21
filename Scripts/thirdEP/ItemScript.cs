using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    Text itemNumber;

    private void Start()
    {
        itemNumber = GetComponent<Text>();
        StartCoroutine(CheckItem());
    }

    IEnumerator CheckItem()
    {
        while (true)
        {
            if (CharacterMove.item == 4)
            {
                itemNumber.text = "Run Back Home";
            }
            else
            {
                itemNumber.text = CharacterMove.item + "/4";
            }
            yield return Yielder.CustomWaitForSeconds(0.5f);
        }
    }

}
