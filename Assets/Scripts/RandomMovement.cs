using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {


    private Rigidbody2D rb;
    private GameObject player;
    private float distance;
    public float force;
    public float tumble;
    public float detectDistance = 4.0f;

    //Time delay for moving
    public float nextMove = 2.0f;
    public float nextRotate = 4.0f;
    private float myMoveTime = 0.0f;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        myMoveTime += Time.deltaTime;
        distance = (player.transform.position - transform.position).magnitude;

        if ((myMoveTime > nextMove) && (distance < detectDistance))
        {
            //30% chance to face, 35% chance to move forward, 35% chance to randomly turn;
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion facePlayer = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            if (Random.value > 0.65f)
            {
                rb.AddForce((Random.value - 0.5f) * rb.transform.up * force);
            }
            else if (Random.value > 0.35f)
            {
                //this facing should be gradual, but does not
                rb.transform.rotation = facePlayer;
            }
            else
            {
                rb.angularVelocity = tumble * (Random.value - 0.5f);
            }
            myMoveTime = 0.0f;
        }
    }
}