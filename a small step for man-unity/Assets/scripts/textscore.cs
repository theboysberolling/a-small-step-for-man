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
    public static int currentscore = 0;
    private float initialheight;
    public float maxasteroid_per_seconds = 60;
    //count is for if timer
    private int count = 0;
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

        ObjectSpawn.manypersecond = Mathf.Max(1,0.1f / 1 + Mathf.Pow(1.03f, -currentscore- maxasteroid_per_seconds) * maxasteroid_per_seconds+Mathf.Sin(currentscore/4)*4);
       // this is to win the game and earn rebirth point/ we will add rebirths later.
        if (count == 0)
        {
            
            if (currentscore == 10)
            {
                Debug.Log("you have won");
                count++;
                

            }
            return;
        }

    }
    
    
      
    
}
