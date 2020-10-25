using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOnDoor : MonoBehaviour
{
    
    public bool isKnocking;

    // Privates

    private AudioSource knockSFX;
    private GestureDetector gestureDetector;
    private GameObject spawnPoint;


    // Neighbor Spawn
    public GameObject[] neighborOptions;

    // Door Rotation Variables
    private Vector3 targetAngle, currentAngle;


    void Awake() 
    {
        gestureDetector = GameObject.Find("GestureDetector").GetComponent<GestureDetector>();
        spawnPoint = this.transform.Find("Spawn").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        knockSFX = GetComponent<AudioSource>();
        // Calculated in Editor, messing around with the door.
        targetAngle = new Vector3(-90f, 0f, -90f);
        currentAngle = transform.eulerAngles;

        // Redundant because every default bool is false, but better safe than sorry. ¯\_(ツ)_/¯
        isKnocking = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "OVRHand")
        {
            Debug.Log("Door triggered by" + other.gameObject.name);
            // There's a "bug" here where player can collide with door with one hand, but have the fist done with another hand, and the door still will react. 
            // Too tired to write the fix. But it involves parametrizing the if function below into:
            // if(other.gameObject.name == "LeftHandPrefab", handColliding == LeftHandPrefab.SkeletonMesh) or something like that.
            // if(handColliding == "Fist" && !isKnocking)
            if(gestureDetector.Recognise().leftHandGesture == "Fist" || gestureDetector.Recognise().rightHandGesture == "Fist" && !isKnocking)
            {
                Debug.Log("<color=blue>Knocking recognized.");
                isKnocking = true;
                knockSFX.Play();
                StartCoroutine(OpenDoor(targetAngle, 2f));
            }
        }   
    }


    private IEnumerator OpenDoor(Vector3 finishAngle, float time)
    {
        var pivot = this.transform.parent.gameObject;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            pivot.transform.RotateAround(pivot.transform.position, Vector3.up * -1, 45 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if(neighborOptions.Length < 1)
        {
            Debug.LogError("Neighbor list is empty.");
        }
        else
        {
            var index = Random.Range (0, neighborOptions.Length);
            Instantiate(neighborOptions[index], spawnPoint.transform.position, neighborOptions[index].transform.rotation);
        }
    }
}
