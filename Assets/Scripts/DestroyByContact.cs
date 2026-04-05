using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    private GameObject spawnpoint;
    private GameObject player;
    public GameObject tankExplosion;
    public AudioClip tankdeath;

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
            float delay = collision.gameObject.GetComponent<PlayerController>().PlayDialogue(0, 1, 2);
            
            // Wait for dialogue to finish, then do explosion and sound
            StartCoroutine(DelayedExplosion(delay, collision.transform));
            StartCoroutine(DeathScene(spawnpoint, delay));
            player.GetComponent<DestroyByBullet>().hitsToKill = player.GetComponent<DestroyByBullet>().maxhp;
        }
    }

    IEnumerator DelayedExplosion(float delay, Transform playerTransform)
    {
        yield return new WaitForSeconds(delay);
        SoundManager.Play3DSound(tankdeath, playerTransform.position, 1f, 10f, 1f);
        Instantiate(tankExplosion, playerTransform.position, playerTransform.rotation);
        player.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator DeathScene(GameObject spawnpoint, float dialogueDelay)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        foreach (Collider2D c in player.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }

        //Wait for dialogue to finish plus 5 seconds before respawning
        yield return new WaitForSeconds(dialogueDelay + 5);
        player.transform.position = spawnpoint.transform.position;
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<Renderer>().enabled = true;

        foreach (Collider2D c in player.GetComponents<Collider2D>())
        {
            c.enabled = true;
        }

    }
}
