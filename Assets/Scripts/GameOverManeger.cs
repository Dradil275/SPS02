using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOverManeger : MonoBehaviour
{
    public GameObject score;

    public TextMeshProUGUI GOscore;
    // Start is called before the first frame update
    private void Awake()
    {
        GOscore.text = score.GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneLoader.TriplePoints == true)
        {

            float Fscore = float.Parse(score.GetComponent<Text>().text);
            Fscore = Fscore * 3;
            GOscore.text = Fscore.ToString();
        }
        else GOscore.text = score.GetComponent<Text>().text;
    }
}
