using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public GameObject unbreakable_block;
    public GameObject unbreakable_triangle;

	// Use this for initialization
	void Start () {
        //programatically instantiate all unbreakable blocks. if blocks are together, that means they are connected!
        ArrayList unbreakableBlockPositions = new ArrayList();
        unbreakableBlockPositions.Add(new Vector3(0.5f, 0.5f));
        unbreakableBlockPositions.Add(new Vector3(0.5f, 1.5f));
        unbreakableBlockPositions.Add(new Vector3(0.5f, 2.5f));
        unbreakableBlockPositions.Add(new Vector3(0.5f, 3.5f));
        unbreakableBlockPositions.Add(new Vector3(0.5f, 4.5f));

        unbreakableBlockPositions.Add(new Vector3(1.5f, 5.5f));

        unbreakableBlockPositions.Add(new Vector3(2.5f, 6.5f));
        unbreakableBlockPositions.Add(new Vector3(3.5f, 6.5f));
        unbreakableBlockPositions.Add(new Vector3(4.5f, 6.5f));
        unbreakableBlockPositions.Add(new Vector3(5.5f, 6.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 6.5f));
        unbreakableBlockPositions.Add(new Vector3(7.5f, 6.5f));
        unbreakableBlockPositions.Add(new Vector3(8.5f, 6.5f));
        unbreakableBlockPositions.Add(new Vector3(8.5f, 5.5f));
        unbreakableBlockPositions.Add(new Vector3(9.5f, 5.5f));
        unbreakableBlockPositions.Add(new Vector3(9.5f, 4.5f));
        unbreakableBlockPositions.Add(new Vector3(9.5f, 3.5f));
        unbreakableBlockPositions.Add(new Vector3(9.5f, 2.5f));

        unbreakableBlockPositions.Add(new Vector3(4.5f, 0.5f));
        unbreakableBlockPositions.Add(new Vector3(4.5f, 1.5f));
        unbreakableBlockPositions.Add(new Vector3(4.5f, 2.5f));

        foreach (Vector3 position in unbreakableBlockPositions)
        {
            Instantiate(unbreakable_block, position, Quaternion.identity);
        }
        
        //triangles set at 0 degrees
        ArrayList unbreakableTriangle0 = new ArrayList();
        unbreakableTriangle0.Add(new Vector3(5.5f, 3.5f));
        unbreakableTriangle0.Add(new Vector3(5.5f, 0.5f));

        foreach (Vector3 position in unbreakableTriangle0)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.identity);
        }
        
        //triangles set at 90 degrees
        ArrayList unbreakableTriangle90 = new ArrayList();
        unbreakableTriangle90.Add(new Vector3(4.5f, 3.5f));
        unbreakableTriangle90.Add(new Vector3(0.5f, 5.5f));
        unbreakableTriangle90.Add(new Vector3(1.5f, 6.5f));
        unbreakableTriangle90.Add(new Vector3(7.5f, 7.5f));

        foreach (Vector3 position in unbreakableTriangle90)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 90));
        }

        //triangles set at 180 degrees
        ArrayList unbreakableTriangle180 = new ArrayList();
        unbreakableTriangle180.Add(new Vector3(7.5f, 5.5f));
        unbreakableTriangle180.Add(new Vector3(8.5f, 4.5f));

        foreach (Vector3 position in unbreakableTriangle180)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 180));
        }
        
        //triangles set at 270 degrees
        ArrayList unbreakableTriangle270 = new ArrayList();
        unbreakableTriangle270.Add(new Vector3(5.5f, 2.5f));
        unbreakableTriangle270.Add(new Vector3(1.5f, 4.5f));
        unbreakableTriangle270.Add(new Vector3(2.5f, 5.5f));

        foreach (Vector3 position in unbreakableTriangle270)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 270));
        }

    }
}
