using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingPlatformScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float timer = 3.0f;
    public float repeatRate = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Find the rigidBody and use a coroutine to flip the platform 180 degrees
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Flip", timer, repeatRate);
    }

    void Flip()
    {
        transform.Rotate(new Vector3(-180, 0));      
    }
}
