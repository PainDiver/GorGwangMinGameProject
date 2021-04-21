using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingEvent : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject look;
    [SerializeField] Canvas[] eventCanvas;
    [SerializeField] GameObject fadeWall;

    Text[] texts;
    List<string> originalText;
    float timer = 0;
    int textIndex = 0;


    private void Start()
    {
        originalText = new List<string>();
        texts = eventCanvas[2].GetComponentsInChildren<Text>();

        for (int i = 0; i < texts.Length; i++)
        {
            originalText.Add(texts[i].text);
            texts[i].text = "";
        }
    }


    IEnumerator LookSchool()
    {
        while (true)
        {
            timer += Time.deltaTime;
            yield return null;
            Vector3 dir = look.transform.position - cam.transform.position;
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.LookRotation(dir), timer/2);
            if (timer >= 2)
            {
                timer = 0;
                eventCanvas[0].gameObject.SetActive(true);
                eventCanvas[1].gameObject.SetActive(true);
                eventCanvas[2].gameObject.SetActive(true);

                yield break;
            }
        }
    }

    IEnumerator Talk()
    {
        while (true)
        {
            for (int i = 0; i < originalText[textIndex].Length - 1; i++)
            {
                texts[textIndex].text += originalText[textIndex][i];
                yield return new WaitForSeconds(0.07f);
            }

            yield return new WaitUntil(() => Input.GetMouseButton(0));
            texts[textIndex].gameObject.SetActive(false);
            if (textIndex++ == texts.Length - 1)
            {
                for (int i = 0; i < eventCanvas.Length; i++)
                    eventCanvas[i].gameObject.SetActive(false);
                fadein.isEnding = true;
                yield break;
            }
        }

    }

    void EndCheck()
    {
        if (fadein.isEnding == true)
        {
            StopCoroutine("EndCheck");
            fadeWall.SetActive(true);
            Invoke("End", 3f);
        }
    }

    void End()
    {
        
        DataController.stage++;
        DataController._save();
        
        CharacterMove.isPlayable = true;
        SceneManager.LoadScene("thirdEP");
        fadein.isEnding = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        CharacterMove.isPlayable = false;
        TerrainSound.isPlayableMusic = false;
        StartCoroutine(LookSchool());
        StartCoroutine(Talk());
        InvokeRepeating("EndCheck", 0, 2f);
    }


}
