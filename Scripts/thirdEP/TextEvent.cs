using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEvent : MonoBehaviour
{
    [SerializeField] Text[] texts;
    [SerializeField] Text textUI;
    [SerializeField] GameObject GettableItem =null;

    string contents;
    Queue<Text> textOrder;

    public delegate IEnumerator eventBox();

    public static eventBox func;

    [SerializeField] int textToLeave;


    private void OnEnable()
    {
        GorGwangminAI.isMovable = false;
        CharacterMove.isPlayable = false;
        textOrder = new Queue<Text>();
        for (int i = 0; i < texts.Length; i++)
            textOrder.Enqueue(texts[i]);
        StartCoroutine(StartEvent());
    }


    IEnumerator StartEvent()
    {   
        while (textOrder.Count != textToLeave)
        {
            for (int j = 0; j < textOrder.Peek().text.Length + 1; j++)
            {
                contents = textOrder.Peek().text.Substring(0, j);
                textUI.text = contents;
                if (Input.GetMouseButton(1))
                {
                    j = textOrder.Peek().text.Length + 1;
                    textUI.text = textOrder.Peek().text;
                }

                yield return Yielder.CustomWaitForSeconds(0.05f);
            }
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            textOrder.Dequeue();
        }
        if(func != null)    
            StartCoroutine(func());

        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));


        while (textOrder.Count != 0)
        {
            for (int j = 0; j < textOrder.Peek().text.Length + 1; j++)
            {
                contents = textOrder.Peek().text.Substring(0, j);
                textUI.text = contents;
                if (Input.GetMouseButton(1))
                {
                    j = textOrder.Peek().text.Length + 1;
                    textUI.text = textOrder.Peek().text;
                }
                yield return Yielder.CustomWaitForSeconds(0.05f);
            }
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            textOrder.Dequeue();
        }

        Destroy(this.gameObject);
        CharacterMove.isPlayable = true;
        GorGwangminAI.isMovable = true;
        if (GettableItem)
        {
            GettableItem.SetActive(false);
            CharacterMove.item++;
        }
    }


}
