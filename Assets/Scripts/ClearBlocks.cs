using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBlocks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
        var gameObjects = GameObject.FindGameObjectsWithTag("cubee");

        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);

        Debug.Log("trigger");
    }
}
