using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JingyuEvent : MonoBehaviour
{
    [SerializeField] Text[] diaryPages;
    [SerializeField] GameObject image;
    [SerializeField] GameObject character;
    [SerializeField] GameObject diary;
    [SerializeField] GameObject mainEvent;
    [SerializeField] AudioSource water;
    float timer;

    private void Start()
    {
        
        if (Observer.GetEventOp()!=0)
        {
            if ((Observer.GetEventOp() & (int)Events.JinGyu) == (int)Events.JinGyu)
                Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GorGwangminAI.isChasing)
        {
            if (other.transform.CompareTag("Player"))
            {
                water.Play();
                TextEvent.func = ShowDiary;
                StartCoroutine(LookSlow(diary));
                mainEvent.SetActive(true);
            }
        }
    }

    IEnumerator ShowDiary()
    {
        TextEvent.func -= ShowDiary;
        image.SetActive(true);
        for (int i = 0; i < diaryPages.Length; i++)
        {
            diaryPages[i].gameObject.SetActive(true);
            yield return Yielder.CustomWaitForSeconds(1f);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
        image.SetActive(false);
        
        Observer.SendEvent(Events.JinGyu);
        Observer.SendSpawnPos(1);
        Observer.SendItemNum(CharacterMove.item + 1);
        DataController._save();
        
        Destroy(this.gameObject);

    }

    IEnumerator LookSlow(GameObject Target)
    {
        while (timer < 1)
        {
            timer += Time.deltaTime;
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(Target.transform.position - character.transform.position), timer);
            yield return null;
        }
    }
}
