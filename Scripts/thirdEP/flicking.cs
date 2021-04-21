using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicking : MonoBehaviour
{
    float timer;
    Light lighting;

    static public bool isOkay;
    [SerializeField] GameObject mainEvent;

    private void Start()
    {
        lighting = this.GetComponent<Light>();
        StartCoroutine(Flicking());
    }



    IEnumerator Flicking()
    {
        while (true)
        {
            if (isOkay)
            {
                lighting.intensity = 1.1f;
                yield break;
            }

            timer += Time.deltaTime;
            if (timer > 300 && !GorGwangminAI.isChasing)
            {

                lighting.intensity = 0.3f;
                yield return Yielder.CustomWaitForSeconds(1f);
                lighting.intensity = 1.1f;
                yield return Yielder.CustomWaitForSeconds(0.7f);
                lighting.intensity = 0.3f;
                yield return Yielder.CustomWaitForSeconds(0.8f);
                lighting.intensity = 1.1f;
                yield return Yielder.CustomWaitForSeconds(1.3f);
                lighting.intensity = 0.3f;
            }
            
            if (lighting.intensity == 0.3f)
            {
                mainEvent.SetActive(true);

                yield break;
            }
            yield return null;
        }

    }


}
