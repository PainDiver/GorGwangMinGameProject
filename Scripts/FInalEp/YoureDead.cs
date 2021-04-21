using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YoureDead : MonoBehaviour
{
    Text gameoverText;
    Color color;
    float timer;

    void Start()
    {
        gameoverText = GetComponent<Text>();
        color = gameoverText.color;
        StartCoroutine(gameOver());
    }



    IEnumerator gameOver()
    {
        yield return Yielder.CustomWaitForSeconds(3f);
        while (true)
        {
            timer += Time.deltaTime;
            gameoverText.color = new Color(color.r, color.g, color.b, timer);
            yield return null;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Title");
                yield break;
            }
        }

    }


}
