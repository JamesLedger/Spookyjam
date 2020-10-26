using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceChunk : MonoBehaviour
{
    [SerializeField]
    public GameObject chunkSpawnPoint;

    [SerializeField]
    public List<GameObject> decorativePropList;
    public List<GameObject> houseList;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ResetChunk")
        {
            gameObject.transform.position = new Vector3(0,0,70f);
            ResetChunk();
            PopulateChunk();
        }
    }

    public int decorationChance;

    private void ResetChunk()
    {
        //Removing house
        GameObject houseSpot = gameObject.transform.GetChild(2).gameObject;
        Destroy(houseSpot.transform.GetChild(0).gameObject);

        //Removing Decorations
        GameObject decorativeProps = gameObject.transform.GetChild(1).gameObject;

        foreach (Transform propPosition in decorativeProps.transform)
        {
            foreach (Transform item in propPosition)
            {
                Destroy(item.gameObject);
            }
        }
    }

    private void PopulateChunk()
    {
        GameObject decorativeProps = gameObject.transform.GetChild(1).gameObject;

        //Spawning Decorations
        foreach (Transform decorativePropTransform in decorativeProps.transform)
        {
            decorationChance = Random.Range(0, 10);

            if (decorationChance > 2)
            {
                int selection = Random.Range(0, decorativePropList.Count);

                GameObject decorativeProp = Instantiate(decorativePropList[selection]);
                decorativeProp.transform.position = decorativePropTransform.position;
                decorativeProp.transform.parent = decorativePropTransform.transform;
            }
        }

        //Spawning House
        GameObject houseSpot = gameObject.transform.GetChild(2).gameObject;

        int houseSelection = Random.Range(0, houseList.Count);
        GameObject houseObject = Instantiate(houseList[houseSelection]);
        // position + offset
        houseObject.transform.position = houseSpot.transform.position + new Vector3(-0.25f, 0.5f, 0f);
        houseObject.transform.parent = houseSpot.transform;
    }
}
