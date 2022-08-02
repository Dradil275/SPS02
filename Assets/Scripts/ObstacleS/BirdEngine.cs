using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-10f * Time.deltaTime, 0, 0);;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
