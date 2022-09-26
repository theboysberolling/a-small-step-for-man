using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMovment1 : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float velocity = 1f;
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private float Xaxis = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //adding force to the object
    void FixedUpdate()
    {
        if (velocity >= maxSpeed)
        {
            rb.velocity = (new Vector2 (velocity, maxSpeed));
        }
        rb.AddForce(new Vector2 (-velocity, 0f));
    }
}

