using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_spawner : MonoBehaviour
{
    [Tooltip("The Bat GameObject.")]
    public GameObject bat;
    [Tooltip("The different points at which a bat can spawn at.")]
    public Transform[] points;
    private float timer;
    [Tooltip("The minimum time between bats spawning.")]
    public float min_interval;
    [Tooltip("The maximum time between bats spawning.")]
    public float max_interval;
    private float interval_f;
    private float interval;

    // Use this for initialization
    void Start()
    {
        //Picking a random time for the first bat to spawn in at
        interval_f = Random.Range(min_interval, max_interval);
        interval = Mathf.Round(interval_f);
    }

    // Update is called once per frame
    void Update()
    {
        //checking to see if it is time for the bat to spawn
        if (timer >= interval)
        {
            //spawning the bat
            GameObject cube = Instantiate(bat, points[Random.Range(0, points.Length)]);
            //Picking a random time for the next bat to spawn at
            interval_f = Random.Range(min_interval, max_interval);
            interval = Mathf.Round(interval_f);
            //resting the timer
            timer = 0;
        }

        //Adding to the timer at the end of the frame
        timer += Time.deltaTime;
    }
}
