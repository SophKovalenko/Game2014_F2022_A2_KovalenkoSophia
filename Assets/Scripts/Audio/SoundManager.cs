///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 11th, 2022
//  Last modified: Dec 11th, 2022
//  - this script manages the sound effects in the game scene
//////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SoundManager : MonoBehaviour
{
    public List<AudioSource> channels;
    private List<AudioClip> audioClips;

    // Start is called before the first frame update
    void Awake()
    {
        channels = GetComponents<AudioSource>().ToList();
        audioClips = new List<AudioClip>();
        InitializeSoundFX();
    }

    // Update is called once per frame
    private void InitializeSoundFX()
    {
        //Preload SFX
        audioClips.Add(Resources.Load<AudioClip>("Audio/Jump_Sound"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Player_Hurt"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Player_Death"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Player_Bullet"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Restore_Health"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Enemy_Bullet"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Enemy_Hit"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Pickup_Key"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Pickup_Fruit"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/Unlock_Door"));
    }

    public void PlaySoundFX(Sounds sound, Channel channel)
    {
        channels[(int)channel].clip = audioClips[(int)sound];
        channels[(int)channel].volume = 0.3f;
        channels[(int)channel].Play();
    }

}
