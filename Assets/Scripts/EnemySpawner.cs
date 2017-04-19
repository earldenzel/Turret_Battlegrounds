using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    //note that this script controls the enemy spawner

    public GameObject enemy_tank;
    public float detectDistance = 4.0f;
    public float nextSpawn;

    private GameObject player;
    private Vector3 randomPosition;
    private float distance;
    private float myTime;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        myTime += Time.deltaTime;
        distance = (player.transform.position - transform.position).magnitude;

        if ((myTime > nextSpawn) && (distance < detectDistance))
        {
            float random_x = 2 * (Random.value - 0.5f);
            float random_y = 2 * (Random.value - 0.5f);
            randomPosition = new Vector3((transform.position.x + random_x), (transform.position.y + random_y));
            
            //objects in the spawner will face the player!
            Vector3 dir = player.transform.position - randomPosition;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion facePlayer = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            Instantiate(enemy_tank, randomPosition, facePlayer);
            
            myTime = 0.0f;
        }

    }
}
