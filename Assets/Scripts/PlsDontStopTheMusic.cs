using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlsDontStopTheMusic : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip Bells;
    public AudioClip magicPing;
    public AudioClip retroCoin;
    private GameObject[] other;
    private bool NotFirst = false;
    public static bool isStopped;
    //icons

    private void Awake()
    {

        
        other = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                NotFirst = true;
            }
        }

        if (NotFirst == true)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
       
        if (isStopped == true)
        {
            StopMusic();
        }
    }
    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
        isStopped = false;
        
    }

    public void StopMusic()
    {
        isStopped = true;
        _audioSource.Pause();
    }

    public void PlayBells()
    {
        if(ObstacleSpawner.isDontPlaySounds == false)
        {
            _audioSource.PlayOneShot(Bells);
        }
        
    }



}
