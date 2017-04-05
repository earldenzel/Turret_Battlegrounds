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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if it hits anything it will be destroyed
        Destroy(gameObject);
        Instantiate(bulletExplosion, this.transform.position, this.transform.rotation); // spawn explosion at this collission
    }
}
