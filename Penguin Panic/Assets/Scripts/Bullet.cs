using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public int damage;
   public float lifetime;
   private float shootTime;

    void OnEnable()
    {
        shootTime = Time.time;
    }
  
    
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);        
    }
}
