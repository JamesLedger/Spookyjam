using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristMenu : MonoBehaviour
{
    public GameObject wristMenu;
    public GameObject handPosition;

    public float xOffset;
    public float yOffset;
    public float zOffset;

    bool menuActive;
    bool positionSet;

    private void Start()
    {
        menuActive = false;
        positionSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMenuActive();

        //if (menuActive && positionSet == false)
        //{
        //    wristMenu.transform.position = new Vector3(xOffset, yOffset, zOffset) + handPosition.transform.position;
        //    wristMenu.transform.rotation = handPosition.transform.rotation;
        //    positionSet = true;
        //}
    }

    public void CheckMenuActive()
    {
        
        GestureDetector detector = GetComponent<GestureDetector>();
        CurrentHandInfo info = detector.Recognise();

        if (info.leftHandGesture == "Open Menu")
        {
            wristMenu.SetActive(true);
            menuActive = true;
        }

        if (info.leftHandGesture == "Close Menu")
        {
            wristMenu.SetActive(false);
            menuActive = false;
            positionSet = false;
        }
    }
}
