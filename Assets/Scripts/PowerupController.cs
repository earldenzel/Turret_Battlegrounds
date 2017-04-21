using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour {

    private GameObject player;
    public AudioClip success;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(success, this.transform.position, this.transform.rotation); //musics on powerup  
            player.GetComponent<PlayerController>().AddPowerUp();
            Destroy(gameObject);
        }
    }
}
