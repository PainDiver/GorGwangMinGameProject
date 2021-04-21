using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDoor : MonoBehaviour
{

    [SerializeField] GameObject body;
    OpeningDoor self;


    private void Start()
    {
        self = this.GetComponent<OpeningDoor>();
    }


    IEnumerator CheckEvent()
    {
        while (true)
        {
            if (!self.isOpened && this.transform.hasChanged)
            {
                if (body.activeSelf == false)
                {
                    body.SetActive(true);
                    yield break;

                }
            }

            yield return Yielder.CustomWaitForSeconds(0.1f);
        }
    }


    private void Update()
    {
        if (!self.isOpened && this.transform.hasChanged)
        {
            if (body.activeSelf == false)
                body.SetActive(true);
        }
    }
}
