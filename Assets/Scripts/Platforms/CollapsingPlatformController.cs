using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatformController : MonoBehaviour
{
    public float timeUntilCollapse = 3f;
    private bool playerOnPlatform = false;
    private bool platformDestroyed = false;
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform == true && timeUntilCollapse > 0)
        { 
            timeUntilCollapse-= Time.deltaTime;

            if (timeUntilCollapse <= 0)
            {
                playerOnPlatform = false;
                Destroy(this.gameObject);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerOnPlatform = true;
            particleSystem.Play();
        }
    }
}
