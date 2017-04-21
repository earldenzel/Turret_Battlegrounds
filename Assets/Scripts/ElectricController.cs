using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricController : MonoBehaviour {

    public AudioClip generatordestroy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            AudioSource.PlayClipAtPoint(generatordestroy, Camera.main.transform.position);
            //this code makes all electricity disappear on Generator death
            GameObject[] electroblocks = GameObject.FindGameObjectsWithTag("Electricity");
            foreach (GameObject electroblock in electroblocks)
            {
                Destroy(electroblock);
            }
            Destroy(this.gameObject);
        }
    }
}
