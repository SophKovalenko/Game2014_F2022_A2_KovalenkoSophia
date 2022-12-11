//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a platform mobile game still in development.
//
//  Created: December 5th, 2022
//  Last modified: December 5th, 2022
//  - this script controls the health icons displayed in the game scene based on the players lives
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public GameObject lifeOnePrefab;
    public GameObject lifeTwoPrefab;
    public GameObject lifeThreePrefab;
    public PlayerBehaviour playerReference;

    // Update is called once per frame
    void Update()
    {
        if (playerReference.playerLives == 3)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(true);
            lifeThreePrefab.SetActive(true);
        }

        if (playerReference.playerLives == 2)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(true);
            lifeThreePrefab.SetActive(false);
        }

        if (playerReference.playerLives == 1)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(false);
            lifeThreePrefab.SetActive(false);
        }

        if (playerReference.playerLives == 0)
        {
            lifeOnePrefab.SetActive(false);
            lifeTwoPrefab.SetActive(false);
            lifeThreePrefab.SetActive(false);
        }
    }

    public void ResetLives()
    {
        playerReference.playerLives = 0;
    }

    public void AddLife()
    {
        playerReference.playerLives += 1;
    }

    public void LoseLife()
    {
        playerReference.playerLives -= 1;

        if (playerReference.playerLives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        FindObjectOfType<SoundManager>().PlaySoundFX(Sounds.PLAYER_DEATH, Channel.PLAYER_DEATH_FX);
        SceneManager.LoadScene("GameOverScene");
    }
}

