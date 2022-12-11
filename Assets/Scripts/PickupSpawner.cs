///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 7th, 2022
//  Last modified: Dec 7th, 2022
//  - this script is responsible for randomly generating the fruit pickups based on set spawn points
////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    public Transform[] pickupSpawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        int lastPickupInterator = pickupPrefabs.Length;
        foreach (Transform spawnPoint in pickupSpawnLocations)
        {
            Instantiate(pickupPrefabs[Random.Range(0, lastPickupInterator)], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

}
