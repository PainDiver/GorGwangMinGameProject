using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleOption : MonoBehaviour
{
    [SerializeField] Slider vsl;


    static public float mouseSensivity = 2;

    public void CheckVolume()
    {
        AudioListener.volume = vsl.value;
    
    }


    public void ExitOption()
    {
        this.gameObject.SetActive(false);
        TitleScene.isOption = false;
    }

    public void SaveOption()
    {
        mouseSensivity = transform.Find("MouseSensivity").GetComponent<Slider>().value;
        OptionDataController._save();
    }

    public void CheckSensivity()
    {
      if(transform.Find("MouseSensivity").GetComponent<Slider>().value.ToString().Length<2)
        transform.Find("MouseSensivity/MouseSensivityText").GetComponent<Text>().text = transform.Find("MouseSensivity").GetComponent<Slider>().value.ToString().Substring(0);
      else
        transform.Find("MouseSensivity/MouseSensivityText").GetComponent<Text>().text = transform.Find("MouseSensivity").GetComponent<Slider>().value.ToString().Substring(0,3);
    }

}
