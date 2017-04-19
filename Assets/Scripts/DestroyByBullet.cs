using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {

    private GameObject spawnpoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (gameObject.tag == "Player")
            {
                spawnpoint = GameObject.FindGameObjectWithTag("Active");
                StartCoroutine(DeathScene(spawnpoint));

            }
            else
            {
                Destroy(this.gameObject);
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
