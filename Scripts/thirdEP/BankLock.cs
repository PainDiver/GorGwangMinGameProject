using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BankLock : MonoBehaviour
{
    [SerializeField] string key;
    [SerializeField] AudioSource unlock;
    [SerializeField] GorGwangminAI gorgwangmin;
    NavMeshAgent nav;
    [SerializeField] GameObject currentPoint;

    void Start()
    {

        nav = gorgwangmin.GetComponent<NavMeshAgent>();
        this.transform.hasChanged = false;
        StartCoroutine(CheckOpened());
    }

    

    IEnumerator CheckOpened()
    {
        yield return Yielder.CustomWaitForSeconds(3f);
        while (true)
        {
            if (this.transform.hasChanged)
            {
                Debug.Log(this.transform.hasChanged);
                while (true)
                {
                    if (this.transform.hasChanged)
                    {
                        Debug.Log("잘됨");
                        if (CharacterMove.inventory.Contains(key))
                        {
                            CharacterMove.inventory.Remove(key);
                            unlock.Play();
                            yield return Yielder.CustomWaitForSeconds(0.8f);
                            Destroy(this.transform.gameObject);
                            nav.SetDestination(currentPoint.transform.position);
                            yield break;
                        }
                    }
                    yield return Yielder.CustomWaitForSeconds(0.2f);
                }
            }
            yield return Yielder.CustomWaitForSeconds(0.1f);
        }
    
    }


}
