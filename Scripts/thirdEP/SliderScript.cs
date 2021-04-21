using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    Slider slide;
    float stamina;

    private void Start()
    {
        slide = GetComponent<Slider>();
    }


    void Update() 
    {
        stamina = CharacterMove.stamina;
        slide.value = stamina;
    }


}
