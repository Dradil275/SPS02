using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEvent : MonoBehaviour
{
    public GameObject TenjinManeger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TenjinEventSent()
    {


        BaseTenjin instance = Tenjin.getInstance("CRQI2QZDASGH1YASSFAFXAIXTXDHCV5X");
        instance.Connect();
        instance.SendEvent("Test_from_build", "27");
        
        Debug.Log("EVENT");
        //Tenjin.getInstance("FAFXAIXTXDHCV5XSSFAFXAIXTXDHCV5X").SendEvent("Test from build");
    }
}
