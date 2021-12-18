using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class SoundsScr : MonoBehaviour
{
    public Sound[] Sounds;
    public AudioMixerGroup mixerGroup;
    public AudioMixer Mixer;
    void Awake() 
    {
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.loop = false;
            s.source.clip = s.Clip; 
            s.source.outputAudioMixerGroup = mixerGroup; 
        }
        //slider.value = volumelock;
        //AudioPLayer.Play(Sounds[1]);
    }

    public void IntroSong()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Intro");
        if(s != null)
        {
            s.source.Play();
            s.source.loop = true;
        }
        
            
    }
    public void MainGameSong(string Play)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Main");
        if(s != null)
        {
            if(Play == "Play")
            {
                s.source.Play();
                s.source.loop = true;
            }
            else if (Play == "Stop")
            {
                s.source.Stop();
                Debug.Log("stop");
            }
        }
    }
    public void CarHorn()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "CarHorn");
        if(s != null)
        {
            s.source.volume = 250;
            s.source.PlayOneShot(s.source.clip);
        }
    }
    public void Cat()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Cat");
        if(s != null)
            s.source.PlayOneShot(s.source.clip);
    }
    public void Coin()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Coin");
        if(s != null)
            s.source.PlayOneShot(s.source.clip);
    }
    public void CoinsCollect(string Play)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "CoinsCollect");
        if(s != null)
        {
            if(Play == "Play")
            {
                s.source.Play();
                s.source.loop = true;
                Debug.Log("play");
            }
            else if (Play == "Stop")
            {
                s.source.Stop();
                Debug.Log("stop");
            }
        }  
    }
    public void Dog()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Dog");
        if(s != null)
            s.source.PlayOneShot(s.source.clip);
    }
    void Update() 
    {
        /*if(TimerSound != null)
        {
            if(gameMechanicsScr.PauseWindow.activeSelf)
                TimerSound.source.Pause();
            else
                TimerSound.source.UnPause();
        }*/
    }
   /* public void Mute()
    {   
        if(extradatahere.dataForSaving.Sound)
            {
                Mixer.SetFloat("Volume",0);
            }
        else
            {
                Mixer.SetFloat("Volume",-80);
            }
        
    }*/

}
