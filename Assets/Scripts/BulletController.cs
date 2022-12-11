using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("BulletProperties")]
    public Vector2 direction;
    public Rigidbody2D rigidbody2D;
    [Range(1.0f, 30.0f)]
    public float force;
    public Vector3 offset;
    public BulletType bulletType;
    public BulletManager bulletManager;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Activate()
    {
        bulletManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<BulletManager>();
        Vector3 playerPosition = FindObjectOfType<PlayerBehaviour>().transform.position + offset;


        if (bulletType == BulletType.PLAYER)
        {
          //  if (playerPosition.x)
            direction = Vector2.right;
           // Rotate();
            Move();
          //  Invoke("DestroyYourself", 2.0f);
        }

        if (bulletType == BulletType.ENEMY)
        {
            //direction = (playerPosition - transform.position).normalized;
            //Rotate();
            //Move();
            //Invoke("DestroyYourself", 2.0f);
        }


    }

    private void Rotate()
    {
        rigidbody2D.AddTorque(Random.Range(5.0f, 15.0f) * direction.x * -1, ForceMode2D.Impulse);
    }

    private void Move()
    {
        rigidbody2D.AddForce(Vector2.up * 1000f, ForceMode2D.Force);
        Debug.Log("Moving");
    }

    private void DestroyYourself()
    {
        if (gameObject.activeInHierarchy)
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
        }
    }

    public void ResetAllPhysics()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.angularVelocity = 0;
        direction = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            || other.gameObject.CompareTag("Ground")
            || other.gameObject.CompareTag("Platform"))
        {
            DestroyYourself();
        }
    }

}


