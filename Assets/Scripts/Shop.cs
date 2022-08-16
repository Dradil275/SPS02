using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    // text objects
    public TextMeshProUGUI pointsNum;
    public Text bagPrice;
    public Text NetzPrice;
    public TextMeshProUGUI BagSizeNum;
    public TextMeshProUGUI NetzAmmountNum;
    //price points
    //playerprefs key "bagSize"
    public static int bagSize;
    static int netzLevel;
    
  
    // price arrays
    static float[] bagPrices = new float[249];
    static float[] NetzPrices = new float[249];
    //shop
    static float allPoints;
    public GameObject sleighPanel;
    public GameObject InstructionsPanel;

    //sounds
    public AudioSource audioSource;
    public AudioClip Bells;
    public AudioClip magicPing;
    public AudioClip retroCoin;
    
    // Start is called before the first frame update
    void Start()
    {
        //TenjinConnect();

        SceneLoader.LoadGameSave();
        

        bagPrices[0] = 200; 
        for (int i = 1; i < bagPrices.Length; i++ )
        {
            bagPrices[i] = bagPrices[i - 1] + 86;
            
        }
        NetzPrices[0] = 220;
        for (int j = 1; j < NetzPrices.Length; j++)
        {
            NetzPrices[j] = NetzPrices[j - 1] + 62;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pointsNum != null)
        {
            pointsNum.text = allPoints.ToString();
        }
        if(bagPrice != null )
        {
           // bagPrice.text = bagPrices[PlayerPrefs.GetInt("bagSize")].ToString();
            bagPrice.text = bagPrices[bagSize].ToString();
        }
        if (NetzPrice != null)
        {
            //NetzPrice.text = NetzPrices[PlayerPrefs.GetInt("netzLevel")].ToString();
            NetzPrice.text = NetzPrices[netzLevel].ToString();

        }
        BagSizeNum.text = (3 + bagSize).ToString();
        NetzAmmountNum.text = netzLevel.ToString();

        /* PlayerPrefs.SetInt("bagSize", bagSize);
         PlayerPrefs.SetInt("netzLevel", netzLevel);
        */
        // chaets for developer
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cheats();   
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Tenjin.getInstance("CRQI2QZDASGH1YASSFAFXAIXTXDHCV5X").SendEvent("Test27");
            
        }
    }
    //Functions
    public static void StorePoints()
    {
       
        allPoints = allPoints + PlayerPrefs.GetFloat("points");
        
    }

    public void IncreaseBagSize()
    {
        if(allPoints >= bagPrices[bagSize])
        {
            if (ObstacleSpawner.isDontPlaySounds == false)
            {
                audioSource.PlayOneShot(retroCoin);

            }
            allPoints = allPoints - bagPrices[bagSize];
            bagSize++;
            SceneLoader.SaveGame();
        }
    }

    public void IncreaseNetz()
    {
        if(allPoints >= NetzPrices[PlayerPrefs.GetInt("netzLevel")])
        {
            if(ObstacleSpawner.isDontPlaySounds == false)
            {
                audioSource.PlayOneShot(magicPing);
            }
            allPoints = allPoints - NetzPrices[netzLevel];
            netzLevel++;
            SceneLoader.SaveGame();
        }
    }

    public void OpenSleighSelect()
    {
        if(ObstacleSpawner.isDontPlaySounds == false)
        {
            audioSource.PlayOneShot(Bells);
        }    
        sleighPanel.SetActive(true);
    }

    public void CloseSleighSelect()
    {
        sleighPanel.SetActive(false);
    }


    public void TenjinConnect()
    {
        BaseTenjin instance = Tenjin.getInstance("CRQI2QZDASGH1YASSFAFXAIXTXDHCV5X");
       
        // Sends install/open event to Tenjin
        instance.Connect();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            TenjinConnect();
        }
    }

        // get functions
        public static int GetBagSize()
    {
        return bagSize;
    }
    public static int GetNetzLevel()
    {
        return netzLevel;
    }
    public static float GetAllPoints()
    {
        return allPoints;
    }
    // set functions

    public static void SetBagSize(int LoadedBagSize)
    {
        bagSize = LoadedBagSize;
    }
    public static void SetNetzLEvel(int LoadedNetzLevel)
    {
        netzLevel = LoadedNetzLevel;
    }
    public static void SetAllPoints(float LoadedAllPoints)
    {
        allPoints =  LoadedAllPoints;
    }

    public void Cheats()
    {
        SetAllPoints(10000);
    }
    public void OpenInstructions()
    {
        InstructionsPanel.SetActive(true);
    }
    public void CloseInstructions()
    {
        InstructionsPanel.SetActive(false);
    }
}

