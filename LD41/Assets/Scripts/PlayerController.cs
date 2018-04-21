using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    Rigidbody2D rigid;
    float maximumSpeed = 10f;
    bool isGrounded;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();		
    }
	
    // Update is called once per frame
    void Update () {
        isGrounded = Physics2D.Raycast((Vector2)transform.position-new Vector2(0, 1.01f), Vector2.down, 0.5f);

        if (Input.GetAxis("Horizontal") > 0)
            rigid.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        if (Input.GetAxis("Horizontal") < 0)
            rigid.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
       
        Vector2 vel = rigid.velocity; 
        if (Input.GetAxis("Horizontal") == 0)
            rigid.velocity = new Vector2(0, vel.y);

        if (vel.x > maximumSpeed)
            rigid.velocity = new Vector2(maximumSpeed, vel.y);
        if (vel.x < -maximumSpeed)
            rigid.velocity = new Vector2(-maximumSpeed, vel.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
            rigid.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
    }
}
