using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rv_maneger : MonoBehaviour
{
    public GameObject ADS;
    public Text GOscore;
    public Text score;
    public static bool isScoreset;
    public Text scoreText;
    public static bool isGOTripplePoints;
    public GameObject ScoreOutofPresetns;
    public GameObject GameOverPanelScore;

    private void Start()
    {
        isScoreset = false;
    }
    public void LoadIntOrRv()
    {
        if (SceneLoader.interstialCounter >= 4)
        {
            ADS.GetComponent<Interstitial>().LoadInterstitial();
            SceneLoader.interstialCounter = 0;
         
        }
        else
        { 
            ADS.GetComponent<Rewarded>().LoadRewardedAd();
         
        }

    }

}

