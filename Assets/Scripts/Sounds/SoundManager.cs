﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
 private static SoundManager instance;
 public static SoundManager Instance{get {return instance;}}
 public SoundType[] sounds;
 public AudioSource soundEffect;
 public AudioSource soundMusic;
 public bool IsMute = false;
 public float Volume =1f;

     private void Awake(){
     if(instance == null)
     {
     instance=this;
     DontDestroyOnLoad(gameObject);    
     }    
     else
     {
     Destroy(gameObject);    
     }
     }

    private void Start()
    {
     PlayMusic(Sounds.Music);    
    }
    public void Mute(bool status)
    {
        IsMute = status;    
    }

    public void SetVolume(float volume)
    {
    Volume=volume;
    soundEffect.volume = Volume;
    soundMusic.volume = Volume;    
    }
    public void PlayMusic(Sounds sound)
    {
     if(IsMute)
     return;   
     AudioClip clip = getSoundClip(sound);  
     if(clip != null)
     {
       soundMusic.clip = clip;
       soundMusic.Play();   
     } 
     else{Debug.LogError("Audio clip not found"); }   
          
    }
     
    public void Play(Sounds sound)
    {
     if(IsMute)
     return;   
     AudioClip clip = getSoundClip(sound);  
     if(clip != null)
     {
       soundEffect.PlayOneShot(clip);   
     } 
     else{Debug.LogError("Audio clip not found"); }
    } 

    private AudioClip getSoundClip(Sounds sound)
    { 
      SoundType item = Array.Find(sounds, i=> i.soundType == sound);
      if(item != null)
      return item.soundClip;
      return null;  

    } 

    [Serializable]
    public class SoundType
    {
      public Sounds soundType;
      public AudioClip soundClip;
    }

    public enum Sounds
    {
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    }



}
