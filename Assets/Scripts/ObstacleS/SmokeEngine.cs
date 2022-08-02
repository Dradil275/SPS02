using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == 0)
        {
            Destroy(gameObject);
        }
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Preciver")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
