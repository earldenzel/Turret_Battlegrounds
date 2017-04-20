using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float thrustForce;
    public float rotationSpeed;
    public float backLimit;

    public GameObject bullet;
    public Transform tankBarrel;

    private Rigidbody2D rb;
    private float multiplier;
    private bool onSecret;
    
    //Time delay for shooting
    public float nextFire = 0.5f;
    private float myTime = 0.0f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        onSecret = false;
    }

    void Update()
    {
        myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && (myTime > nextFire) && (GetComponent<Renderer>().enabled == true))
        {
            Instantiate(bullet, tankBarrel.position, tankBarrel.rotation);
            myTime = 0.0f;
        }
    }
	
	void FixedUpdate () {
        // Thrust the tank if necessary. Pressing the reverse key will use backLimit which should be between 0 and 1.
        // To simulate tank heaviness, please tweak linear drag and angular drag settings
        if (GetComponent<Renderer>().enabled == true)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                multiplier = backLimit * Input.GetAxis("Vertical");
            }
            else
            {
                multiplier = Input.GetAxis("Vertical");
            }
            rb.AddForce(transform.up * thrustForce * multiplier);

            // Rotate the tank if necessary
            transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

            //First teleport map. Will probably put a non-collider sprite later!
            if (transform.position.y > 49 && transform.position.y < 50 && transform.position.x > 0 && transform.position.x < 4)
            {
                transform.position = new Vector3(transform.position.x + 7, transform.position.y - 23);
            }

            //Second teleport map. To secret area.
            if (transform.position.y > 52 && transform.position.y < 54 && transform.position.x > 0 && transform.position.x < 1 && !onSecret)
            {
                transform.position = new Vector3(transform.position.x + 18, transform.position.y - 5);
            }
            if (transform.position.y > 47 && transform.position.y < 49 && transform.position.x > 15 && transform.position.x < 18 && !onSecret)
            {
                onSecret = true;
            }
            if (transform.position.y > 47 && transform.position.y < 49 && transform.position.x > 18 && transform.position.x < 19 && onSecret)
            {
                transform.position = new Vector3(transform.position.x - 18, transform.position.y + 5);
                onSecret = false;
            }

            //Last teleport map to boss.
            if (transform.position.y > 71 && transform.position.y < 74 && transform.position.x > 18 && transform.position.x < 19)
            {
                transform.position = new Vector3(transform.position.x - 18, transform.position.y + 10);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }
}
