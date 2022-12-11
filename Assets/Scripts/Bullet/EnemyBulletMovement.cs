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
