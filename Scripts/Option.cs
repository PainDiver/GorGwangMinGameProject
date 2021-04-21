using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{

    [SerializeField] GameObject OptionCanvas;

    public void Resume()
    {
        this.GetComponentInParent<Image>().gameObject.SetActive(false);
        CharacterMove.isPlayable = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenOption()
    {
        OptionCanvas.SetActive(true);
    }

    public void GoToMain()
    {
        CharacterMove.isPlayable = true;
        SceneManager.LoadScene("Title");
    }

}
