using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public class Diary : MonoBehaviour
{
    [SerializeField] Text[] content;
    [SerializeField] Text[] textBox;
    [SerializeField] AudioSource writingSound;
    [SerializeField] AudioSource knock;
    [SerializeField] AudioSource gorGwangminSound;
    [SerializeField] GameObject gorgwangmin;
    [SerializeField] GameObject character;
    [SerializeField] Image image;
    [SerializeField] Image ender;
    [SerializeField] AudioSource BGM;
    [SerializeField] PostProcessVolume ppv;
    Vignette vig;

    Vector3 dir;

    Queue<string> text;

    int textBoxindex = 0;
    float timer;


    private void OnEnable()
    {
        ppv.profile.TryGetSettings(out vig);
        dir = (character.transform.position - gorgwangmin.transform.position).normalized;
        text = new Queue<string>();
        for (int i = 0; i < content.Length; i++)
            text.Enqueue(content[i].text);
        StartCoroutine(Read());
    }


    IEnumerator Read()
    {
        yield return Yielder.CustomWaitForSeconds(1f);
        vig.intensity.value = 0.7f;
        for (int i = 0; i < text.Peek().Length + 1; i++)
        {
            textBox[textBoxindex].text = text.Peek().Substring(0, i);
            if (!writingSound.isPlaying)
                writingSound.Play();
            yield return Yielder.CustomWaitForSeconds(0.05f);
        }
        knock.Play();
        vig.intensity.value = 0f;
        writingSound.Stop();
        textBoxindex++;
        text.Dequeue();
        gorgwangmin.SetActive(true);
        yield return Yielder.CustomWaitForSeconds(0.8f);
        image.gameObject.SetActive(false);
        while (timer < 1)
        {
            timer += Time.deltaTime;
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(gorgwangmin.transform.position - character.transform.position), timer);
            yield return null;
        }
        timer = 0;

        yield return Yielder.CustomWaitForSeconds(1f);
        gorGwangminSound.Play();
        while (timer < 0.5)
        {
            timer += Time.deltaTime;
            gorgwangmin.transform.position += dir * timer / 5;
            gorgwangmin.transform.LookAt(character.transform.position);
            yield return null;
        }
        ender.gameObject.SetActive(true);
        yield return Yielder.CustomWaitForSeconds(1.5f);
        BGM.Play();
        yield return Yielder.CustomWaitForSeconds(5f);
        image.gameObject.SetActive(true);
        yield return Yielder.CustomWaitForSeconds(3f);


        for (int i = 0; i < text.Peek().Length + 1; i++)
        {
            textBox[textBoxindex].text = text.Peek().Substring(0, i);
            yield return Yielder.CustomWaitForSeconds(0.2f);
        }
        textBoxindex++;
        text.Dequeue();

        for (int i = 0; i < text.Peek().Length + 1; i++)
        {
            textBox[textBoxindex].text = text.Peek().Substring(0, i);
            yield return Yielder.CustomWaitForSeconds(0.05f);
        }
        textBoxindex++;
        text.Dequeue();


        yield return Yielder.CustomWaitForSeconds(10f);
        image.gameObject.SetActive(false);
        DataController.stage++;
        DataController._save();
        SceneManager.LoadScene("EndingCredit");
    }


}
