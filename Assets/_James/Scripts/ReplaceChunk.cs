using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceChunk : MonoBehaviour
{
    [SerializeField]
    public GameObject chunkSpawnPoint;

    [SerializeField]
    public List<GameObject> decorativePropList;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ResetChunk")
        {
            gameObject.transform.position = new Vector3(0,0,70f);
         //   ResetChunk();
         //   PopulateChunk();
        }
    }

    public int decorationChance;

    private void ResetChunk()
    {
        GameObject decorativeProps = gameObject.transform.GetChild(1).gameObject;

        foreach (Transform decorativePropTransform in decorativeProps.transform)
        {
            decorationChance = Random.Range(0, 10);

            if (decorationChance > 4)
            {
                int selection = Random.Range(0, decorativePropList.Count);

                GameObject decorativeProp = Instantiate(decorativePropList[selection]);
                decorativeProp.transform.position = decorativePropTransform.position;
            }
        }
       
    }

    private void PopulateChunk()
    {

    }
}
