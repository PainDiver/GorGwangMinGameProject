using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerOption : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Text sliderNum;
    [SerializeField] Slider vslider;
    
    public void ControlSlider()
    {
      CharacterMove.mouseSensivity = slider.value;
        if (slider.value.ToString().Length < 2)
            sliderNum.text = slider.value.ToString().Substring(0);
        else
            sliderNum.text = slider.value.ToString().Substring(0,3);
    }

    public void Vslider()
    {
        AudioListener.volume = vslider.value;

    }


    public void FullScreen()
    {
        Screen.fullScreen = true;
    }

    public void HalfScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ExitOption()
    {
        this.gameObject.SetActive(false);
    }

}
