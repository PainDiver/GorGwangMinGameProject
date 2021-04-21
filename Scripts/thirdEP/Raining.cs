using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raining : MonoBehaviour
{
    [SerializeField] GameObject rain;

    private void Start()
    {

        if ((Observer.GetEventOp() & (int)Events.Rain) == (int)Events.Rain)
        {
            rain.SetActive(true);
            Destroy(this.gameObject);
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (CharacterMove.inventory != null)
        {
            if (other.CompareTag("Player") && CharacterMove.inventory.Contains("outeriorKey"))
            {
                Observer.SendEvent(Events.Rain);
                rain.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }


}
