using UnityEngine;
using System.Collections;

public class TenjinStarter : MonoBehaviour
{

    void Start()
    {
        TenjinConnect();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            TenjinConnect();
        }
    }

    public void TenjinConnect()
    {
        BaseTenjin instance = Tenjin.getInstance("CRQI2QZDASGH1YASSFAFXAIXTXDHCV5X");

        // Sends install/open event to Tenjin
        instance.Connect();
    }
}