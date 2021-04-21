using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationChamber : MonoBehaviour
{
    [SerializeField] GameObject mainEvent;


    private void Start()
    {
        
        if (Observer.GetEventOp() != 0)
        {
            if ((Observer.GetEventOp() & (int)Events.OperationChamber) == (int)Events.OperationChamber)
                Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GorGwangminAI.isChasing && other.CompareTag("Player"))
        {
            mainEvent.SetActive(true);
            Observer.SendEvent(Events.OperationChamber);
            Destroy(this.gameObject);
        }
    }


}
