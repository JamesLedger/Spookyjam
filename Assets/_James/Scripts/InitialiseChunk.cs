using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseChunk : MonoBehaviour
{

    public GameObject chunkObject;
    public int decorationChance;
    public List<GameObject> decorativePropList;

    // Start is called before the first frame update
    void Start()
    {
        for (float i = -10; i <= 60; i = i + 10)
        {
            GameObject Chunk = Instantiate(chunkObject);
            Chunk.transform.position = new Vector3(0, 0, i);

            GameObject decorativeProps = Chunk.transform.GetChild(1).gameObject;

            foreach (Transform decorativePropTransform in decorativeProps.transform)
            {
                decorationChance = Random.Range(0, 10);

                if (decorationChance > 2)
                {
                    int selection = Random.Range(0, decorativePropList.Count);

                    GameObject decorativeProp = Instantiate(decorativePropList[selection]);
                    decorativeProp.transform.position = decorativePropTransform.position;
                    decorativeProp.transform.parent = Chunk.transform;
                }
            }

        }        
    }
}
