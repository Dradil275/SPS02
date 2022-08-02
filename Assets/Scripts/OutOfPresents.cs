using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfPresents : MonoBehaviour
{
    public GameObject score;
    
    public Text presentsDealt;
    // Start is called before the first frame update
    private void Awake()
    {
        SceneLoader.interstialCounter++;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneLoader.TriplePoints == true)
        {
            
            float Fscore = float.Parse(score.GetComponent<Text>().text);
            Fscore = Fscore * 3;
           presentsDealt.text = Fscore.ToString();
        }
        else presentsDealt.text = score.GetComponent<Text>().text;
        
    }
}
