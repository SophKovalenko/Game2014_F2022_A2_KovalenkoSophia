//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a platform mobile game still in development.
//
//  Created: December 5th, 2022
//  Last modified: December 5th, 2022
//  - this script controls the player anamations
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PlayerAnimationState
{
    IDLE,
    RUN,
    JUMP
}