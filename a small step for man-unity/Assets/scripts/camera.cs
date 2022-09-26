using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.rotation = Quaternion.identity;

    }


}
