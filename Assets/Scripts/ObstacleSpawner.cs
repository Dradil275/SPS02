using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    float chance;
    bool canSpawn;
    public bool isGameOver;
    //obstacles
    public GameObject bird;
    public GameObject plane;
    public GameObject superman;
    public GameObject superWarning;
    GameObject warning;
    float supermanY;

    //sounds
    public AudioSource audioSource;
    public AudioClip[] birdSounds = new AudioClip[2];
    public AudioClip planeSound;
    public AudioClip superSound;
    public static bool isDontPlaySounds;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        InvokeRepeating("ReturnChance", 5, 4);
    }

    // Update is called once per frame
    void Update()
    {

        if(isGameOver == false)
        {
            if (canSpawn == true)
            {

                Invoke(WhatEnemy(), chance);
                canSpawn = false;
            }
        }
    
    
    }



    public void ReturnChance()
    {
        float spawn = Random.Range(1,10);
        chance = spawn;
        canSpawn = true;
        
    }


    public string WhatEnemy()
    {
        bool notBird = false;
        bool notPlane = false;
        float select = Random.Range(1, 100);
        
        if(select > 50)
        {
            notBird = true;
        }
        if(select > 90)
        {
            notBird = true;
            notPlane = true;
        }
        if (select <= 50 && notBird == false)
        {
            return "SpawnBird";
        }
        else if (select <= 90 && notBird == true)
        {
            return "SpawnPlane";
        }
        else if (select > 90 && notBird == true & notPlane == true)
        {
            return "SpawnSuperWarning";
        }
        else return "null";
    }


    //spawn Obstacles
    public void SpawnBird()
    {
        int RandomBirdSound = Random.Range(0,2);
        if(isDontPlaySounds == false && isGameOver == false)
        {
            audioSource.PlayOneShot(birdSounds[RandomBirdSound]);
        }
        
        Instantiate(bird, new Vector3(spawnPoint.position.x, spawnPoint.position.y + (Random.Range(-4, 4)), spawnPoint.position.z), bird.transform.rotation);
      
    }

    public void SpawnPlane()
    {
        if(isDontPlaySounds == false && isGameOver == false)
        {
            audioSource.PlayOneShot(planeSound);
        }
        
        Instantiate(plane, new Vector3(spawnPoint.position.x, spawnPoint.position.y + (Random.Range(-2, 2)), spawnPoint.position.z), plane.transform.rotation);
      
    }
    
    public void SpawnSuperMan()
    {
        if (isDontPlaySounds == false && isGameOver == false)
        {
            audioSource.PlayOneShot(superSound);
        }
        Instantiate(superman, new Vector3(spawnPoint.position.x, spawnPoint.position.y + supermanY, spawnPoint.position.z), superman.transform.rotation);
        
    }
    public void SpawnSuperWarning()
    {
        supermanY = Random.Range(-2, 2);
        warning = Instantiate(superWarning, new Vector3(spawnPoint.position.x - 11, supermanY, spawnPoint.position.z), superWarning.transform.rotation);
        Invoke("SpawnSuperMan", 1);
        Invoke("DestroyWarning", 1);
    }
    public void DestroyWarning()
    {
        Destroy(warning);
    }

}
