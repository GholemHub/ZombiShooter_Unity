﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerHitSound, SpiderHitSound, ZombiHitSound, CollectItemsSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip> ("shot");
        SpiderHitSound = Resources.Load<AudioClip> ("SpiderDamage");
        ZombiHitSound = Resources.Load<AudioClip> ("ZombiDamage");
        CollectItemsSound = Resources.Load<AudioClip> ("CollectItems");
        //BackGroundSong = Resources.Load<AudioClip> ("BackGroundSong");
   
        audioSrc = GetComponent<AudioSource> ();

        //SoundManagerScript.PlayerSound("BackSong");
        PlayerSound("BackSong");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayerSound(string clip){
        switch(clip){
            case "fire":
            audioSrc.PlayOneShot(playerHitSound);
            break;
            case "SpiderHit":
            audioSrc.PlayOneShot(SpiderHitSound);
            break;
            case "ZombiHit":
            audioSrc.PlayOneShot(ZombiHitSound);
            break;
             case "CollectItems":
            audioSrc.PlayOneShot(CollectItemsSound);
            break;
            
        }
    }
}