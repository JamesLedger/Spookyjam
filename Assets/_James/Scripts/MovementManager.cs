using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager :MonoBehaviour
{
    public bool isWaiting;

    void Awake()
    {
        isWaiting = false;
    }
}
