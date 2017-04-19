using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricController : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
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
