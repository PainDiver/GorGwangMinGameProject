using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GorGwangminAI : MonoBehaviour
{
    [SerializeField] GameObject character;
    Vector3 dir;
    float distance;
    float viewAngle;
    float timer;
    static public bool isMovable = true;
    static public bool isChasing;

    [SerializeField] AudioSource openingDoor;
    [SerializeField] AudioSource sopeningDoor;
    [SerializeField] AudioSource footStepSound;
    [SerializeField] GameObject eye;
    [SerializeField] GameObject[] ways;
    [SerializeField] GameObject outeriorDoor;
    [SerializeField] AudioSource chasingSound;
    [SerializeField] AudioSource gorSound;
    [SerializeField] GameObject[] spawn;

    Door eventDoor;

    Animator anim;
    NavMeshAgent nav;
    
    int Patrollimit = 33;
    float runningSpeed;
    float originalSpeed;

    

    Transform[] wayPoints;
    Vector3 currentTarget;

    private void Start()
    {
        int spawnI = Random.Range(0, 3);
         
        Patrollimit = 33;
        eventDoor = outeriorDoor.GetComponent<Door>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        wayPoints = new Transform[ways.Length];
        runningSpeed = nav.speed + 5;
        originalSpeed = nav.speed;
        nav.Warp(spawn[spawnI].transform.position
            );

        for (int i = 0; i < ways.Length; i++)
            wayPoints[i] = ways[i].transform;
        StartCoroutine(WayPointCheck());
        Patrol();
    }


    // Update is called once per frame
    void Update()
    {
        if (!isMovable)
        {
            Stop();
        }
        else
        {
            nav.isStopped = false;
            anim.SetBool("isMove", true);
            Chase();
            Targeting();
            MakeSound();
        }
    }

    private void Stop()
    {
        nav.isStopped = true;
        anim.SetBool("isMove", false);
    }


    void Chase()
    {
        dir = (character.transform.position - eye.transform.position).normalized;
        viewAngle = Vector2.Angle(this.transform.forward, dir);
        distance = Vector3.Distance(eye.transform.position, character.transform.position);
        Debug.DrawRay(eye.transform.position, dir * 300f, Color.red);
        if (Physics.Raycast(eye.transform.position, dir, out RaycastHit hitinfo, 300f) && viewAngle < 100f)
        {
            if (hitinfo.transform.CompareTag("Player"))
            {
                Debug.Log("Chasing");
                eye.transform.LookAt(hitinfo.transform.position);
                isChasing = true;
                nav.speed = runningSpeed;
                anim.SetBool("isRunning", true);
                nav.SetDestination(character.transform.position);
                StartCoroutine(followChase());
            }
            else
            {
                Debug.Log("NotChasing");
                isChasing = false;
                nav.speed = originalSpeed;
                anim.SetBool("isRunning", false);
            }
        }
    }

    IEnumerator followChase() 
    {
        while (timer<2)
        {
            timer += Time.deltaTime;
            nav.SetDestination(character.transform.position);
            yield return null;
        }
        yield return Yielder.CustomWaitForSeconds(15f);
        if (!isChasing && chasingSound.isPlaying)
            chasingSound.Stop();
        timer = 0;
    }


    void MakeSound()
    {
        if (!footStepSound.isPlaying)
        {
            footStepSound.volume = Mathf.Lerp(0, 0.8f, 1 / distance * 10);
            footStepSound.Play();
        }
        if (!gorSound.isPlaying)
        {
            gorSound.volume = Mathf.Lerp(0, 0.8f, 1 / distance * 10);
            gorSound.Play();
        }
        if (isChasing && !chasingSound.isPlaying)
            chasingSound.Play();
            
    }

    void Targeting()
    {
        if (Vector3.Distance(this.transform.position, nav.destination) < 1.5f)
        {
            Debug.Log("Targetting");
            Patrol();
            isChasing = false;
        }
    }

    void Patrol()
    {
        Debug.Log("Patrolling");
        currentTarget = wayPoints[Random.Range(Patrollimit, wayPoints.Length)].position;
        nav.SetDestination(currentTarget);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stair"))
            this.transform.position += new Vector3(0, 0.1f, 0);

        if (collision.transform.CompareTag("OpeningDoor"))
        {
            if (collision.gameObject.GetComponent<OpeningDoor>().isOpened == false)
            {
                collision.transform.hasChanged = true;
                openingDoor.volume = Mathf.Lerp(0, 0.8f, 1 / distance * 10);
                openingDoor.Play();
            }
        }
        else if (collision.transform.CompareTag("Door"))
        {
            if (collision.gameObject.GetComponent<SldiingDoor>().isOpened == false)
            {
                collision.transform.hasChanged = true;
                sopeningDoor.volume = Mathf.Lerp(0, 0.8f, 1 / distance * 10);
                sopeningDoor.Play();
            }
        }
    }



    IEnumerator WayPointCheck()
    {
        while (true)
        {
            if (!eventDoor.isLocked)
            {
                Patrollimit = 0;
                yield break;
            }
            yield return Yielder.CustomWaitForSeconds(5f);
        }
    }

}
