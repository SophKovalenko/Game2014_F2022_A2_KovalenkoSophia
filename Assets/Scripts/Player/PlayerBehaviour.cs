//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 2
//  Courageous City Crawler!! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a platform mobile game still in development.
//
//  Created: December 5th, 2022
//  Last modified: December 11th, 2022
//  - this script controls the player and their interactions with the game scene as well as movement
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement Properties")]
    public float horizontalForce;
    public float horizontalSpeed;
    public float verticalForce;
    public float airFactor;
    public Transform groundPoint; // origin of the circle
    public float groundRadius; // size of the circle
    public LayerMask groundLayerMask; // the stuff we can colide with
    public bool isGrounded;
    public bool isFacingRight = true;

    [Header("Animations")]
    public Animator animator;
    public PlayerAnimationState playerAnimationState;

    //[Header("Dust Trail Properties")]
    //public ParticleSystem dustTrail;
    //public Color dustTrailColor;

    [Header("Screen Shake Properties")]
    public CinemachineVirtualCamera playerCamera;
    public CinemachineBasicMultiChannelPerlin perlin;
    public float shakeIntensity;
    public float shakeDuration;
    public float shakeTimer;
    public bool isCameraShaking;
    private int pushbackForce = 8; // How much should player be knocked back on collision?

    [Header("Health System")]
    public HealthManager healthManagerRef;
    public DeathPlaneController deathPlane;
    public int playerLives;

    [Header("Controls")]
    public Joystick leftStick;
    [Range(0.1f, 1.0f)]
    public float verticalThreshold;

    private Rigidbody2D rigidBody;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private SoundManager soundManager;

    void Start()
    {
        //Find the rigid body attached to the player
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        deathPlane = FindObjectOfType<DeathPlaneController>();
        soundManager = FindObjectOfType<SoundManager>();
        bulletPrefab = Resources.Load<GameObject>("Prefabs/playerBullet");
        leftStick = (Application.isMobilePlatform) ? GameObject.Find("LeftStick").GetComponent<Joystick>() : null;

        playerLives = 3;

        playerCamera = GameObject.Find("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
        perlin = playerCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        isCameraShaking = false;
        shakeTimer = shakeDuration;
    }

    void Update()
    {
        if (playerLives <= 0)
        {
            soundManager.PlaySoundFX(Sounds.PLAYER_DEATH, Channel.PLAYER_DEATH_FX);
            SceneManager.LoadScene("GameOverScene");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var hit = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundLayerMask);
        isGrounded = hit;

        Move();
        Jump();
        AirCheck();

        //Camera Shake Control
        if (isCameraShaking)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0.0f) // timed out
            {
                perlin.m_AmplitudeGain = 0.0f;
                shakeTimer = shakeDuration;
                isCameraShaking = false;
            }
        }
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal") + ((Application.isMobilePlatform) ? leftStick.Horizontal : 0.0f);

        if (x != 0.0f)
        {

            Flip(x);


            x = (x > 0.0) ? 1.0f : -1.0f;
            rigidBody.AddForce(Vector2.right * x * horizontalForce * ((isGrounded) ? 1.0f : airFactor));

            var clampedXVelocity = Mathf.Clamp(rigidBody.velocity.x, -horizontalSpeed, horizontalSpeed);
            rigidBody.velocity = new Vector2(clampedXVelocity, rigidBody.velocity.y);

            ChangeAnimation(PlayerAnimationState.RUN);
        }

        if ((isGrounded) && (x == 0.0f))
        {
            ChangeAnimation(PlayerAnimationState.IDLE);
        }

    }

    public void Flip(float x)
    {
        if (x != 0.0f)
        {
            transform.localScale = new Vector3((x > 0.0f) ? 1.0f : -1.0f, 1.0f, 1.0f);

            if (x == 1)
            { isFacingRight = true; }
            if (x == -1)
            { isFacingRight = false; }
        }
    }

    private void ShakeCamera()
    {
        perlin.m_AmplitudeGain = shakeIntensity;
        isCameraShaking = true;
    }

    private void Jump()
    {
        var y = Input.GetAxis("Jump") + ((Application.isMobilePlatform) ? leftStick.Vertical : 0.0f); ;

        if ((isGrounded) && (y > verticalThreshold))
        {
            rigidBody.AddForce(Vector2.up * verticalForce, ForceMode2D.Impulse);


            ChangeAnimation(PlayerAnimationState.JUMP);
            soundManager.PlaySoundFX(Sounds.JUMP, Channel.PLAYER_JUMP_FX);
        }
    }

    private void AirCheck()
    {
        if (!isGrounded)
        {
          ChangeAnimation(PlayerAnimationState.JUMP);
        }

    }

    private void ChangeAnimation(PlayerAnimationState animationState)
    {
        playerAnimationState = animationState;
        animator.SetInteger("AnimationState", (int)playerAnimationState);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerLives -= 1;
            soundManager.PlaySoundFX(Sounds.PLAYER_HURT, Channel.PLAYER_HURT_FX);
            ShakeCamera();

            // If player is facing right, knock them to the left
            // If player if facing left, knock them to the right
            if (isFacingRight == true)
            {
                rigidBody.AddForce(Vector2.left * pushbackForce, ForceMode2D.Impulse);
            }
            else if (isFacingRight == false)
            {
                rigidBody.AddForce(Vector2.right * pushbackForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            healthManagerRef.LoseLife();
            soundManager.PlaySoundFX(Sounds.PLAYER_HURT, Channel.PLAYER_HURT_FX);
            ShakeCamera();

            // If player is facing right, knock them to the left
            // If player if facing left, knock them to the right
            if (isFacingRight == true)
            {
                rigidBody.AddForce(Vector2.left * pushbackForce, ForceMode2D.Impulse);
            }
            else if (isFacingRight == false)
            {
                rigidBody.AddForce(Vector2.right * pushbackForce, ForceMode2D.Impulse);
            }
        }
    }

    public void OnAButton_Pressed()
    {
        //Fire player bullet
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        soundManager.PlaySoundFX(Sounds.PLAYER_BULLET, Channel.PLAYER_BULLET_FX);
    }

}
