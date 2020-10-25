using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManagerScript : MonoBehaviour
{
    public static int playerScore;
    public static int playerLives = 3;
    
    public static Object[] neighborOptions;

    void Awake() 
    {
        // Populate neighborOptions
        neighborOptions = Resources.LoadAll("Neighbors", typeof(GameObject));

        foreach (var n in neighborOptions)
        {
            Debug.Log("<color=red>" + n.name);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
