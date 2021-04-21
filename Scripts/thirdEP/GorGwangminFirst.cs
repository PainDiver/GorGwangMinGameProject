using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class GorGwangminFirst : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] AudioSource laugh;
    [SerializeField] GameObject gor;
    [SerializeField] GameObject warp;
    [SerializeField] PostProcessVolume ppv;
    ChromaticAberration ca;
    float first_intentsity;

    Vector3 dir;
    float timer;
    

    void Start()
    {
        if (Observer.GetEventOp() != 0)
        {
            if ((Observer.GetEventOp() & (int)Events.gorgwangminLook) == (int)Events.gorgwangminLook)
            {
                Debug.Log("잘된다");
                Destroy(this.gameObject);
            }
        }

        ppv.profile.TryGetSettings(out ca);
        first_intentsity = ca.intensity.value;
        StartCoroutine(PeekPlayer());
    }


    IEnumerator PeekPlayer()
    {



        while (true)
        {
            dir = character.transform.position - this.transform.position;
            

            if (Physics.Raycast(this.transform.position, dir, out RaycastHit hitinfo, 300f))
            {
                Debug.Log("Que!");
                if (hitinfo.transform.CompareTag("Player"))
                {
                    if (Vector3.Distance(hitinfo.transform.position, this.transform.position) < 230f)
                    {
                        if (!laugh.isPlaying)
                            laugh.Play();
                        ca.intensity.value = 1f;
                    }
                    if (Vector3.Distance(hitinfo.transform.position, this.transform.position) < 230f)
                    {
                        while (timer < 4f)
                        {
                            timer += Time.deltaTime;
                            this.transform.position += Vector3.forward * Time.deltaTime * 15f;
                            yield return null;
                        }
                        Observer.SendEvent(Events.gorgwangminLook);
                        yield return Yielder.CustomWaitForSeconds(8f);
                        gor.gameObject.GetComponent<NavMeshAgent>().Warp(warp.transform.position);
                        gor.gameObject.GetComponent<NavMeshAgent>().SetDestination(character.transform.position);
                        ca.intensity.value = first_intentsity;
                        Destroy(this.gameObject);
                        yield break;
                    }
                }
            }
            yield return Yielder.CustomWaitForSeconds(0.1f);
        }
    }
}
