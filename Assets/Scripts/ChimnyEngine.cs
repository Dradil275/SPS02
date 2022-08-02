using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimnyEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("DestroySelf", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == 0)
        {
            DestroySelf();
        }
    }


    public void DestroySelf()
    {
        Destroy(gameObject);
    }


}
