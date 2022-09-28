using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maxVelocity ;
    public float acceleration;
    public float rotationSpeed ;
    
    #region Monobehaviour API
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
        float yAxis = Input.GetAxis("Vertical");

        float xAxis = Input.GetAxis("Horizontal");

        ThrustForward(yAxis* acceleration);

        Rotate(transform, xAxis * - rotationSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {

            Destroy(gameObject);
            Application.Quit();
        }
    }
    #endregion

    #region Maneuvering API

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, - maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, - maxVelocity, maxVelocity);
        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        rb.AddForce(force);
    }
    private void Rotate (Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    #endregion
}
