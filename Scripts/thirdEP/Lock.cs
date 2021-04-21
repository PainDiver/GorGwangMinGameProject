using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject lockingDoor;
    [SerializeField] AudioSource unlock;
    
    [SerializeField] string key;

    void Start()
    {
        lockingDoor.GetComponent<Door>().isLocked = true;

        
        if ((this.gameObject.name.Equals("Lock")) && ((Observer.GetEventOp() & (int)Events.Lock) == (int)Events.Lock))
        {
            lockingDoor.GetComponent<Door>().isLocked = false;
            Destroy(this.gameObject);
        }
        if ((this.gameObject.name.Equals("Lock2")) && ((Observer.GetEventOp() & (int)Events.Lock2) == (int)Events.Lock2))
        {
            lockingDoor.GetComponent<Door>().isLocked = false;
            Destroy(this.gameObject);
        }
        
        this.transform.hasChanged = false;
        StartCoroutine(CheckLocked());
    }

    IEnumerator CheckLocked()
    {
        Debug.Log(this.transform.hasChanged);
        while (true)
        {
            if (this.transform.hasChanged)
            {
                Debug.Log("잘됨");
                if (CharacterMove.inventory.Contains(key))
                {
                    lockingDoor.GetComponent<Door>().isLocked = false;
                    unlock.Play();
                    if (this.gameObject.name.Equals("Lock"))
                        Observer.SendEvent(Events.Lock);
                    if (this.gameObject.name.Equals("Lock2"))
                        Observer.SendEvent(Events.Lock2);
                    yield return Yielder.CustomWaitForSeconds(1f);
                    Destroy(this.transform.gameObject);
                    yield break;
                }
            }
            yield return Yielder.CustomWaitForSeconds(0.2f);
        }
    }
}
