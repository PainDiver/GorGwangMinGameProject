using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nahobin : MonoBehaviour
{
    [SerializeField] GameObject nahobinEvent;
    [SerializeField] GameObject character;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject eventPic;
    [SerializeField] AudioSource bgm;

    float timer;


    private void Start()
    {
        
        if (Observer.GetEventOp() != 0)
        {
            if ((Observer.GetEventOp() & (int)Events.NaHoBin) == (int)Events.NaHoBin)
                this.GetComponent<Collider>().enabled = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GorGwangminAI.isChasing)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                bgm.Play();
                TextEvent.func = ShowPicture;
                StartCoroutine(LookSlowy(camera));
                nahobinEvent.SetActive(true);
            }
        }
    }



    IEnumerator ShowPicture()
    {
        TextEvent.func -= ShowPicture;
        eventPic.SetActive(true);
        yield return Yielder.CustomWaitForSeconds(2.5f);
        eventPic.SetActive(false);
        this.GetComponent<Collider>().enabled = false;
        
        Observer.SendEvent(Events.NaHoBin);
        Observer.SendSpawnPos(2);
        Debug.Log("아이템 저장 수:"+CharacterMove.item+1);
        Observer.SendItemNum(CharacterMove.item + 1);
        DataController._save();
        
    }

    IEnumerator LookSlowy(GameObject Target)
    {
        while (timer < 1)
        {
            timer += Time.deltaTime;
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(Target.transform.position - character.transform.position), timer);
            yield return null;
        }
        timer = 0;
        yield break;
    }

}
