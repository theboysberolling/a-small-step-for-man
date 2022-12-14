
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Profiling;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] public GameObject asteroidPrefab;
    [SerializeField] public static float manypersecond = 1;
    
    private float manyper;
    float scale;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {   
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
       

    }

    // Update is called once per frame
    private void spawnEnemy()
    {
        //Vector2 randpos = new Vector2(screenBounds.x+ Random.Range(0,screenBounds.x), Random.Range(0, screenBounds.y));
        //Instantiate(asteroidPrefab, randpos, Quaternion.identity);
        // Destroy(gameObject);
        GameObject a = Instantiate (asteroidPrefab) as GameObject;

        if( Random.Range(0, 100) >= 50)
        {
            a.transform.position = new Vector2(20f + gameObject.transform.position.x+ Random.Range(0,30), Random.Range(Mathf.Max(0, gameObject.transform.position.y - 20), gameObject.transform.position.y + 120));

        }
        else
        {
            a.transform.position = new Vector2(-20f + gameObject.transform.position.x - Random.Range(0, 30), Random.Range(Mathf.Max(0, gameObject.transform.position.y - 20), gameObject.transform.position.y + 120));

        }
        scale = Random.Range(0, 0.3f);
        a.transform.localScale += new Vector3(scale, scale, scale);

        Destroy(a, 20);
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            
            for (manyper=0; manyper<= 1; manyper+= 1/ manypersecond)
            {
                yield return new WaitForSeconds(1/manypersecond);
                spawnEnemy();
            }
         
        }
    }
}
