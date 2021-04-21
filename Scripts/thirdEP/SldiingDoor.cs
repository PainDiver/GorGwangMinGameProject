using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SldiingDoor : Door
{
    float openingTime;
    float closingTime;
    Vector3 originCl;
    Vector3 originOp;
    
    private void Start()
    {
        this.transform.hasChanged = false;
        isOpened = false;
        originOp = this.transform.position;
        originCl = this.transform.position + this.transform.right * 11f;
    }

    void Open()
    {
        if (!isOpened && this.transform.hasChanged == true)
        {
            Debug.Log("opening");
            openingTime += Time.deltaTime;
            if (openingTime <= 1)
                this.transform.position = Vector3.Lerp(this.transform.position, originCl, openingTime);
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
        if (isOpened && this.transform.hasChanged == true)
        {
            closingTime += Time.deltaTime;

            if (closingTime <= 1)
                this.transform.position = Vector3.Lerp(this.transform.position, originOp, closingTime);
            else
            {
                this.transform.hasChanged = false;
                isOpened = false;
                closingTime = 0;
            }

        }
 
    }

    private void Update()
    {
        if (!isLocked)
        {
            Open();
            Close();

        }
    }
}
