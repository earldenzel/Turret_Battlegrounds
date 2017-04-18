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
            Instantiate(bullet, tankBarrel.position, tankBarrel.rotation);
            myTime = 0.0f;
        }
    }
}
