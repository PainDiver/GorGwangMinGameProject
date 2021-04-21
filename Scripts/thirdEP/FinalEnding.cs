using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEnding : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject mainEvent;
    [SerializeField] GameObject[] gorgwangmins;

    bool endingOn = true;

    private void Start()
    {
        StartCoroutine(LastCheck());
    }


    IEnumerator LastCheck()
    {
        while (true)
        {
            if ((this.GetComponent<OpeningDoor>().isOpened == true) && (endingOn))
            {
                for(int i=0;i<gorgwangmins.Length;i++)
                    Destroy(gorgwangmins[i]);
                fadein.isEnding = true;
                fadeOut.SetActive(true);
                yield return Yielder.CustomWaitForSeconds(2.5f);
                endingOn = false;
                TextEvent.func = End;
                mainEvent.SetActive(true);
                fadeOut.SetActive(false);
            }
            yield return Yielder.CustomWaitForSeconds(0.2f);
        }
    }


    IEnumerator End()
    {
        TextEvent.func -= End;
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DataController.stage++;
                DataController._save();
                fadein.isEnding = false;
                SceneManager.LoadScene("FinalScene");
                yield break;
            }
            yield return null;
        }
    }


}
