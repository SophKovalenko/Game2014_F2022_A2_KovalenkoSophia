///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 11th, 2022
//  Last modified: Dec 11th, 2022
//  - this script is responsible for setting the channel for SFX
////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Channel
{
    PLAYER_JUMP_FX,
    PLAYER_HURT_FX,
    PLAYER_DEATH_FX,
    PLAYER_BULLET_FX,
    RESTORE_HEALTH_FX,
    ENEMY_BULLET_FX,
    ENEMY_HURT_FX,
    PICKUP_KEY_FX,
    PICKUP_FRUIT_FX,
    UNLOCK_DOOR_FX
}
