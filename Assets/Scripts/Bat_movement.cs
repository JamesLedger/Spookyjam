using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_movement : MonoBehaviour
{
    //setting speed
    [Tooltip("Speed at which you want the bat to move at")]
    public float speed;
    [Tooltip("How long after the bat is spawned do you want it to be destoryed.")]
    public float destroy_timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        //moving the bat forwards forever
        transform.position += new Vector3(0,0,-1) * speed * Time.deltaTime;
    }

    IEnumerator destroy()
    {
        //waits until the destroy timer time has been fulfilled
        yield return new WaitForSeconds(destroy_timer);
        //destroys itself
        Destroy(this.gameObject);
    }
}
