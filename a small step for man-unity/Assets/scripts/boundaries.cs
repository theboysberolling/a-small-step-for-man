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
       if(transform.position.x >= 3.4f)
        {
            transform.position = new Vector3(3.4f, transform.position.y, 0);
        }
       else if(transform.position.x <= -4.3f)
        {
            transform.position = new Vector3(-4.3f, transform.position.y, 0);
        }
       
       
        
    }
}
