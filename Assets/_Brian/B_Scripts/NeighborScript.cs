using System.Collections;
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
        Debug.Log("<color=red>Neighbor started.</color>");
        responseTimer = 10f;
        timerRunning = false;
    }


     public IEnumerator FlipNeighbor(float time)
    {
        Debug.Log("<color=red>Flipping started.</color>");
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            transform.RotateAround(transform.position, Vector3.right * -1, 179 * Time.deltaTime);
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

        else if(timerRunning)
        {
            responseTimer = 1f;
            timerRunning = false;

            // Remove one life.
            GameManagerScript.playerLives--;

        }
    }
}
