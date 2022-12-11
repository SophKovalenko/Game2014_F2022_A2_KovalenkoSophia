///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 11th, 2022
//  Last modified: Dec 11th, 2022
//  - this script manages displaying and incrementing the players score
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ScoreManager : MonoBehaviour
{
    private TMP_Text scoreLabel;

    void Start()
    {
        scoreLabel = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        SetScore(0);
    }

    public int GetScore()
    {
        return ScoreKeeper.totalScore;
    }

    public void SetScore(int newScore)
    {
        ScoreKeeper.totalScore = newScore;
        UpdateScoreLabel();
    }

    public void AddPoints(int points)
    {
        ScoreKeeper.totalScore += points;
        UpdateScoreLabel();
    }

    public void UpdateScoreLabel()
    {
        scoreLabel.text = $"Score: {ScoreKeeper.totalScore}";
    }
}

