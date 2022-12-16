using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;
    public float scrollSpeed;
    private float score = textscore.currentscore;
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (GameObject obj in levels)
        {
            loadChildObjects(obj);
            

        }
    }

    void loadChildObjects(GameObject obj)
    {
        float objectHeight = obj.GetComponent<SpriteRenderer>().bounds.size.y - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.y * 2 / objectHeight);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(transform.position.y, objectHeight * i, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());

    }
    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectHeight = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y - choke;
            if (transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectHeight)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectHeight * 2, lastChild.transform.position.z);
            }
            else if (transform.position.y - screenBounds.y < firstChild.transform.position.y - halfObjectHeight)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x,firstChild.transform.position.y - halfObjectHeight * 2, firstChild.transform.position.z);
            }
        }
    }
    void Update()
    {

        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

    }
    void LateUpdate()
    {
        foreach (GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}
