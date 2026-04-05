using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour {

    private GameObject spawnpoint;
    public int hitsToKill;
    public int maxhp;
    public AudioClip tankdeath;
    public GameObject tankExplosion;
    private GameObject player;

    // Use this for initialization
    void Start () {
        maxhp = hitsToKill;
        player = GameObject.FindGameObjectWithTag("Player");
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
                    float delay = gameObject.GetComponent<PlayerController>().PlayDialogue(0, 1, 2);
                    
                    // Wait for dialogue to finish (2 seconds), then do explosion and sound
                    StartCoroutine(DelayedExplosion(delay));
                    StartCoroutine(DeathScene(spawnpoint, delay));
                    hitsToKill = maxhp;
                }

            }
            else if (hitsToKill <= 0)
            {
                SoundManager.Play3DSound(tankdeath, this.transform.position, 1f, 10f, 1f);
                Destroy(this.gameObject);
                if (gameObject.tag != "Breakable") Instantiate(tankExplosion, this.transform.position, this.transform.rotation); // spawn explosion at this collision  
                if (gameObject.tag == "Peon" || gameObject.tag == "Homing" || gameObject.tag == "Battery"){
                    float randomValue = Random.value;
                    if (randomValue > 0.8f){
                        player.GetComponent<PlayerController>().PlayDialogue(3,4,5,6,7,8);
                    }
                }
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
    
    IEnumerator DelayedExplosion(float delay)
    {
        yield return new WaitForSeconds(delay);
        SoundManager.Play3DSound(tankdeath, this.transform.position, 1f, 10f, 1f);
        Instantiate(tankExplosion, this.transform.position, this.transform.rotation);
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator DeathScene(GameObject spawnpoint, float dialogueDelay)
    {

        foreach(Collider2D c in gameObject.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }

        //Wait for dialogue to finish plus 5 seconds before respawning
        yield return new WaitForSeconds(dialogueDelay + 5);
        gameObject.transform.position = spawnpoint.transform.position;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.GetComponent<Renderer>().enabled = true;

        foreach (Collider2D c in gameObject.GetComponents<Collider2D>())
        {
            c.enabled = true;
        }
    }
}
