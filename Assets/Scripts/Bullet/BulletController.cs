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
    public PlayerBehaviour playerRef;
    private ScoreManager scoreManager;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerRef = FindObjectOfType<PlayerBehaviour>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void FixedUpdate()
    {
         Rotate();
         Move();
    }

    private void Rotate()
    {
        rigidbody2D.AddTorque(Random.Range(5.0f, 15.0f) * direction.x * -1, ForceMode2D.Impulse);
    }

    private void Move()
    {
        if (playerRef.isFacingRight)
        {
            direction = Vector2.right;
            rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        }
        if (!playerRef.isFacingRight)
        {
            direction = Vector2.left;
            rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }

    private void DestroyYourself()
    {
        if (gameObject.activeInHierarchy)
        {
            Destroy(this.gameObject);
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
        if (other.gameObject.CompareTag("Ground")
            || other.gameObject.CompareTag("Platform"))
        {
            DestroyYourself();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            scoreManager.AddPoints(10);
            FindObjectOfType<SoundManager>().PlaySoundFX(Sounds.ENEMY_HURT, Channel.ENEMY_HURT_FX);
            Destroy(other.gameObject);
            DestroyYourself();
        }
    }

}