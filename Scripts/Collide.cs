using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    Collider col;

    [SerializeField] Camera cam;
    [SerializeField] GameObject character;
    [SerializeField] float speed;
    float mouseSensivity;

    float x;
    float y;
    float mx;
    float my;

    private void Awake()
    {
        col = GetComponent<Collider>();
        mouseSensivity = TitleOption.mouseSensivity;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {

        character.transform.forward = new Vector3(cam.transform.forward.x,0,cam.transform.forward.z);
        character.transform.right = cam.transform.right;
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical") ;

        Vector3 dir = character.transform.right* x + character.transform.forward *y;

        this.transform.position += dir.normalized * speed *Time.deltaTime;
    }


    private void Look()
    {
        Vector3 camRot = this.transform.rotation.eulerAngles;

        mx = Input.GetAxis("Mouse X") *mouseSensivity;
        my = Input.GetAxis("Mouse Y") *mouseSensivity;

        float rotX = camRot.x - my;
        float rotY = camRot.y + mx;


        if ( rotX <340 && rotX > 40 && my < 0)
        {
            rotX = Mathf.Clamp(rotX, -1, 40);
        }
        else if( rotX>40 && rotX <340 && my> 0) 
        {
            rotX = Mathf.Clamp(rotX, 340, 361);
        }

        Debug.Log(rotX);
        this.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }






}
