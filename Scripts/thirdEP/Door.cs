using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour
{
    [SerializeField] public bool isLocked;
    [SerializeField] public bool isOpened;
}
