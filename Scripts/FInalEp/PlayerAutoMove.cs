using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject look;
    [SerializeField] GameObject DiaryHolder;

    [SerializeField] AudioSource[] audioCase;
    [SerializeField] GameObject diaryPage;
    float timer;
    Vector3 ToDiarydir;
    Vector3 Diaryrot;

    void Start()
    {
        DataController.stage++;
        ToDiarydir = (new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(this.transform.position.x,0, this.transform.position.z)).normalized;
        Diaryrot = DiaryHolder.transform.rotation.eulerAngles;
        StartCoroutine(GotoDiary());
    }

    IEnumerator GotoDiary()
    {
        yield return Yielder.CustomWaitForSeconds(3f);

        StartCoroutine(Look());

        yield return Yielder.CustomWaitForSeconds(2f);

        while (timer < 3)
        {
            if (!audioCase[0].isPlaying)
                audioCase[0].Play();
            timer += Time.deltaTime;
            this.transform.position += ToDiarydir * Time.deltaTime *5;
            this.transform.LookAt(look.transform.position);
            yield return null;
            if (timer >= 3)
            {
                timer = 0;
                audioCase[0].Stop();
                break;
            }
        }

        while (timer < 2)
        {
            timer += Time.deltaTime;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(look.transform.position - this.transform.position), timer / 2);
            yield return null;
            if (timer >= 2)
            {
                timer = 0;
                StartCoroutine(OpenDiary());
                yield break;
            }
        }

    }

    IEnumerator OpenDiary()
    {
        while (timer < 1.5f)
        {
            if (!audioCase[1].isPlaying)
            {
                audioCase[1].Play();
                Debug.Log("ㅇㅇ");
            }
            timer += Time.deltaTime;
            DiaryHolder.transform.rotation = Quaternion.Euler(Diaryrot.x, Diaryrot.y, Diaryrot.z - timer*120);
            if (timer >= 1.5f)
            {
                timer = 0;
                diaryPage.SetActive(true);
                yield break;
            }
            yield return null;
        }
    
    }

    IEnumerator Look()
    {
        while (timer < 2)
        {
            timer += Time.deltaTime;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(look.transform.position - this.transform.position), timer / 2);
            yield return null;
            if (timer >= 2)
            {
                timer = 0;
                yield break;
            }
        }
    }


}

