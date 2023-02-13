using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonMusic : MonoBehaviour
{
    public static AudioClip BackGroundSong1;
    static AudioSource audioSrc;void Start()
    {
       
        BackGroundSong1 = Resources.Load<AudioClip> ("BackGroundSong");
   
        audioSrc = GetComponent<AudioSource> ();

        
        FonMusic.PlayerSound("BackSong");
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
