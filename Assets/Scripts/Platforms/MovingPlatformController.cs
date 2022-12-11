///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 6th, 2022
//  Last modified: Dec 7th, 2022
//  - this script manages the moving platforms in the scene
////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public PlatformDirection direction;

    [Header("Movement Properties")]
    [Range(1.0f, 20.0f)]
    public float horizontalDistance = 8.0f;
    [Range(1.0f, 20.0f)]
    public float horizontalSpeed = 3.0f;
    [Range(1.0f, 20.0f)]
    public float verticalDistance = 8.0f;
    [Range(1.0f, 20.0f)]
    public float verticalSpeed = 3.0f;

    private Vector2 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        switch (direction)
        {
            case PlatformDirection.HORIZONTAL:
                transform.position = new Vector2(Mathf.PingPong(horizontalSpeed * Time.time, horizontalDistance) + startPoint.x,
                    startPoint.y);
                break;
            case PlatformDirection.VERTICAL:
                transform.position = new Vector2(startPoint.x, Mathf.PingPong(verticalSpeed * Time.time, verticalDistance) + startPoint.y);
                break;
            case PlatformDirection.DIAGONAL_UP:
                transform.position = new Vector2(Mathf.PingPong(horizontalSpeed * Time.time, horizontalDistance) + startPoint.x,
                    Mathf.PingPong(verticalSpeed * Time.time, verticalDistance) + startPoint.y);
                break;
            case PlatformDirection.DIAGONAL_DOWN:
                transform.position = new Vector2(Mathf.PingPong(horizontalSpeed * Time.time, horizontalDistance) + startPoint.x,
                    startPoint.y - Mathf.PingPong(verticalSpeed * Time.time, verticalDistance));
                break;
        }
    }
}
