using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingBag : MonoBehaviour
{
    [SerializeField] GameObject Bag;


    private void Start()
    {
        if (Observer.GetEventOp()!=0)
        {
            if (!((Observer.GetEventOp() & (int)Events.EventDoor2) == (int)Events.EventDoor2))
                Destroy(this.gameObject);
                
        }
        StartCoroutine(DropBag());
    }



    IEnumerator DropBag()
    {
        while (true)
        {
            if (this.GetComponent<Door>().isOpened)
            {
                Observer.SendEvent(Events.EventDoor2);
                Bag.SetActive(true);
                yield break;
            }
            yield return null;
        }
    }


}
