using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookSchoolEvent : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject look;
    [SerializeField] Canvas[] eventCanvas;

    Text[] texts;
    List<string> originalText;
    float timer=0;
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
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.LookRotation(dir), timer);
            if (timer >= 1)
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
            for (int i = 0; i < originalText[textIndex].Length; i++)
            {
                texts[textIndex].text += originalText[textIndex][i];
                if (Input.GetMouseButton(1))
                {
                    texts[textIndex].text = originalText[textIndex];
                    i = originalText[textIndex].Length;
                }
                yield return new WaitForSeconds(0.07f);
            }

            yield return new WaitUntil(() => Input.GetMouseButton(0));
            texts[textIndex].gameObject.SetActive(false);
            if (textIndex++ == texts.Length - 1)
            {
                Destroy(this.gameObject);
                CharacterMove.isPlayable = true;
                TerrainSound.isPlayableMusic = true;
                yield break;

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterMove.isPlayable = false;
        TerrainSound.isPlayableMusic = false;
        StartCoroutine(LookSchool());
        StartCoroutine(Talk());
        
    }


}
