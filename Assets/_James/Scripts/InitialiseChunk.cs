using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseChunk : MonoBehaviour
{

    public GameObject chunkObject;
    public int decorationChance;
    public List<GameObject> decorativePropList;
    public List<GameObject> characterList;

    // Start is called before the first frame update
    void Start()
    {
        //Spawning chunks
        for (float i = -10; i <= 60; i = i + 10)
        {
            GameObject Chunk = Instantiate(chunkObject);
            Chunk.transform.position = new Vector3(0, 0, i);

            GameObject decorativeProps = Chunk.transform.GetChild(1).gameObject;

            //Spawning Decorations
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

            //Spawning Character
            GameObject characterSpot = Chunk.transform.GetChild(2).gameObject;

            int charSelection = Random.Range(0, characterList.Count);
            GameObject charObject = Instantiate(characterList[charSelection]);
            charObject.transform.position = characterSpot.transform.position;
            charObject.transform.parent = Chunk.transform;
        }        
    }
}
