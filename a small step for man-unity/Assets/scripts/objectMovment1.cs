using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class objectMovment1 : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float velocity = 1f;
    [SerializeField] private Rigidbody2D rb;
    public  Rigidbody2D rocket;
    private bool first = true;
    private float verticalcomponent;
    //[SerializeField] private float Xaxis = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //adding force to the object
    void FixedUpdate()
    {   if (first)
        {
            //rb= GetComponent<Rigidbody2D>();
      
            if (gameObject.transform.position.x > rocket.transform.position.x)
            {
                velocity = velocity* - 1f;
            }
            first = false;
// verticalcomponent = Random.Range(-2f, 2f);

        }
           
        if (velocity >= maxSpeed)
        {
            rb.velocity = (new Vector2 (velocity, maxSpeed));
        }
        else if (velocity <= -maxSpeed)
        {
            rb.velocity = (new Vector2(velocity, -maxSpeed));
        }
        rb.AddForce(new Vector2 (velocity, 0f));
    }
}

