using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONreader : MonoBehaviour
{
    public TextAsset textJSON;
    [System.Serializable]
        public class customEvents
    {
        public int BagSize;
    }
    [System.Serializable]
    public class CEList
    {
        public customEvents[] CustomEvents;
    }

    public CEList myCEList = new CEList();

    private void Start()
    {
        myCEList = JsonUtility.FromJson<CEList>(textJSON.text);
    }
}
