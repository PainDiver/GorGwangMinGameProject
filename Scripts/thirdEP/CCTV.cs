using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    [SerializeField] Camera connectedCCTV;
    [SerializeField] Light CCTVLight;
    private void Start()
    {
        this.transform.hasChanged = false;
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        while (true)
        {
            if (this.transform.hasChanged && connectedCCTV.gameObject.activeSelf == false)
            {
                connectedCCTV.gameObject.SetActive(true);
                CCTVLight.intensity=0.3f;
                CharacterMove.isPlayable = false;
                this.transform.hasChanged = false;
            }
            if (this.transform.hasChanged && connectedCCTV.gameObject.activeSelf)
            {
                CCTVLight.intensity = 0f;
                CharacterMove.isPlayable = true;
                connectedCCTV.gameObject.SetActive(false);
                this.transform.hasChanged = false;
            }
            yield return null;
        }
    }




}
