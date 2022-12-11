///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 7th, 2022
//  Last modified: Dec 7th, 2022
//  - this script is responsible keeping the player on the platforms
////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(transform);
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.transform.SetParent(null);
    }
}
