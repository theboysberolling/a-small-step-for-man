using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class textscore : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public TMP_Text txt;
    public float heightoincrementscore;
    private int currentscore = 0;
    private float initialheight;
    void Start()
    {
        
        txt = gameObject.GetComponent<TMP_Text>();
        initialheight = rb.transform.position.y;
        //rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Score : " + currentscore;
        currentscore =(int)((0.5+rb.transform.position.y-initialheight)/ heightoincrementscore);
    }
}
