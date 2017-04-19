using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autofire : MonoBehaviour {
    
    public GameObject bullet;
    public Transform tankBarrel;
    public float detectDistance = 4.0f;
    
    private float distance;
    private GameObject player;

    //Time delay for shooting
    public float nextFire = 1.0f;
    private float myTime = 0.0f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        myTime += Time.deltaTime;
        distance = (player.transform.position - transform.position).magnitude;

        if ((myTime > nextFire) && (distance < detectDistance))
        //if (myTime > nextFire)
        {
            if (gameObject.tag == "Homing")
            {
                //these should rotate in a smooth manner, but doesn't
                Vector3 dir = player.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion facePlayer = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                transform.rotation = facePlayer;
            }
            Instantiate(bullet, tankBarrel.position, tankBarrel.rotation);
            myTime = 0.0f;
        }
    }
}
