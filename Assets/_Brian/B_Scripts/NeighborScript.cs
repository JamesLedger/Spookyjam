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

    private bool timerRunning;

    private GestureDetector gestureDetector;

    private GameManagerScript gameMngr;
    private GameObject leftHandAnchor, rightHandAnchor;

    void Awake() 
    {
        // Finds a GameObject named Gesture Detector, and gets it's Gesture Detector component and assigns it to the variable.
        // It's not pretty, but it works.
        gestureDetector = GameObject.Find("/GestureDetector").GetComponent<GestureDetector>();

        gameMngr = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        
        // Get costume (material)
        var costume = GetComponentInChildren<MeshRenderer>().material;
        // Choose costume from list
        if(isHuman)
        {
            //GetComponentInChildren<MeshRenderer>().material = costume;
        }
        else
        {

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<color=red>Neighbor started.</color>");
        // Timer to "respond" to neighbor
        responseTimer = 1f;
        timerRunning = false;
        leftHandAnchor = gameMngr.leftHandAnchor;
        rightHandAnchor = gameMngr.rightHandAnchor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (responseTimer > 0 && timerRunning)
        {
            // Checks for FingerGun gesture while timer is above 0. (Must be monster)
            if(gestureDetector.Recognise().leftHandGesture == "FingerGun" || gestureDetector.Recognise().rightHandGesture == "FingerGun")
            {
                if(isHuman)
                {
                    // Remove one life.
                    GameManagerScript.playerLives--;
                }

                else
                {
                    Debug.Log("<color=green>Monster killed.</color>");
                    GameManagerScript.playerScore++;

                }
                
                StartCoroutine(this.GetComponent<NeighborScript>().KillMonster(0.5f));
                responseTimer = 1f;
                timerRunning = false;
                GameObject.Find("MoveManager").GetComponent<MovementManager>().isWaiting = false;
            }

            // Must be last thing inside this if statement.
            responseTimer -= Time.deltaTime;
        }

        else if(timerRunning)
        {
            responseTimer = 1f;
            timerRunning = false;

            if(isHuman)
            {
                GameManagerScript.playerScore++;
            }
            else
            {
                // Remove one life.
                GameManagerScript.playerLives--;

                StartCoroutine(this.GetComponent<NeighborScript>().MonsterBite());
            }

            StartCoroutine(this.GetComponent<NeighborScript>().KillMonster(0.5f));
            GameObject.Find("MoveManager").GetComponent<MovementManager>().isWaiting = false;
        }
    }


    public IEnumerator MonsterBite()
    {
        
        Debug.Log("Monster Bite");       
        yield return new WaitForSeconds(0.5f);
        // Play SFX here
        // Play PS here
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

    public IEnumerator KillMonster(float time)
    {
        Debug.Log("<color=red>Slidding started.</color>");
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            transform.RotateAround(transform.position, Vector3.right, 180 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.5f);
    }
}
