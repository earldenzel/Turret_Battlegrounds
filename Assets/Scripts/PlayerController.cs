using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float thrustForce;
    public float friction;
    public float rotationSpeed;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Thrust the ship if necessary
        rb.AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));
        

        //Floor Friction if button not pressed
        if(rb.velocity.magnitude > 0)
        {
            if (!Input.GetButtonDown("Vertical"))
            {
                float xVelocity = rb.velocity.x;
                float yVelocity = rb.velocity.y;
                rb.AddForce(friction * new Vector2(-xVelocity, -yVelocity));
            }
        }

        //does not allow rotation if under a certain magnitude
        if(rb.velocity.magnitude > 0.2)
        {
            transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        }
    }
}
