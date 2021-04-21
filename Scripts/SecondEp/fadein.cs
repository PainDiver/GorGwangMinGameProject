using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein : MonoBehaviour
{
    float timer;
    SpriteRenderer fadeWall;
    [SerializeField] Camera cam;
    static public bool isEnding=false;


    private void OnEnable()
    {

        fadeWall = this.GetComponent<SpriteRenderer>();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        if (isEnding == false)
        {
            fadeWall.color = new Color(0, 0, 0, 1);
            while (true)
            {
                Debug.Log("fadingin");
                this.transform.position = cam.transform.position + cam.transform.forward * 1.3f;
                this.transform.LookAt(cam.transform.position);

                timer += 0.1f;
                fadeWall.color = new Color(0, 0, 0, 1 - timer / 2);
                if (1 - timer / 2 < 0)
                {
                    this.gameObject.SetActive(false);
                    timer = 0;
                    yield break;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            fadeWall.color = new Color(0, 0, 0, 0);
            while (true)
            {
                Debug.Log("fadingout");
                this.transform.position = cam.transform.position + cam.transform.forward * 1.3f;
                this.transform.LookAt(cam.transform.position);

                timer += 0.1f;
                fadeWall.color = new Color(0, 0, 0, timer / 2);
                if (timer / 2 > 1)
                {
                    timer = 0;
                    yield break;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
