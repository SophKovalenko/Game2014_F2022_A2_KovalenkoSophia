///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 11th, 2022
//  Last modified: Dec 11th, 2022
//  this script manages displaying the player's final score in the end scenes
//////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    public TMP_Text finalScoreText;

    //Display the final player score when game ends (win or lose)
    void Update()
    {
        finalScoreText.text = "Final Score: " + ScoreKeeper.totalScore + "";
    }
}
