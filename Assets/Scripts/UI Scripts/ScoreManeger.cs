using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManeger : MonoBehaviour
{
    public GameObject santa;

    bool stopChimnys;
    public Text scoreText;
    public TextMeshProUGUI GoScore;
    public float score;
    public float plusPoints;
    int i;
    float ChimnysPassed;
    public float[] checkPoints = new float[35];
    public float[] pointsToGain = new float[36];

    void Start()
    {
     
        i = 0;
    }
    // Update is called once per frame
    void Update()
    {
  
            ChimnysPassed = santa.GetComponent<SantaEngine>().chimnysPassed;
       
        
        if (ChimnysPassed >= checkPoints[i])
        {
            plusPoints = pointsToGain[i];
            i++;
            
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            
            scoreText.text = ((int)score).ToString();

        }
    
  



    }
}
