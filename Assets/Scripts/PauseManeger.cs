using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManeger : MonoBehaviour
{
    GameObject SceneMusic;
    public GameObject SoundManeger;
    public  bool isMusic;
    public Sprite musicIcon;
    public Sprite mutedMusicIcon;
    public Sprite soundIcon;
    public Sprite mutedSoundIcon;
   

    void Awake()
    {
        SceneMusic = GameObject.FindGameObjectWithTag("Music");
        isMusic = SceneMusic.GetComponent<AudioSource>().isPlaying;
        GameObject soundImage = GameObject.FindGameObjectWithTag("SoundIcon");
        GameObject musicImage = GameObject.FindGameObjectWithTag("MusicIcon");
       
        if (ObstacleSpawner.isDontPlaySounds)
        {
           Debug.Log("works on awake");
            soundImage.GetComponent<Image>().sprite = mutedSoundIcon;
        }
        if(isMusic == false)
        {
      
            musicImage.GetComponent<Image>().sprite = mutedMusicIcon;
        }
     
    }
  
    public void MusicButton()
    {
        isMusic = SceneMusic.GetComponent<AudioSource>().isPlaying;
        GameObject musicImage = GameObject.FindGameObjectWithTag("MusicIcon");
        if (isMusic)
        {
            SceneMusic.GetComponent<PlsDontStopTheMusic>().StopMusic();
            musicImage.GetComponent<Image>().sprite = mutedMusicIcon;
        }
        else if (isMusic == false)
        {
            SceneMusic.GetComponent<PlsDontStopTheMusic>().PlayMusic();
            musicImage.GetComponent<Image>().sprite = musicIcon;
        }
        
        
    }

    public void SoundButton()
    {
        AudioSource audioSource = SoundManeger.GetComponent<AudioSource>();
        GameObject soundImage = GameObject.FindGameObjectWithTag("SoundIcon");

        if (ObstacleSpawner.isDontPlaySounds == false)
        {
            ObstacleSpawner.isDontPlaySounds = true;
            soundImage.GetComponent<Image>().sprite = mutedSoundIcon;
        }
        else if (ObstacleSpawner.isDontPlaySounds == true)
        {
            ObstacleSpawner.isDontPlaySounds = false;
            soundImage.GetComponent<Image>().sprite = soundIcon;
        }
    }
}
