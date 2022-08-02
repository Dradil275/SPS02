using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonPressedAnm : MonoBehaviour
{
    public GameObject GoTripplePoints;
    public Sprite GoTripplePointsIMG;
    public Sprite GoTripplePointsPressed;

    public GameObject GoMainMenu;
    public Sprite GoMainMenuIMG;
    public Sprite GoMainMenuPressed;

    public GameObject GoPlayAgain;
    public Sprite GoPlayAgainIMG;
    public Sprite GoPlayAgainPressed;

    public GameObject AdTripplePoints;
    public GameObject AdMainMenu;
    public GameObject AdPlayAgain;

    // Start is called before the first frame update


    //game over tripple
    public void GoPressTriple()
    {
        GoTripplePoints.GetComponent<Image>().sprite = GoTripplePointsPressed;
        Invoke("BackToNormalTripple", 0.1f);
    }

    void BackToNormalTripple()
    {
        GoTripplePoints.GetComponent<Image>().sprite = GoTripplePointsIMG;
    }

    //game over main menu
    public void PressMainMenu()
    {
        GoMainMenu.GetComponent<Image>().sprite = GoMainMenuPressed;
        Invoke("BackToNormalMainMenu", 0.1f);
    }

    void BackToNormalMainMenu()
    {
        GoMainMenu.GetComponent<Image>().sprite = GoMainMenuIMG;
    }

    //game over Play again
    public void PressPlayAgain()
    {
        GoPlayAgain.GetComponent<Image>().sprite = GoPlayAgainPressed;
        Invoke("GoPlayAgainBackToNormal", 0.1f);
    }

    void PlayAgainBackToNormal()
    {
        GoPlayAgain.GetComponent<Image>().sprite = GoPlayAgainIMG;
    } 



    public void AdPressTriple()
    {
        AdTripplePoints.GetComponent<Image>().sprite = GoTripplePointsPressed;
        Invoke("AdBackToNormalTripple", 0.1f);
    }

    void AdBackToNormalTripple()
    {
        AdTripplePoints.GetComponent<Image>().sprite = GoTripplePointsIMG;
    }

    //game over main menu
    public void AdPressMainMenu()
    {
        AdMainMenu.GetComponent<Image>().sprite = GoMainMenuPressed;
        Invoke("AdBackToNormalMainMenu", 0.1f);
    }

    void AdBackToNormalMainMenu()
    {
        GoMainMenu.GetComponent<Image>().sprite = GoMainMenuIMG;
    }

    //game over Play again
    public void AdPressPlayAgain()
    {
        AdPlayAgain.GetComponent<Image>().sprite = GoPlayAgainPressed;
        Invoke("AdPlayAgainBackToNormal", 0.1f);
    }

    void AdPlayAgainBackToNormal()
    {
        AdPlayAgain.GetComponent<Image>().sprite = GoPlayAgainIMG;
    }

}
