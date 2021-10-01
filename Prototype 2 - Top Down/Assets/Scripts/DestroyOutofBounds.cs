using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    public float topBound = 5.5f;

    public float botBound = -5.5f;

    public float rBound = 12f;

    public float lBound = -12f;



    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.y < botBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x > rBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < lBound)
        {
            Destroy(gameObject);
        }
    }
}
