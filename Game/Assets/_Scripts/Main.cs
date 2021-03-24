using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//update
//This is the main class - BIG BOI
//It will be used to dynamically spawn in enemies and other player objects 
//Will also handle other main scripts within the game
//The script is attached to the MainCamera
public class Main : MonoBehaviour
{
    public GameObject[] slimes;
    public float enemySpawnPerSecond = 0.5f;

    private int slimeNum = 2;

    void Awake()
    {
        Invoke("SpawnEnemy", 0.5f / enemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        //Spawns in a maximum of 3 slimes at any given time

        if (slimeNum < 3)
        {
            GameObject go = Instantiate<GameObject>(slimes[slimeNum]);
            slimeNum++;

            //Initial position of spawned enemy
            Vector3 pos = new Vector3(-18f, 10.5f, 0f);
            go.transform.position = pos;

            Invoke("SpawnEnemy", 0.5f / enemySpawnPerSecond);
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
