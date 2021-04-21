using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : Door
{
    float openingTime;
    float closingTime;
    Vector3 origin;
    Quaternion originQuat;

    private void Start()
    {
        this.transform.hasChanged = false;
        isOpened = false;
        origin = this.transform.rotation.eulerAngles;
        originQuat = this.transform.rotation;
    }

    private void Update()
    {
        if (!isLocked)
        {
            Open();
            Close();
        }
    }

    void Open()
    {
        if (!isOpened && this.transform.hasChanged==true)
        {
            Debug.Log("Opening");
            openingTime += Time.deltaTime;
            if (openingTime <= 1)
            {
                this.transform.rotation = Quaternion.Euler(origin.x, origin.y + Mathf.Lerp(0, 90, openingTime), origin.z);
            }
            else
            {
                this.transform.hasChanged = false;
                isOpened = true;
                openingTime = 0;
            }
        }

    }

    void Close()
    {
        if (isOpened && this.transform.hasChanged==true)
        {
            closingTime += Time.deltaTime;
            if (closingTime <= 1)
            {
                this.transform.hasChanged = true;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, originQuat, closingTime);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(origin);
                this.transform.hasChanged = false;
                isOpened = false;
                closingTime = 0;
            }
        }


    }

}
