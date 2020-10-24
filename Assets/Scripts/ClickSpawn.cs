using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public bool spawnReady;
    public bool hasSpawned;

    void Start()
    {
        spawnReady = false;
        hasSpawned = false;
    }

    public GameObject spawnObject;
    public Transform spawnPos;

    // Update is called once per frame
    void Update()
    {
        GestureDetector detector = GetComponent<GestureDetector>();
        CurrentHandInfo info = detector.Recognise();

        if (info.rightHandGesture == "Candy")
        {
            spawnReady = true;
            hasSpawned = false;
        }

        if (info.rightHandGesture == "Fireball" && spawnReady == true)
        {
            spawnReady = false;
            hasSpawned = true;

            GameObject tempCube = Instantiate(spawnObject);
            tempCube.transform.position = spawnPos.position;
        }


    }
}
