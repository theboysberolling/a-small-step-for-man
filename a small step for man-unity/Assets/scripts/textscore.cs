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
    public float heightoincrementscore=5;
    private int currentscore = 0;
    private float initialheight;
    public float maxasteroid_per_seconds = 60;
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

        ObjectSpawn.manypersecond = 1 / 1 + Mathf.Pow(1.05f, -currentscore- maxasteroid_per_seconds/2f) * maxasteroid_per_seconds+Mathf.Sin(currentscore/4)*4;
    }
}
