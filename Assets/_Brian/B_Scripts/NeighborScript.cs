using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NeighborScript : MonoBehaviour
{
    /*
    // Was trying to do it with Enums, gave up.
    [System.Serializable]
    public enum neighborState {human, monster};
    */
    [Header("Neighbor Classification")]
    [Tooltip("If human neighbor, check true. If monster, leave as false.")]
    public bool isHuman;

    [Space]
    public float responseTimer;
    public TextMesh timerText;
    public GestureDetector gestureDetector;

    public Vector3 currentAngle, upAngle;

    void Awake() 
    {
        // Finds a GameObject named Gesture Detector, and gets it's Gesture Detector component and assigns it to the variable.
        // It's not pretty, but it works.
        gestureDetector = GameObject.Find("/GestureDetector").GetComponent<GestureDetector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.eulerAngles;
        upAngle = new Vector3(45, 45, 45);
        responseTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (responseTimer > 0)
        {
            if(gestureDetector.Recognise().leftHandGesture == "Candy" || gestureDetector.Recognise().rightHandGesture == "Candy" && isHuman)
            {
                GameManagerScript.playerScore++;
                killThis();
            }

            // Must be last thing inside this if statement.
            responseTimer -= Time.deltaTime;
            timerText.text = "" + responseTimer;
        }
        else
        {
            currentAngle = new Vector3(Mathf.LerpAngle(currentAngle.x, upAngle.x, Time.deltaTime * 5),0,0);
            transform.eulerAngles = currentAngle;
        }
    }

    void killThis()
    {
        Destroy(this, 0.5f);
    }
}
