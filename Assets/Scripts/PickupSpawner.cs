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
