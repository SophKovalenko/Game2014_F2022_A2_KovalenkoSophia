///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 7th, 2022
//  Last modified: Dec 10th, 2022
//  - this script is responsible for controlling the interactions between the player and the pickup items
////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupObjectController : MonoBehaviour
{
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private PlayerBehaviour playerRef;
    public GameObject NoKeyPopup;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        soundManager = FindObjectOfType<SoundManager>();
        playerRef = FindObjectOfType<PlayerBehaviour>();
        timer = 0;
    }

    public void Update()
    {
        if (NoKeyPopup != null)
        {
            if (NoKeyPopup.activeInHierarchy == true)
            {
                timer += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string pickupName = gameObject.name;

        if (other.gameObject.name == "Player")
        {
            switch (pickupName)
            {
                case "Orange_Pickup(Clone)": 
                    scoreManager.AddPoints(20);
                    soundManager.PlaySoundFX(Sounds.PICKUP_FRUIT, Channel.PICKUP_FRUIT_FX);
                    Destroy(this.gameObject);
                    break;
                case "Melon_Pickup(Clone)":
                    scoreManager.AddPoints(30);
                    soundManager.PlaySoundFX(Sounds.PICKUP_FRUIT, Channel.PICKUP_FRUIT_FX);
                    Destroy(this.gameObject);
                    break;
                case "Cherries_Pickup(Clone)":
                    scoreManager.AddPoints(40);
                    soundManager.PlaySoundFX(Sounds.PICKUP_FRUIT, Channel.PICKUP_FRUIT_FX);
                    Destroy(this.gameObject);
                    break;
                case "Pineapple_Pickup(Clone)":
                    scoreManager.AddPoints(50);
                    soundManager.PlaySoundFX(Sounds.PICKUP_FRUIT, Channel.PICKUP_FRUIT_FX);
                    Destroy(this.gameObject);
                    break;
                case "Key": Debug.Log("Player has key!");
                    playerRef.hasKey = true;
                    soundManager.PlaySoundFX(Sounds.PICKUP_KEY, Channel.PICKUP_KEY_FX);
                    Destroy(this.gameObject);
                    break;
                case "ExtraLife":
                    Debug.Log("Player picked up an extra life!");
                    soundManager.PlaySoundFX(Sounds.RESTORE_HEALTH, Channel.RESTORE_HEALTH_FX);
                    Destroy(this.gameObject);
                    break;
                case "WinningTrophy":
                    Destroy(this.gameObject);
                    SceneManager.LoadScene("GameWonScene");
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (playerRef.hasKey == true)
        {
            Debug.Log("Nice! The door is open.");
            soundManager.PlaySoundFX(Sounds.UNLOCK_DOOR, Channel.UNLOCK_DOOR_FX);
            Destroy(this.gameObject);
        }
        if (playerRef.hasKey == false)
        {
            Debug.Log("You dont have a key!");
            NoKeyPopup.SetActive(true);
            if (timer == 4.0f)
            {
                NoKeyPopup.SetActive(false);
                timer = 0;
            }
        }
    }
}
