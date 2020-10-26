using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    private TMP_Text scoreText;
    private GameManagerScript gameMngr;

    // Start is called before the first frame update
    void Awake()
    {
        gameMngr = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + gameMngr.playerScoreDisplay;
    }
}
