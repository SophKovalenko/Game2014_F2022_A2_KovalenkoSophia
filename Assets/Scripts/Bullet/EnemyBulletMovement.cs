///////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile platformer still in development.
//
//  Created: Dec 8th, 2022
//  Last modified: Dec 11th, 2022
//  - this script manages the enemy bullet movement in the scene and is responsible for cleanup
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletDirection
{
    RIGHT,
    LEFT
}


public class EnemyBulletMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private PlayerBehaviour playerRef;

    [Header("Bullet Properties")]
    public int bulletSpeed;
    public BulletDirection bulletDirection;
    private Vector3 velocity;

    private float timer = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bulletSpeed = 10;

        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();

        SetDirection((spriteRenderer.flipX == true ? BulletDirection.RIGHT : BulletDirection.LEFT));
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer != null)
        {
            Move();

            if (timer >= 3.0f)
            {
                DestroyBullet();
            }
        }
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
        timer += Time.deltaTime;
      
    }

    public void SetDirection(BulletDirection direction)
    {
        switch (direction)
        {
            case BulletDirection.RIGHT:
                velocity = Vector3.right * bulletSpeed;
                break;
            case BulletDirection.LEFT:
                velocity = Vector3.left * bulletSpeed;
                break;
        }
    }

    public void DestroyBullet()
    {
        Destroy(this.gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRef.playerLives -= 1;
            FindObjectOfType<SoundManager>().PlaySoundFX(Sounds.PLAYER_HURT, Channel.PLAYER_HURT_FX);
            Debug.Log("Bullet hit player");
            DestroyBullet();
        }

        if (other.gameObject.CompareTag("Ground")
        || other.gameObject.CompareTag("Platform"))
        {
            DestroyBullet();
        }
    }

}
