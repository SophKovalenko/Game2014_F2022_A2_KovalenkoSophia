using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                case "Orange_Pickup": 
                    scoreManager.AddPoints(20);
                    Destroy(this.gameObject);
                    break;
                case "Melon_Pickup":
                    scoreManager.AddPoints(30);
                    Destroy(this.gameObject);
                    break;
                case "Cherries_Pickup":
                    scoreManager.AddPoints(40);
                    Destroy(this.gameObject);
                    break;
                case "Pineapple_Pickup":
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
                case "EndOfLevelDoor":
                    if (playerHasKey == true)
                    {
                        Debug.Log("Nice! The door is open.");
                        Destroy(this.gameObject);
                    }
                    if (playerHasKey == false)
                    {
                        Debug.Log("You dont have a key!");
                        //TODO: popup window
                    }
                    break;
                case "WinningTrophy":
                    Debug.Log("Level Complete!");
                    Destroy(this.gameObject);
                    //TODO: trigger GameWon state
                    break;
            }
        }
    }
}
