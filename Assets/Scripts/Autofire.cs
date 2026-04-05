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
    private GameObject boss;

    //Time delay for shooting
    public float nextFire = 1.0f;
    private float myTime = 0.0f;
    private float myFire = 1.0f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
    }
	
	// Update is called once per frame
	void Update () {
        myTime += Time.deltaTime;
        distance = (player.transform.position - transform.position).magnitude;

        if (gameObject.tag == "Homing" && distance < detectDistance && player.GetComponent<Renderer>().enabled == true)
        {
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion facePlayer = Quaternion.Euler(0, 0, angle - 90);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, facePlayer, rotationSpeed * Time.deltaTime);
        }

        if ((myTime > myFire) 
            && (distance < detectDistance) 
            && (player.GetComponent<Renderer>().enabled == true)
            && boss != null)
        {
            Instantiate(bullet, tankBarrel.position, tankBarrel.rotation);
            myTime = 0.0f;
            float randomValue = Random.value;
            if (randomValue > 0.9f)
            {
                myFire = 0.25f * nextFire;
            }
            else if (randomValue > 0.8f)
            {
                myFire = 0.5f * nextFire;
            }
            else
            {
                myFire = nextFire;
            }
        }
    }
}
