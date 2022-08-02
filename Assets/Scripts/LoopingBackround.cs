using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackround : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    public bool isLooping;



    private void Start()
    {
        isLooping = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(isLooping == true)
        {
            backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0);
        }
      
    }
}
