using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    private GameObject spawnpoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spawnpoint = GameObject.FindGameObjectWithTag("Active");
            StartCoroutine(DeathScene(spawnpoint));
        }
    }

    IEnumerator DeathScene(GameObject spawnpoint)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Renderer>().enabled = false;

        foreach (Collider2D c in player.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }

        //this is the bit where we show lightning effects//

        yield return new WaitForSeconds(5);
        player.transform.position = spawnpoint.transform.position;
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<Renderer>().enabled = true;

        foreach (Collider2D c in player.GetComponents<Collider2D>())
        {
            c.enabled = true;
        }

    }
}
