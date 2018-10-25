using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {

    public CharacterController2D controller;
    Rigidbody2D rb;
    float horizontalMove = 0f;
    public float runSpeed = 30f;
    bool jump = false;
    bool crouch = false;
	
	// Update is called once per frame
	void Update ()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
	}
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }

    void fixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platforms"))
            this.transform.parent = collision.transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platforms"))
            this.transform.parent = null;
    }
}
