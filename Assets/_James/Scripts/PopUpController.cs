using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public Vector3 upAngle = new Vector3(-90f, 0f, 0f);
    public Vector3 downAngle = new Vector3(-90f, 0f, 0f);

    private Vector3 currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "popUp")
        {
            Debug.Log("Pop Up");
            currentAngle = new Vector3(Mathf.LerpAngle(currentAngle.x, upAngle.x, Time.deltaTime * 5),0,0);
            transform.eulerAngles = currentAngle;
        }
        else if(other.tag == "popDown")
        {
            Debug.Log("Pop Down");
            currentAngle = new Vector3(0, 0, 0);
            transform.eulerAngles = currentAngle;
        }
    }
}
