using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autofire : MonoBehaviour {
    
    public GameObject bullet;
    public Transform tankBarrel;
    public float detectDistance = 4.0f;
    public float rotationSpeed = 5.0f;
    
    private float distance;
    private GameObject player;

    //Time delay for shooting
    public float nextFire = 1.0f;
    private float myTime = 0.0f;
    private float myFire = 1.0f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        myTime += Time.deltaTime;
        distance = (player.transform.position - transform.position).magnitude;

        if ((myTime > myFire) && (distance < detectDistance) && (player.GetComponent<Renderer>().enabled == true))
        //if (myTime > nextFire)
        {
            if (gameObject.tag == "Homing")
            {
                //these now rotate smoothly towards the player
                Vector3 dir = player.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion facePlayer = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                transform.rotation = Quaternion.Lerp(transform.rotation, facePlayer, Time.deltaTime * rotationSpeed);
            }
            Instantiate(bullet, tankBarrel.position, tankBarrel.rotation);
            myTime = 0.0f;
            float randomValue = Random.value;
            if (randomValue > 0.9f){
                myFire = 0.25f * nextFire;
            }
            else if (randomValue > 0.8f){
                myFire = 0.5f * nextFire;
            }
            else{
                myFire = nextFire;
            }
        }
    }
}
