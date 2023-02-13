﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSongScript : MonoBehaviour
{

    public static AudioClip BackGroundSong1;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
       
        BackGroundSong1 = Resources.Load<AudioClip> ("BackGroundSong");
   
        audioSrc = GetComponent<AudioSource> ();

        
        BackGroundSongScript.PlayerSound("BackSong");
        PlayerSound("BackSong");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayerSound(string clip){
        switch(clip){
            case "BackSong":
            audioSrc.PlayOneShot(BackGroundSong1);
            break;
        }
    }
}