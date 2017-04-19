using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointController : MonoBehaviour {

    private GameObject oldSpawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            oldSpawn = GameObject.FindGameObjectWithTag("Active");
            if (oldSpawn != null) oldSpawn.gameObject.tag = "Finished";
            this.gameObject.tag = "Active";
        }
    }
}
