using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour
{
    [SerializeField] Text skipText;
    [SerializeField] GameObject key;
    [SerializeField] Text[] diary;
    List<string> copied;

    short textNumber;
    short textIndex;
    bool isOver;

    private void Start()
    {
        textNumber = 0;
        textIndex = 1;
        copied = new List<string>();

        for (int i = 0; i < diary.Length; i++)
            copied.Add(diary[i].text);

        StartCoroutine("Type");
    }

    IEnumerator Type()
    {
        while (true)
        {
            diary[textNumber].gameObject.SetActive(true);
            diary[textNumber].text = copied[textNumber].Substring(0, textIndex);
            ++textIndex;
            yield return new WaitForSeconds(0.05f);

            if (copied[textNumber].Length == (textIndex - 1))
            {
                textIndex = 1;
                textNumber++;
                if (textNumber == diary.Length)
                {
                    yield return Yielder.CustomWaitForSeconds(1.5f);
                    key.gameObject.SetActive(true);
                    isOver = true;
                    yield break;
                }
            }

        }
    }

    private void Update()
    {
        skip();
        Play();

    }

    private void skip()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < diary.Length; i++)
            {
                StopCoroutine("Type");
                diary[i].gameObject.SetActive(true);
                diary[i].text = copied[i];
            }
            isOver = true;
            key.gameObject.SetActive(true);
        }

        if (isOver == true)
            skipText.text = "Enter to Play";

    }


    public void Play()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            DataController.stage++;
            DataController._save();
            SceneManager.LoadScene("secondEP");
        }
    }


}
