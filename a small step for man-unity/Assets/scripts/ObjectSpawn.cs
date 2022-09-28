using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] public GameObject asteroidPrefab;
    [SerializeField] public static float manypersecond = 1;
    
    private float manyper;
    
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
        a.transform.position = new Vector2(screenBounds.x+Random.Range(0, screenBounds.x), Random.Range(Mathf.Max(0,gameObject.transform.position.y-20), gameObject.transform.position.y+120));
        
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
