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

    private bool timerRunning;

    private GestureDetector gestureDetector;

    public Vector3 currentAngle, upAngle;

    void Awake() 
    {
        // Finds a GameObject named Gesture Detector, and gets it's Gesture Detector component and assigns it to the variable.
        // It's not pretty, but it works.
        gestureDetector = GameObject.Find("/GestureDetector").GetComponent<GestureDetector>();
        timerText = this.transform.Find("TextDebug").GetComponent<TextMesh>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.eulerAngles;
        upAngle = new Vector3(45, 45, 45);
        responseTimer = 10f;
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (responseTimer > 0 && timerRunning)
        {
            // Checks for Candy gesture while timer is above 0. (Must be human)
            if(gestureDetector.Recognise().leftHandGesture == "Candy" || gestureDetector.Recognise().rightHandGesture == "Candy" && isHuman)
            {
                GameManagerScript.playerScore++;
                timerRunning = false;
            }

            // Checks for Fireball gesture while timer is above 0. (Must be monster)
            if(gestureDetector.Recognise().leftHandGesture == "Fireball" || gestureDetector.Recognise().rightHandGesture == "Fireball" && !isHuman)
            {
                GameManagerScript.playerScore++;
                timerRunning = false;
            }

            // Must be last thing inside this if statement.
            responseTimer -= Time.deltaTime;
            timerText.text = "" + responseTimer;
        }
        else
        {
            // Remove one life.
            GameManagerScript.playerLives--;
        }
    }
}
