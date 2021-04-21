using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boo : MonoBehaviour
{
    [SerializeField] GameObject body;
    [SerializeField] GameObject character;

    [SerializeField] AudioSource laughing;
    float timer;
    Vector3 dir;
    Vector3 characterPos;

    private void Start()
    {
        
        if (Observer.GetEventOp()!=0)
        {
            if ((Observer.GetEventOp() & (int)Events.BOO) == (int)Events.BOO)
                Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            StartCoroutine(BOO());
    }

    IEnumerator BOO()
    {
        while (timer<4)
        {
            timer += Time.deltaTime;
            dir = new Vector3(character.transform.position.x,character.transform.position.y-8f,character.transform.position.z) - body.transform.position;
            body.transform.position += dir * Time.deltaTime *6f;
            if (Vector3.Distance(body.transform.position, character.transform.position) < 10f)
            {
                if(!laughing.isPlaying)
                    laughing.Play();
                break;
            }
            yield return null;
        }
        timer = 0;

        while (timer < 8)
        {
            timer += Time.deltaTime;
            characterPos = new Vector3(character.transform.position.x, character.transform.position.y - 5f, character.transform.position.z);
            body.transform.position = characterPos + character.transform.forward* 6f;
            body.transform.LookAt(character.transform.position);

            if (!laughing.isPlaying)
                laughing.Play();
            yield return null;
        }
        timer = 0;

        Observer.SendEvent(Events.BOO);
        Destroy(body);
    }




}
