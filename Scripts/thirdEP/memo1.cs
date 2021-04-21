using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memo1 : MonoBehaviour
{
    [SerializeField] AudioSource booksound;
    [SerializeField] GameObject text;
    [SerializeField] GameObject character;


    private void Start()
    {
        StartCoroutine(CheckMemo());
    }


    IEnumerator CheckMemo()
    {
        yield return Yielder.CustomWaitForSeconds(3f);

        while (true)
        {
            Debug.Log(Vector3.Distance(this.transform.position, character.transform.position));
            if (text.gameObject.activeSelf==false&&Vector3.Distance(this.transform.position, character.transform.position) < 15f && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("good");
                text.gameObject.SetActive(true);
              
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                text.gameObject.SetActive(false);
                
            }
            else if(Vector3.Distance(this.transform.position,character.transform.position)>15f)
                text.gameObject.SetActive(false);

            yield return null;
        }
    
    }


}
