using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public int damage;

    //Enemy Dies on impact
    void OnTriggerEnter(Collider other)
    {
        // If hit deal out damage to the Player     
        if(other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);
    }

}
