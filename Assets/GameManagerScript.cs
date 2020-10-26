using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public Object[] neighborList;

    // Static
    public static int playerScore;
    public static int playerLives;

    // Debugging
    public int playerScoreDisplay, playerLivesDisplay;
    
    public List<Material> monsterSkins, humanSkins;

    public GameObject leftHandAnchor, rightHandAnchor;

    void Awake() 
    {
        neighborList = Resources.LoadAll("Neighbors", typeof(GameObject));

        // Debugging
        /*
        foreach (var m in neighborList)
        {
            Debug.Log("<color=red>" + m.name + "</color>");
        }
        /*
        foreach (var m in monsterSkins)
        {
            Debug.Log("<color=green>" + m.name + "</color>");
        }

        foreach (var m in humanSkins)
        {
            Debug.Log("<color=blue>" + m.name  + "</color>");
        }
        */

        playerScore = 0;
        playerLives = 3;
    }
    private void LateUpdate() 
    {
        // Pure debugging.
        playerLivesDisplay = playerLives;
        playerScoreDisplay = playerScore;

        if (playerLives < 1)
        {
            StartCoroutine(LoseGame());
        }
    }

    public IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("lose", LoadSceneMode.Single);
    }
}
