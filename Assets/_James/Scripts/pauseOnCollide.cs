using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseOnCollide : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject moveCheck = GameObject.Find("MoveManager");
            MovementManager currentVal = moveCheck.GetComponent<MovementManager>();
            currentVal.isWaiting = true;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject moveCheck = GameObject.Find("MoveManager");
            MovementManager currentVal = moveCheck.GetComponent<MovementManager>();
            currentVal.isWaiting = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "waitSpot")
        {
            GameObject moveCheck = GameObject.Find("MoveManager");
            MovementManager currentVal = moveCheck.GetComponent<MovementManager>();
            currentVal.isWaiting = true;

            Debug.Log("booping ");
        }
    }
}
