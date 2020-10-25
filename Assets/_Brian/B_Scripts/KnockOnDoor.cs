using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class KnockOnDoor : MonoBehaviour
{
    public bool isKnocking;

    // Privates
    private AudioSource knockSFX;
    private GestureDetector gestureDetector;
    private GameObject spawnPoint;
    private GameManagerScript gameMngr;
    private GameObject myNeighbor;

    void Awake() 
    {
        gestureDetector = GameObject.Find("GestureDetector").GetComponent<GestureDetector>();

        spawnPoint = gameObject.transform.parent.parent.Find("Spawn").gameObject;
        // spawnPoint = this.transform.Find("Spawn").gameObject;

        gameMngr = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        
        knockSFX = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Redundant because every default bool is false, but better safe than sorry. ¯\_(ツ)_/¯
        isKnocking = false;

        if(gameMngr.neighborList.Length < 1)
        {
            Debug.LogError("Neighbor list is empty.");
        }
        else
        {
            var index = Random.Range(0, gameMngr.neighborList.Length);
            myNeighbor = Object.Instantiate(gameMngr.neighborList[index], spawnPoint.transform.position, Quaternion.Euler(90f, 0f, 0f), spawnPoint.transform)as GameObject;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "OVRHand")
        {
            // There's a "bug" here where player can collide with door with one hand, but have the fist done with another hand, and the door still will react. 
            // Too tired to write the fix. But it involves parametrizing the if function below into:
            // if(other.gameObject.name == "LeftHandPrefab", handColliding == LeftHandPrefab.SkeletonMesh) or something like that.
            // if(handColliding == "Fist" && !isKnocking)
            if(gestureDetector.Recognise().leftHandGesture == "Fist" || gestureDetector.Recognise().rightHandGesture == "Fist" && isKnocking == false)
            {
                isKnocking = true;
                Debug.Log("Door triggered by" + other.gameObject.name);
                Debug.Log("<color=blue>Knocking recognized.</color>");
                knockSFX.Play();
                // Rotates for two seconds.
                StartCoroutine(OpenDoor(2f));
            }
        }   
    }

    private IEnumerator OpenDoor(float time)
    {
        var pivot = this.transform.parent.gameObject;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            pivot.transform.RotateAround(pivot.transform.position, Vector3.up * -1, 45 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(myNeighbor.GetComponent<NeighborScript>().FlipNeighbor(0.5f));
    }
}
