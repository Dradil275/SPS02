using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneySpawner : MonoBehaviour
{
    //chimys
    GameObject[] chimnys = new GameObject[5];
    public GameObject chimny2;
    public GameObject chimny3;
    public GameObject chimny4;
    public GameObject chimny5;
    public GameObject chimny6;


    //spawner

    public float minX;
    public float maxX;

    float spawnTime;
    float randomfire;


    // Start is called before the first frame update
    void Start()
    {
       
        float spawnDelay = 2f;
        spawnTime = 2f;
        chimnys[0] = chimny2;
        chimnys[1] = chimny3;
        chimnys[2] = chimny4;
        chimnys[3] = chimny5;
        chimnys[4] = chimny6;
        
        InvokeRepeating("SpawnChimny", spawnDelay, spawnTime);

    }

    
    

    public void SpawnChimny()
    {
        
        float randomX = Random.Range(minX, maxX);
        float XcloserToPlayer = 14;
        int randomChimny = Random.Range(0, 5);
        float thisChimnyY = chimnys[randomChimny].transform.position.y;
        Instantiate(chimnys[randomChimny], transform.position + new Vector3(randomX - XcloserToPlayer, thisChimnyY , 10), transform.rotation);
        
    }

  
}
