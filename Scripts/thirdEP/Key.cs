using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] public AudioSource get;

    private void Start()
    {
       /* if (Observer.GetItemHaving() != null)
        {
            for (int i = 0; i < Observer.GetItemHaving().Count; i++)
            {
                if (Observer.GetItemHaving()[i].Equals(this.gameObject.name))
                    Destroy(this.gameObject);
            }
        }
       */

        StartCoroutine(Begotten());
    }


    virtual public IEnumerator Begotten()
    {
        yield return Yielder.CustomWaitForSeconds(2f);

        this.transform.hasChanged = false;

        while (true) {
            if (this.transform.hasChanged==true)
            {
                get.Play();
                CharacterMove.inventory.Add(this.gameObject.name);
                //Observer.SendItemHaving(CharacterMove.inventory);
                Destroy(this.gameObject);
                yield break;
            }
            yield return null;
        }
    
    
    }



}
