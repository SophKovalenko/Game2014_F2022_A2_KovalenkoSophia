///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: November 18th, 2022
//  Last modified: November 18th, 2022
//  - this script is responsible for navigation between scenes on button clicks and via the game conditions
////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    private AudioSource UIAudio;
    public AudioClip buttonClick;

    public void Start()
    {
        UIAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("GameOverScene");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("GameWonScene");
        }
    }

    public void PlayUIAudio()
    {
       // UIAudio.PlayOneShot(buttonClick, 1.0f);
    }

    public void OnInstructionsButtonClicked()
    {
        SceneManager.LoadScene("InstructionsScene");
        PlayUIAudio();
    }


    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("GameplayScreen");
        PlayUIAudio();
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
        PlayUIAudio();
    }

    public void OnExitButtonClicked()
    {
        PlayUIAudio();

        //Quit the game if running as app
        Application.Quit();
    }

}

