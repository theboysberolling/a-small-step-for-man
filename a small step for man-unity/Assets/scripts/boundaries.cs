using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(transform.position.x >= 12.66f)
        {
            transform.position = new Vector3(12.66f, transform.position.y, 0);
        }
       else if(transform.position.x <= -13.16f)
        {
            transform.position = new Vector3(-13.16f, transform.position.y, 0);
        }
       
       
        
    }
}
