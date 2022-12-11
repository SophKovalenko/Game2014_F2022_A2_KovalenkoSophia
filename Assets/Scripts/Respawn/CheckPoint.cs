///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 6th, 2022
//  Last modified: Dec 6th, 2022
//  - this script is responsible for setting the checkpoint the player will respawn at after losing a life
////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<DeathPlaneController>().currentCheckPoint = transform;
        }
    }
}
