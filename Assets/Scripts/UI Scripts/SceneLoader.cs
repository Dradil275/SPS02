using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    
    public GameObject gameOverPanel;
    public GameObject presentsDealtPanel;
    public GameObject theScore;
    // sounds
    public  AudioClip uiSound1;
    public  AudioClip uiSound2;
    AudioSource audioSource;
    //shop stuff
    
    public  float pointsGot;
    public static bool TriplePoints;
    // Pause Game
    public GameObject pausePanel;
    public GameObject pauseButton;

    //ad stuff
    public static int interstialCounter;

    // Update is called once per frame
    void Update()
    {
        //audioSource = GameObject.FindGameObjectWithTag("Audio Source").GetComponent<AudioSource>();
      //  theScore.GetComponent<Text>().text = GameObject.Find("Score Text").GetComponent<Text>().text;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("RESET");
            PlayerPrefs.SetInt("bagSize", 0);
            PlayerPrefs.SetInt("netzLevel", 0);
            SleighSelection.prices[1] = 0;
            SleighSelection.prices[1] = 800;
            SleighSelection.prices[2] = 2000;
            SleighSelection.prices[3] = 4500;
            SleighSelection.prices[4] = 9420;
            SleighSelection.slighSelector = 0;
            SceneLoader.ResetGame();
        }
    }


    public void PlayAgain()
    {
        //Save Points
        SendPointstoBank();
        ResetPoints();

        // Cancel panels
        gameOverPanel.SetActive(false);
        presentsDealtPanel.SetActive(false);
     

        // deleting all chimnys
        GameObject[] chimnys = GameObject.FindGameObjectsWithTag("Chimny");
        foreach (GameObject c in chimnys)
        {
            
            Destroy(c);
        }
        // invoking chimnys spawner
        Invoke("AllowSpawn", 3);
        //save game
        SaveGame();

       
        
        
        //load scene
        SceneManager.LoadScene("MainGame");
    }


    public void LoadGame()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        music.GetComponent<PlsDontStopTheMusic>().PlayBells();
        ResetPoints();
        SceneManager.LoadScene("MainGame");

        
        
    }
    public void ExitGame()
    {
        SaveGame();
        Application.Quit();
    }
    
    private void OnApplicationQuit()
    {
        SaveGame();
        CameraMovement.isInstructionsRead = false;
    }
    
    public void LoadShop()
    {
        
        SendPointstoBank();
        SaveGame();
        SceneManager.LoadScene("Shop");
    }

    public void LoadShopFromPause()
    {
        SaveGame();
        Time.timeScale = 1; 
        SceneManager.LoadScene("Shop");
        
    }

    public void SendPointstoBank()
    {
        pointsGot = theScore.GetComponent<ScoreManeger>().score;
        if(TriplePoints == true)
        {
            pointsGot = pointsGot * 3;
            TriplePoints = false;
        }
        PlayerPrefs.SetFloat("points", pointsGot);
        Shop.StorePoints();
        SaveGame();
        
    }
    public void ResetPoints()
    {
        PlayerPrefs.SetFloat("points", 0);
    }

    //saves
   public static void SaveGame()
    {
        
        SaveData saveData = new SaveData();
        saveData.BagSizeLevl = Shop.GetBagSize();
        saveData.NetzLevel = Shop.GetNetzLevel();
        saveData.points = Shop.GetAllPoints();
        saveData.sleighSelector = SleighSelection.slighSelector;
        saveData.SP1 = SleighSelection.prices[1];
        saveData.SP2 = SleighSelection.prices[2];
        saveData.SP3 = SleighSelection.prices[3];
        saveData.SP4 = SleighSelection.prices[4];
       

        SaveManeger.SaveGameState(saveData);
    }

    public static void LoadGameSave()
    {
        SaveData saveData = SaveManeger.LoadGameState();
        if(saveData != null)
        {
            Shop.SetBagSize(saveData.BagSizeLevl);
            Shop.SetNetzLEvel(saveData.NetzLevel);
            Shop.SetAllPoints(saveData.points);
            SleighSelection.SetPrices(saveData.SP1, saveData.SP2, saveData.SP3, saveData.SP4);
            SleighManeger.selectedSleigh = saveData.sleighSelector;
        }
    }
    //Pause Panel
    public void PauseGame()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
 

        

    }    

    public void ResumeGame()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    //dev tool
    public static void ResetGame()
    {
        Debug.Log("Reset");
        Shop.SetBagSize(0);
        Shop.SetNetzLEvel(0);
        Shop.SetAllPoints(0);
    }

}
