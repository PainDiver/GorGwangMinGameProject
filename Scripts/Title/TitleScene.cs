using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    public static bool isOption;
    [SerializeField] GameObject wall;
    [SerializeField] Camera cam;
    [SerializeField] Button[] Buttons;
    [SerializeField] Button but;
    [SerializeField] GameObject[] diary;
    float timer;


    private void Start()
    {
        if(DataController._jStage=="4")
            but.gameObject.SetActive(true);
    }


    public void PlayGame()
    {
        
        DataController._clear();
        DataController._load();
        
        StartCoroutine(FadeOutTitle());
        for (int i = 1; i < Buttons.Length; i++)
            Buttons[i].gameObject.SetActive(false);
        Invoke("ChangeScene", 4f);
    }

    private IEnumerator FadeOutTitle()
    {
        while (true)
        {
            wall.transform.position = cam.transform.position + cam.transform.forward * 1.3f;
            timer += 0.1f;
            wall.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, timer / 2);
            if (timer < 0)
                yield break;
            yield return new WaitForSeconds(0.1f);
        }
    }



    public void ChangeScene()
    {
            SceneManager.LoadScene("firstEp");
    }



    public void OpenOption()
    {
            gameObject.transform.Find("optionCanvas").GetComponent<Canvas>().gameObject.SetActive(true);
            isOption = true;
    }


    public void Exit()
    {
            Application.Quit();
    }

    public void Credit()
    {
        SceneManager.LoadScene("EndingCredit");

    }

    public void Load()
    {
        DataController._load();

        if (DataController._jStage.Equals("1") && !isOption)
        {
            StartCoroutine(FadeOutTitle());
            SceneManager.LoadScene("secondEP");

        }
        else if (DataController._jStage.Equals("2") && !isOption)
        {
            StartCoroutine(FadeOutTitle());
            SceneManager.LoadScene("thirdEP");
        }
        else if (DataController._jStage.Equals("3") && !isOption)
        {
            StartCoroutine(FadeOutTitle());
            SceneManager.LoadScene("FinalScene");
        }

    }

    public void Open()
    {
        StartCoroutine(OpenBook());
    }


    IEnumerator OpenBook()
    {
        for (int i = 0; i < 4; i++)
        {
            diary[i].SetActive(true);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            if (i == 3)
                diary[i].GetComponentInParent<Canvas>().gameObject.SetActive(false);
        }
    
    }


}
