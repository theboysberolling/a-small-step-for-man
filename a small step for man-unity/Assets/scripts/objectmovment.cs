using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmovment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(Speed, 0f));
        
    }
}
