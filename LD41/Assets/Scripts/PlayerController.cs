using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    Rigidbody rigid;
    float maximumSpeed = 10f;
    bool isGrounded;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();		
    }
	
    // Update is called once per frame
    void Update () {
        isGrounded = Physics.Raycast(transform.position-new Vector3(0, 1, 0), Vector2.down, 0.5f);

        if (Input.GetAxis("Horizontal") > 0)
            rigid.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        if (Input.GetAxis("Horizontal") < 0)
            rigid.AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
       
        Vector2 vel = rigid.velocity; 
        if (Input.GetAxis("Horizontal") == 0)
            rigid.velocity = new Vector3(0, vel.y, 0);

        if (vel.x > maximumSpeed)
            rigid.velocity = new Vector3(maximumSpeed, vel.y, 0);
        if (vel.x < -maximumSpeed)
            rigid.velocity = new Vector3(-maximumSpeed, vel.y, 0);

        if (Input.GetButtonDown("Jump"))
            rigid.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
    }
}
