using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGesture : MonoBehaviour
{
    private GestureDetector gestureDetector;

    // Start is called before the first frame update
    void Awake()
    {
        gestureDetector = GameObject.Find("/GestureDetector").GetComponent<GestureDetector>();
        counter = 0;
    }

    int counter;

    // Update is called once per frame
    void Update()
    {
        if (counter > 200)
        {
            if (gestureDetector.Recognise().leftHandGesture == "Ok" || gestureDetector.Recognise().rightHandGesture == "Ok")
            {
                Destroy(gameObject);
                GameObject.Find("MoveManager").GetComponent<MovementManager>().isWaiting = false;

            }
        }
        else
        {
            counter++;
        }
    }
}
