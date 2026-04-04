using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    //Public fields
    public float speed;
    public GameObject bulletExplosion;
    public AudioClip explosionSound;
    public AudioClip collisionSound;
    public AudioClip breakableHitSound;
    public AudioClip unbreakableHitSound;
    public AudioClip tankHitSound;
    
    //Private fields
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;

        // Play a shoot sound
        SoundManager.Play3DSound(explosionSound, this.transform.position, 1f, 10f, 1f);

        //this code makes the bullet permeate through all water blocks!
        GameObject[] waterblocks = GameObject.FindGameObjectsWithTag("Water");
        foreach(GameObject waterblock in waterblocks)
        {
            Physics2D.IgnoreCollision(waterblock.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Water") return;

        AudioClip clipToPlay = collisionSound;
        if (other.gameObject.CompareTag("Breakable"))
        {
            clipToPlay = breakableHitSound;
        }
        else if (
            other.gameObject.CompareTag("Unbreakable") 
            || other.gameObject.CompareTag("Electricity"))
        {
            clipToPlay = unbreakableHitSound;
        }
        else if (
            other.gameObject.CompareTag("Boss") 
            || other.gameObject.CompareTag("Player") 
            || other.gameObject.CompareTag("Peon"))
        {
            clipToPlay = tankHitSound;
        }

        //if it hits anything else it will be destroyed
        Destroy(gameObject);
        Instantiate(bulletExplosion, this.transform.position, this.transform.rotation); // spawn explosion at this collision  
        SoundManager.Play3DSound(clipToPlay, transform.position, 0.5f, 10f, 1f);
    }
}
