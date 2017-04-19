using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    //Public fields
    public float speed;
    public GameObject bulletExplosion;
    
    //Private fields
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        
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
        //if it hits anything else it will be destroyed
        Destroy(gameObject);
        Instantiate(bulletExplosion, this.transform.position, this.transform.rotation); // spawn explosion at this collision        
    }
}
