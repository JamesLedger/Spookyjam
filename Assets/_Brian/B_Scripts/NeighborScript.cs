﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NeighborScript : MonoBehaviour
{
    [Header("Neighbor Classification")]
    [Tooltip("If human neighbor, check true. If monster, leave as false.")]
    public bool isHuman;

    [Space]
    public float responseTimer;
    public TextMesh timerText;

    private bool timerRunning;

    private GestureDetector gestureDetector;

    private GameManagerScript gameMngr;
    public GameObject leftHandAnchor, rightHandAnchor;

    void Awake() 
    {
        // Finds a GameObject named Gesture Detector, and gets it's Gesture Detector component and assigns it to the variable.
        // It's not pretty, but it works.
        gestureDetector = GameObject.Find("/GestureDetector").GetComponent<GestureDetector>();
        timerText = this.transform.Find("TextDebug").GetComponent<TextMesh>();

        gameMngr = GameObject.Find("GameManager").GetComponent<GameManagerScript>();


    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<color=red>Neighbor started.</color>");
        responseTimer = 10f;
        timerRunning = false;
        leftHandAnchor = gameMngr.leftHandAnchor;
        rightHandAnchor = gameMngr.rightHandAnchor;
    }


     public IEnumerator FlipNeighbor(float time)
    {
        Debug.Log("<color=red>Flipping started.</color>");
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            transform.RotateAround(transform.position, Vector3.right * -1, 180 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.5f);
        timerRunning = true;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (responseTimer > 0 && timerRunning)
        {
            /*
            // Checks for Candy gesture while timer is above 0. (Must be human)
            if(
               (gestureDetector.Recognise().leftHandGesture == "Candy" && (-30f < leftHandAnchor.transform.eulerAngles.x && leftHandAnchor.transform.eulerAngles.x < 10f)) || 
               (gestureDetector.Recognise().rightHandGesture == "Candy" && (-30f < rightHandAnchor.transform.eulerAngles.x && rightHandAnchor.transform.eulerAngles.x < 10f)) 
               && isHuman)
            {
                Debug.Log("<color=green>Human gives candy.</color>");
                GameManagerScript.playerScore++;
                timerRunning = false;
            }
            */

            // Checks for FingerGun gesture while timer is above 0. (Must be monster)
            if(gestureDetector.Recognise().leftHandGesture == "FingerGun" || gestureDetector.Recognise().rightHandGesture == "FingerGun")
            {
                if(isHuman)
                {
                    responseTimer = 1f;
                    timerRunning = false;

                    // Remove one life.
                    GameManagerScript.playerLives--;
                }

                else
                {
                    Debug.Log("<color=green>Monster killed.</color>");
                    GameManagerScript.playerScore++;
                    timerRunning = false;
                    GameObject moveCheck = GameObject.Find("MoveManager");
                    MovementManager currentVal = moveCheck.GetComponent<MovementManager>();
                    currentVal.isWaiting = false;
                }
            }

            // Must be last thing inside this if statement.
            responseTimer -= Time.deltaTime;
            timerText.text = "" + responseTimer;
        }

        else if(timerRunning)
        {
            responseTimer = 1f;
            timerRunning = false;

            if(isHuman)
            {
                GameManagerScript.playerLives++;
            }
            else
            {
                // Remove one life.
                GameManagerScript.playerLives--;
            }
        }
    }
}
