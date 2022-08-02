using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SleighSelection : MonoBehaviour
{
    public Sprite[] Slighs = new Sprite[5];
    public string[] sleighComments = new string[5];
    public static float[] prices = new float[5];
    public static bool isPriceSet;
    public GameObject sligh;
    public static int slighSelector;
    int slighShown;
    float points;
    public Text Points;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI Select;
    public TextMeshProUGUI sleighComment;
    public GameObject includesParticles;


    // Start is called before the first frame update
    void Awake()
    {
        sligh.GetComponent<Image>().sprite = Slighs[slighSelector];
        slighShown = slighSelector;
        points = Shop.GetAllPoints();
        if(isPriceSet == false)
        {
            prices[0] = 0;
            prices[1] = 800;
            prices[2] = 2000;
            prices[3] = 4500;
            prices[4] = 9420;
            isPriceSet = true;
        }
   
    }

    // Update is called once per frame
    void Update()
    {

        
        //show points
        Points.text = Shop.GetAllPoints().ToString();
        points = Shop.GetAllPoints();
        //display sleigh, price or owned 
        sligh.GetComponent<Image>().sprite = Slighs[slighShown];

        Price.text = prices[slighShown].ToString();
        if(Price.text == "0")
        {
            Price.text = "Owned";
        }
        // select slighs
        Mathf.Clamp(slighSelector, 0, 4);
        if (slighShown == slighSelector)
        {
            Select.text = "Selected";
        }
        else Select.text = "Select";

        sleighComment.text = sleighComments[slighShown];
        if (slighShown > 1)
        {
            includesParticles.SetActive(true);
        }
        else includesParticles.SetActive(false);
    }




    public void ArrowRight()
    {
        slighShown++;
        if (slighShown > 4)
        {
            slighShown = 0;
        }
       
    }

    public void ArrowLeft()
    {
        slighShown--;
        if (slighShown < 0)
        {
            slighShown = 4;

        }
      
    }

    public void BuySleigh()
    {
        if(points >= prices[slighShown])
        {
            points = points - prices[slighShown];
            Shop.SetAllPoints(points);
            prices[slighShown] = 0;
            slighSelector = slighShown;
            SceneLoader.SaveGame();
        }
    }

    public void SelectSleigh()
    {
        if(Select.text == "Select" && prices[slighShown] == 0)
        {
            slighSelector = slighShown;
        }
    }

   public static void SetPrices(float SP1, float SP2, float SP3, float SP4)
    {
        prices[1] = SP1;
        prices[2] = SP2;
        prices[3] = SP3;
        prices[4] = SP4;
        
    }
}
