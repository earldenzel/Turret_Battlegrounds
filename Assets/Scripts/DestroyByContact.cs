using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    private GameObject spawnpoint;
    private GameObject player;
    public GameObject tankExplosion;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spawnpoint = GameObject.FindGameObjectWithTag("Active");
            Instantiate(tankExplosion, collision.transform.position, collision.transform.rotation); // spawn explosion at this collision  
            StartCoroutine(DeathScene(spawnpoint));
            player.GetComponent<DestroyByBullet>().hitsToKill = player.GetComponent<DestroyByBullet>().maxhp;
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
