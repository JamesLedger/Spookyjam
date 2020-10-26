using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_load : MonoBehaviour
{
    //scene navigation index
    [SerializeField]
    private int waitingRoomSceneIndex;

    private GestureDetector gestureDetector;

    private int counter;

    // Start is called before the first frame update
    void Awake()
    {
        counter = 0;
        gestureDetector = GameObject.Find("/GestureDetector").GetComponent<GestureDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 200)
        {
            if (gestureDetector.Recognise().leftHandGesture == "Ok" || gestureDetector.Recognise().rightHandGesture == "Ok")
            {  
                // load into waiting room scene
                SceneManager.LoadScene(waitingRoomSceneIndex);
            }
        }
        else
        {
            counter++;
        }
    }
}
