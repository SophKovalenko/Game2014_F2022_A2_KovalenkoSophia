///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 7th, 2022
//  Last modified: Dec 11th, 2022
//  - this script manages the respawn system for the player
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeathPlaneController : MonoBehaviour
{
    public Transform currentCheckPoint;
    public HealthManager healthManagerRef;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerBehaviour>();
            healthManagerRef.LoseLife();

            if (healthManagerRef.playerReference.playerLives > 0)
            {
                ReSpawn(other.gameObject);

               FindObjectOfType<SoundManager>().PlaySoundFX(Sounds.PLAYER_HURT, Channel.PLAYER_HURT_FX);
            }
        }
    }

    public void ReSpawn(GameObject go)
    {
        go.transform.position = currentCheckPoint.position;
    }
}

