﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManagerScript : MonoBehaviour
{

    public Object[] neighborList;

    // Static
    public static int playerScore;
    public static int playerLives = 3;
    
    private Object[] monsterSkins, humanSkins;

    void Awake() 
    {
        neighborList = Resources.LoadAll("Neighbors", typeof(GameObject));
        monsterSkins = Resources.LoadAll("MonsterSkins", typeof(Material));
        humanSkins = Resources.LoadAll("HumanSkins", typeof(Material));

        // Debugging
        /*
        foreach (var m in neighborList)
        {
            Debug.Log("<color=red>" + m.name + "</color>");
        }
        
        foreach (var m in monsterSkins)
        {
            Debug.Log("<color=green>" + m.name + "</color>");
        }

        foreach (var m in humanSkins)
        {
            Debug.Log("<color=blue>" + m.name  + "</color>");
        }
        */
    }
}
