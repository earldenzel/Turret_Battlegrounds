using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorModifier : MonoBehaviour {

    public float modifier;

    private GameObject player;
    private float originalThrustForce;
    private float originalRotationSpeed;
    private float myTime;
    private bool onTile;
    
    // Use this for initialization
    void Start () {
        myTime = 0.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        originalThrustForce = player.GetComponent<PlayerController>().thrustForce;
        originalRotationSpeed = player.GetComponent<PlayerController>().rotationSpeed;
    }

    void Update()
    {
        //reverts the thrust and rotation speed of the player controller back to normal values after 3 seconds of not in effect tile
        myTime += Time.deltaTime;
        if (myTime > 3.0f)
        {
            player.GetComponent<PlayerController>().thrustForce = originalThrustForce;
            player.GetComponent<PlayerController>().rotationSpeed = originalRotationSpeed;
            myTime = 0.0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().thrustForce = originalThrustForce * modifier;
            player.GetComponent<PlayerController>().rotationSpeed = originalRotationSpeed * modifier;
        }
    }
}
