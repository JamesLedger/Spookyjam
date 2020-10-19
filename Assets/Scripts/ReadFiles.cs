using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadFiles : MonoBehaviour
{
    //public TextMeshPro fileList;

    // Start is called before the first frame update
    void Start()
    {
        string filePath = "C:\\Users\\James\\Desktop\\FileInput";
        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(filePath);
        foreach (string fileName in fileEntries)
        {
            int lastSlash = fileName.LastIndexOf("\\");
            int length = fileName.Length;
          //  fileList.text += fileName.Substring(lastSlash + 1, length - (lastSlash + 1)) + " \n";
            SpawnFile();
        }
    }

    public GameObject fileThing;
    public Transform spawnLocation;

    void SpawnFile()
    {
        GameObject temp = Instantiate(fileThing, spawnLocation);
    }
}
