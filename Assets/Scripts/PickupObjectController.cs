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
    private bool playerHasKey = false;
   

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        
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
                    Destroy(this.gameObject);
                    break;
                case "Melon_Pickup(Clone)":
                    scoreManager.AddPoints(30);
                    Destroy(this.gameObject);
                    break;
                case "Cherries_Pickup(Clone)":
                    scoreManager.AddPoints(40);
                    Destroy(this.gameObject);
                    break;
                case "Pineapple_Pickup(Clone)":
                    scoreManager.AddPoints(50);
                    Destroy(this.gameObject);
                    break;
                case "Key": Debug.Log("Player has key!");
                    playerHasKey = true;
                    Destroy(this.gameObject);
                    break;
                case "ExtraLife":
                    Debug.Log("Player picked up an extra life!");
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
        if ((other.gameObject.name == "Player") && (playerHasKey == true))
        {
            Debug.Log("Nice! The door is open.");
            Destroy(this.gameObject);
        }
        if ((other.gameObject.name == "Player") && (playerHasKey == false))
        {
            Debug.Log("You dont have a key!");
            //TODO: popup window
        }
    }
}
