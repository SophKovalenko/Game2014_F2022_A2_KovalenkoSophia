///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 10th, 2022
//  Last modified: Dec 10th, 2022
//  - this script is responsible for creating bullets for the enemy and player
////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    // Bullet Prefabs
    private GameObject playerBulletPrefab;
    private GameObject enemyBulletPrefab;

    // Bullet Parent
    private Transform bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    { 
        playerBulletPrefab = Resources.Load<GameObject>("Prefabs/playerBullet");
        enemyBulletPrefab = Resources.Load<GameObject>("Prefabs/enemyDart");
        bulletParent = GameObject.Find("[BULLETS]").transform;
    }

    public GameObject CreateBullet(BulletType type)
    {

        if (type == BulletType.PLAYER)
        {
            GameObject pBullet = Instantiate(playerBulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);
            pBullet.SetActive(false);
            return pBullet;
        }
        else 
        {
            GameObject eBullet = Instantiate(enemyBulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);
            eBullet.SetActive(false);
            return eBullet;
        }

    }

}
