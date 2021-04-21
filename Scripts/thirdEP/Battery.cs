using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Key
{
    [SerializeField] GameObject flash;
    Light flashlight;

    override public IEnumerator Begotten()
    {
        yield return Yielder.CustomWaitForSeconds(3f);
        this.transform.hasChanged = false;

        while (true)
        {
            if (this.transform.hasChanged)
            {
                Debug.Log("되냐");
                get.Play();
                flicking.isOkay = true;
                flashlight = flash.GetComponent<Light>();
                flashlight.intensity = 1.5f;
                yield return Yielder.CustomWaitForSeconds(0.5f);
                Destroy(this.gameObject);
                yield break;
            }
            yield return Yielder.CustomWaitForSeconds(0.2f);
        }


    }

}
