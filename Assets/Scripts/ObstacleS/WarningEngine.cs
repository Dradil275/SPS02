using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningEngine : MonoBehaviour
{

    public GameObject mainCamera;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.transform.parent = mainCamera.transform;
    }

  
}
