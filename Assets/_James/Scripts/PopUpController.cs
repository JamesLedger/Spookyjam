using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public Vector3 upAngle = new Vector3(-90f, 0f, 0f);
    public Vector3 downAngle = new Vector3(-180f, 0f, 0f);
    private Vector3 currentAngle;

    public bool raiseHouse;
    public bool lowerHouse;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    void Update() 
    {
        if(raiseHouse && !lowerHouse)
        {
            currentAngle = new Vector3(Mathf.LerpAngle(currentAngle.x, upAngle.x, Time.deltaTime * 5),0,0);
            transform.eulerAngles = currentAngle;
        }
        if(lowerHouse && !raiseHouse)
        {
            currentAngle = new Vector3(Mathf.LerpAngle(currentAngle.x, downAngle.x, Time.deltaTime * 5),0,0);
            transform.eulerAngles = currentAngle;
        }
    }
}
