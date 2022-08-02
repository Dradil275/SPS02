using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public GameObject Background;
    public GameObject Instructions;
    GameObject localInstrtuctions;
    public GameObject Santa;
    public bool isMoving;
    public static bool isInstructionsRead;

    private void Start()
    {
       
        Invoke("StartGame", 2f);
        InvokeRepeating("CSspeedup", 30, 60);
        if(isInstructionsRead == false)
        {
           localInstrtuctions  = Instantiate(Instructions, new Vector3(0, 0, 0), Instructions.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isMoving == true)
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }
        

    }


    public void CSspeedup()
    {
        Background.GetComponent<LoopingBackround>().backgroundSpeed = Background.GetComponent<LoopingBackround>().backgroundSpeed + 0.2f;
        cameraSpeed += 3; 
    }


    public void StartGame()
    {
        if(localInstrtuctions != null)
        {
            localInstrtuctions.SetActive(false);
        }
   
        isMoving = true;
        Background.GetComponent<LoopingBackround>().isLooping = true;
        Santa.GetComponent<SantaEngine>().speed = Santa.GetComponent<SantaEngine>().speed + 20;
        isInstructionsRead = true;
    }
}
