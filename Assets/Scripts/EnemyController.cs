using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Properties")]
    public float horizontalSpeed;
    public Transform inFrontPoint;
    public Transform aheadPoint;
    public Transform groundPoint; // origin of the circle
    public float groundRadius; // size of the circle
    public LayerMask groundLayerMask; // the stuff we can colide with
    public bool isObstacleAhead;
    public bool isGroundAhead;
    public bool isGrounded;// Start is called before the first frame update
    public Vector2 direction;

    [Header("Bullet Properties")]
    public GameObject enemyBullet;
    private SpriteRenderer flippedBullet;
    private Rigidbody2D rb;
    public bool firesDarts = false;
    private bool isFacingRight = false;
    private float bulletSpawnInterval = 4f;

    void Start()
    {
        direction = Vector2.left;

        if (firesDarts == true)
        {
            StartCoroutine(SpawnEnemyBullets());
        }
    }

    // Update is called once per frame
    void Update()
    {
        isObstacleAhead = Physics2D.Linecast(groundPoint.position, inFrontPoint.position, groundLayerMask);
        isGroundAhead = Physics2D.Linecast(groundPoint.position, aheadPoint.position, groundLayerMask);
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundLayerMask);

        if (isGrounded && isGroundAhead)
        {
            Move();
        }

        if (!isGroundAhead || isObstacleAhead)
        {
            Flip();
        }
    }

    public void Move()
    {
        transform.position += new Vector3(direction.x * horizontalSpeed * Time.deltaTime, 0.0f);
    }

    public void Flip()
    {
        var x = transform.localScale.x * -1.0f;
        direction *= -1.0f;
        transform.localScale = new Vector3(x, 1.0f, 1.0f);

        if (x == 1)
        { isFacingRight = true; }
        if (x == -1)
        { isFacingRight = false; }
    }

    public void FireBullet()
    {
        flippedBullet = enemyBullet.gameObject.GetComponent<SpriteRenderer>();

        if (isFacingRight == false)
        {
            flippedBullet.flipX = true;
            Instantiate(flippedBullet, this.transform.position, Quaternion.identity); 
        }

        if (isFacingRight == true)
        {
            flippedBullet.flipX = false;
            Instantiate(flippedBullet, this.transform.position, Quaternion.identity);
        }
    }

    IEnumerator SpawnEnemyBullets()
    {
        FireBullet();
        yield return new WaitForSeconds(bulletSpawnInterval);
        StartCoroutine(SpawnEnemyBullets());
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
        Gizmos.DrawLine(groundPoint.position, inFrontPoint.position);
        Gizmos.DrawLine(groundPoint.position, aheadPoint.position);
    }
}

