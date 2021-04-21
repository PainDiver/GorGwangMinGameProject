using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSound : MonoBehaviour
{
    [SerializeField] GameObject mainCharacter;
    [SerializeField] AudioSource walk;
    [SerializeField] AudioSource run;
    Animator characterAnim;

    static public bool isPlayableMusic = true;

    private void Start()
    {
        characterAnim = mainCharacter.GetComponent<Animator>();
        StartCoroutine(SoundEffect());
    }


    // Update is called once per frame




    IEnumerator SoundEffect()
    {
        while (true)
        {
            if (characterAnim.GetBool("isMove") == true && CharacterMove.isPlayable == true)
            {
                if (!CharacterMove.isRunning && !walk.isPlaying)
                {
                    walk.Play();
                    Debug.Log("played");
                }
                else if (CharacterMove.isRunning && !run.isPlaying)
                {
                    run.Play();
                    Debug.Log("played");
                }
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
                walk.Stop();
                run.Stop();
            }

            yield return null;
        }
    }

}
