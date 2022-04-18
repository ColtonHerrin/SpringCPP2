using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    public bool isRandomized;


    public void SpawnObject()
    {
        int index = isRandomized ? Random.Range(0, objectsToSpawn.Count) : 0;
        if (objectsToSpawn.Count > 0)
        {
            Instantiate(objectsToSpawn[index]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
