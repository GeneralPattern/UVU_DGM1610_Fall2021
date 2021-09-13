using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public float turnspeed;

    public float hInput;

    public float vInput;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      hInput = Input.GetAxis("Horizontal");
      vInput = Input.GetAxis("Vertical");

      //move the tank left and right
      transform.Rotate(Vector3.up, turnspeed * hInput * Time.deltaTime);
      //Move the tank forward and back
      transform.Translate(Vector3.forward * speed * Time.deltaTime *vInput);
    }
}
