using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGesture : MonoBehaviour
{
    private GestureDetector gestureDetector;

    private float startTime = 0f;

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
        startTime += Time.deltaTime;
        if ((gestureDetector.Recognise().leftHandGesture == "Ok" || gestureDetector.Recognise().rightHandGesture == "Ok") && startTime > 0.5f)
        {
            GameObject.Find("MoveManager").GetComponent<MovementManager>().isWaiting = false;
            Destroy(gameObject);
        }
    }
}
