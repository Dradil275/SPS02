using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentEngine : MonoBehaviour
{
    public float wind;
    float pointsToAdd;
    public GameObject Score;
    bool canRecive;
    int netzCount;
    bool isNetzOnce;
    GameObject Santa;
    
    private void Awake()
    {
        Santa = GameObject.Find("Santa");
        canRecive = true;
        isNetzOnce = true;
        Score = GameObject.Find("Score Text");
        Invoke("DestroySelf", 10);
        wind = 0;
        pointsToAdd = Score.GetComponent<ScoreManeger>().plusPoints; 
    }

    // Update is called once per frame
    void Update()
    {
        wind += 0.06f;
        transform.Translate(-wind * Time.deltaTime, 0, 0);
        netzCount = Santa.GetComponent<SantaEngine>().netzCount;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (netzCount > 0)
        {
            if (collision.tag == "NetzRange")
            {
             
                if(isNetzOnce == true)
                {
                    Santa.GetComponent<SantaEngine>().netzCount--;
                    Santa.GetComponent<SantaEngine>().presentCount++;
                    Santa.GetComponent<SantaEngine>().isPresentPastNetzRange = true;
                    gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                    Santa.GetComponent<SantaEngine>().PlayParticles();
                    isNetzOnce = false;
                    Destroy(gameObject);
                  


                }
             
            }
        }
     
        if (collision.tag == "Preciver" && canRecive == true)
        {
            Score.GetComponent<ScoreManeger>().score = Score.GetComponent<ScoreManeger>().score + pointsToAdd;
            DestroySelf();
        }
      


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            DestroySelf();
        }
    }

    

}
