using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMove : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float speed;
    [SerializeField] GameObject body;

    [SerializeField] AudioSource gasp;
    [SerializeField] AudioSource openingSound;
    [SerializeField] AudioSource sopeningSound;
    [SerializeField] AudioSource chairSound;
    [SerializeField] GameObject[] SpawnPoint;

    CharacterController cc;

    public static int item = 0;

    static public float mouseSensivity;
    float x;
    float y;
    float mx;
    float my;
    float originalSpeed;
    float gravityVelocity = -9.81f;

    static public float stamina = 100;

    static public bool isPlayable = true;
    static public bool isRunning;
    static public bool isRunnable;

    static public List<string> inventory;

    Animator characterAnim;


    [SerializeField] GameObject screen;

    private void Start()
    {
        
        if (Observer.GetItemNum() != 0)
            item = Observer.GetItemNum();

        if (Observer.GetItemHaving() != null)
            inventory = Observer.GetItemHaving();


        Debug.Log(inventory.Count);
        
        
        if (DataController._jSpawnPos != null && DataController._jStage=="2")
        {
            if (int.Parse(DataController._jSpawnPos) == 0)
                this.transform.position = SpawnPoint[0].transform.position;
            else if (int.Parse(DataController._jSpawnPos) == 1)
                this.transform.position = SpawnPoint[1].transform.position;
            else if (int.Parse(DataController._jSpawnPos) == 2)
                this.transform.position = SpawnPoint[2].transform.position;
            else if (int.Parse(DataController._jSpawnPos) == 3)
                this.transform.position = SpawnPoint[3].transform.position;
        }

        cc = GetComponent<CharacterController>();

        originalSpeed = speed;
        characterAnim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseSensivity = TitleOption.mouseSensivity;
        InvokeRepeating("CheckStamina", 0, 0.1f);
    }


    //Update is called once per frame
    void Update()
    {
        Debug.Log(isPlayable);
        Move();
        Look();
        Run();
        Use();
        TurnOnOption();
    }

    private void TurnOnOption()
    {
        if ( isPlayable && screen.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            CharacterMove.isPlayable = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            screen.SetActive(true);
        }
        else if (screen.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CharacterMove.isPlayable = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            screen.SetActive(false);
        }


    }


    private void Move()
    {
        if (isPlayable)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
            characterAnim.SetFloat("dirX", x);
            characterAnim.SetFloat("dirY", y);


            body.transform.forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
            body.transform.right = cam.transform.right;

            Vector3 dir = (body.transform.forward * y + body.transform.right * x).normalized;

            Debug.Log(x);

            if (x != 0 || y != 0)
                characterAnim.SetBool("isMove", true);
            else
            {
                characterAnim.SetBool("isMove", false);
            }



            if (x != 0 || y != 0)
            {
                cc.Move(dir * speed *Time.deltaTime);
            }
            body.transform.position = this.transform.position;
        }
        cc.Move(new Vector3(0, gravityVelocity*Time.deltaTime, 0));
    }


    private void Run()
    {
        if (isPlayable && Input.GetKey(KeyCode.LeftShift) && isRunnable)
        {
            isRunning = true;
            speed = 23;
        }
        else
        {
            isRunning = false;
            speed = originalSpeed;
        }

        if (stamina < 0)
        {
            isRunnable = false;
            gasp.Play();
        }
        else if (stamina > 20)
        {
            isRunnable = true;
        }

    }




    private void Look()
    {
        if (isPlayable)
        {
            mx = Input.GetAxis("Mouse X") * mouseSensivity/2;
            my = Input.GetAxis("Mouse Y") * mouseSensivity/2;

            Vector3 origin = cam.transform.rotation.eulerAngles;

            float x = origin.x - my;
            float y = origin.y + mx;

            if ((x > 85 && x < 300) && my > 0)
                x = Mathf.Clamp(x, 300f, 361f);

            if ((x > 60 && x < 300) && my < 0)
                x = Mathf.Clamp(x, -1f, 60f);



            cam.transform.rotation = Quaternion.Euler(x, y, origin.z);
        }

    }


    private void Use()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hitinfo, 20f))
            {
                Debug.Log(hitinfo.transform.name);
                hitinfo.transform.hasChanged = true;

                if (hitinfo.transform.CompareTag("OpeningDoor"))
                {
                    if (!hitinfo.transform.GetComponent<OpeningDoor>().isLocked)
                        openingSound.Play();

                }
                else if (hitinfo.transform.CompareTag("Door"))
                {
                    if (!hitinfo.transform.GetComponent<SldiingDoor>().isLocked)
                        sopeningSound.Play();
                }
            }
        }
    }



    void CheckStamina()
    {
        if (isRunning)
        {
            stamina -= 2f;
        }
        else if (stamina < 100)
        {
            stamina += 0.5f;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stair"))
            this.transform.position += new Vector3(0, 0.07f, 0);

        if (collision.gameObject.CompareTag("furniture"))
            if (!chairSound.isPlaying)
            {
                chairSound.Play();
            }
    }

}
