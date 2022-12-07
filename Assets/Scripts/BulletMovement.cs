using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletDirection    
{ 
    RIGHT,
    LEFT
}


public class BulletMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    [Header("Bullet Properties")]
    public int bulletSpeed;
    public BulletDirection bulletDirection;
    private Vector3 velocity;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bulletSpeed = 10;

        SetDirection((spriteRenderer.flipX == true ? BulletDirection.RIGHT : BulletDirection.LEFT));
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer != null)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
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
}



//void CheckBounds()
//{
//    if ((transform.position.x > bounds.horizontal.maxBoundary) ||
//        (transform.position.x < bounds.horizontal.minBoundary) ||
//        (transform.position.y > bounds.vertical.maxBoundary) ||
//        (transform.position.y < bounds.vertical.minBoundary))
//    {
//        // return the bullet to the pool
//        bulletManager.ReturnBullet(this.gameObject, bulletType);
//    }
//}
