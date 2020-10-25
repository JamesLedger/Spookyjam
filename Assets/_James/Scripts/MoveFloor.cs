using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{

    public bool isMoving;

    private void Start()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject moveCheck = GameObject.Find("MoveManager");
        MovementManager currentVal = moveCheck.GetComponent<MovementManager>();

        if (!currentVal.isWaiting)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, -0.05f);
        }
          
    }
}
