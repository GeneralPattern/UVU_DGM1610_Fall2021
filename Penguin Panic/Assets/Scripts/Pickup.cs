using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupType type;

    public int value;

    [Header("Bobbing Animation")]
    
    public float rotationSpeed;

    public float bobSpeed;

    public float bobHeight;

    private bool bobbingUp;

    private Vector3 startPos;


    void Start()
    {
        startPos = transform.position;

    }

    //Distinguish powerup type
    public enum PickupType
    {
        Powerup,
        Ammo
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();


        switch(type)
        {
            
            case PickupType.Ammo:
            player.GiveAmmo(value);
            break;
            default:
            print("Ype not accepted");
            break;
        }

            Destroy(gameObject);
        }
    }

    void Update()
    {
        //Creates bobbing and spinning effect
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight, 0));

        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }
}
