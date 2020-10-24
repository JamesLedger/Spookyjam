using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, -0.05f);
    }
}
