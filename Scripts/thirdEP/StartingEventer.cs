using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingEventer : MonoBehaviour
{

    [SerializeField] GameObject mainEvent;

    private void Start()
    {
        
        if (Observer.GetEventOp() != 0)
        {
            if ((Observer.GetEventOp() & (int)Events.StartingPoint) == (int)Events.StartingPoint)
                Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Delay());
    }


    IEnumerator Delay() 
    {
        yield return Yielder.CustomWaitForSeconds(1f);
        CharacterMove.isPlayable = false;
        mainEvent.SetActive(true);
        Observer.SendEvent(Events.StartingPoint);
        Destroy(this.gameObject);
    }
}
