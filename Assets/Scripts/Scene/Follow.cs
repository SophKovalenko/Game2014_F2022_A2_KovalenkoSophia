//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a platform mobile game still in development.
//
//  Created: December 5th, 2022
//  Last modified: December 5th, 2022
//  - this script is responsible for making sprites follow the player in the scene
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Target
{
    public Transform transform;
    public Vector2 offset;
    public bool x;
    public bool y;
}

[ExecuteInEditMode]
public class Follow : MonoBehaviour
{
    public Target target;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            (target.x) ? target.transform.position.x + target.offset.x : transform.position.x,
            (target.y) ? target.transform.position.y + target.offset.y : transform.position.y,
            transform.position.z
            );
    }
}
