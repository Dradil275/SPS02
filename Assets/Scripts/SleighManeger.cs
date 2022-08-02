using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleighManeger : MonoBehaviour
{
    public Sprite[] Slighs = new Sprite[5];
    public Sprite ZombieSanta;
    public Sprite ZombieRaindeers;
    public GameObject SantaBody;
    public GameObject Raindeers;
    public GameObject IceParticles;
    public GameObject FireParticles;
    public GameObject ZombieParticles;
    public static int selectedSleigh;
    // Start is called before the first frame update
    void Start()
    {
        SceneLoader.LoadGameSave();
        gameObject.GetComponent<SpriteRenderer>().sprite = Slighs[SleighSelection.slighSelector];
        selectedSleigh = SleighSelection.slighSelector;
        if(selectedSleigh == 4)
        {
            SantaBody.GetComponent<SpriteRenderer>().sprite = ZombieSanta;
            SantaBody.transform.localPosition = new Vector3(1.355f, 0.293f, 1);
            SantaBody.transform.localScale = new Vector3(-1.234089f, 1.234089f, 1.234089f);
            ZombieParticles.SetActive(true);
        }
        if(selectedSleigh == 2 )
        {
            IceParticles.SetActive(true);
        }
        if(selectedSleigh == 3)
        {
            FireParticles.SetActive(true);
        }

       
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
