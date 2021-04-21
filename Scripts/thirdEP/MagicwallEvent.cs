using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicwallEvent : MonoBehaviour
{
    [SerializeField] GameObject mainEvent;
    [SerializeField] GameObject character;
    [SerializeField] GameObject look;
    [SerializeField] AudioSource bell;

    Vector3 dir;
    Vector3 origin;

    private void Start()
    {
        
        if (Observer.GetEventOp() != 0)
        {
            if ((Observer.GetEventOp() & (int)Events.magicWall) == (int)Events.magicWall)
                Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GorGwangminAI.isChasing)
        {
            if (other.gameObject.CompareTag("Player") && CharacterMove.item == 3)
            {
                bell.Play();
                StartCoroutine(LookClass());
                mainEvent.SetActive(true);
            }
        }
    }


    IEnumerator LookClass()
    {
        dir = (look.transform.position - character.transform.position).normalized;
        origin = character.transform.position;

        while (Vector3.Distance(character.transform.position, look.transform.position) > 10f)
        {
            character.transform.position += dir * Time.deltaTime * 50f;
            yield return null;
        }
        yield return Yielder.CustomWaitForSeconds(3f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        character.transform.position = origin;
        Observer.SendEvent(Events.magicWall);
        Destroy(this.gameObject);
    }


}
