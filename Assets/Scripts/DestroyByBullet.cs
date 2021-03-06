﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {

    private GameObject spawnpoint;
    public int hitsToKill;
    public int maxhp;
    public AudioClip tankdeath;
    public GameObject tankExplosion;

    // Use this for initialization
    void Start () {
        maxhp = hitsToKill;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hitsToKill = hitsToKill - 1;
            if (gameObject.tag == "Player")
            {
                if (hitsToKill <= 0)
                {
                    spawnpoint = GameObject.FindGameObjectWithTag("Active");
                    AudioSource.PlayClipAtPoint(tankdeath, Camera.main.transform.position);
                    Instantiate(tankExplosion, this.transform.position, this.transform.rotation); // spawn explosion at this collision  
                    StartCoroutine(DeathScene(spawnpoint));
                    hitsToKill = maxhp;
                }

            }
            else if (hitsToKill <= 0)
            {
                AudioSource.PlayClipAtPoint(tankdeath, Camera.main.transform.position);
                Destroy(this.gameObject);
                if (gameObject.tag != "Breakable") Instantiate(tankExplosion, this.transform.position, this.transform.rotation); // spawn explosion at this collision  
            }
            else
            {
                return;
            }            
            Destroy(collision.gameObject);
        }
        else
        {
            return;
        }
    }
    
    IEnumerator DeathScene(GameObject spawnpoint)
    {
        gameObject.GetComponent<Renderer>().enabled = false;

        foreach(Collider2D c in gameObject.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }

        //this is the bit where we show explosions//

        yield return new WaitForSeconds(5);
        gameObject.transform.position = spawnpoint.transform.position;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.GetComponent<Renderer>().enabled = true;

        foreach (Collider2D c in gameObject.GetComponents<Collider2D>())
        {
            c.enabled = true;
        }
    }
}
