using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public GameObject unbreakable_block;
    public GameObject unbreakable_triangle;
    public GameObject breakable_block;
    public GameObject stationary_turret;
    public GameObject enemy_tank;

	// Use this for initialization
	void Start () {
        //programatically instantiate all blocks. if blocks are together, that means they are connected!

        //unbreakable blocks
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
        
        unbreakableBlockPositions.Add(new Vector3(14.5f, 0.5f));
        unbreakableBlockPositions.Add(new Vector3(14.5f, 1.5f));
        unbreakableBlockPositions.Add(new Vector3(14.5f, 2.5f));
        unbreakableBlockPositions.Add(new Vector3(14.5f, 3.5f));
        unbreakableBlockPositions.Add(new Vector3(14.5f, 4.5f));
        unbreakableBlockPositions.Add(new Vector3(13.5f, 4.5f));
        unbreakableBlockPositions.Add(new Vector3(13.5f, 5.5f));
        
        unbreakableBlockPositions.Add(new Vector3(17.5f, 0.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 1.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 2.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 3.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 4.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 5.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 6.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 7.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 8.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 9.5f));
        unbreakableBlockPositions.Add(new Vector3(16.5f, 9.5f));
        unbreakableBlockPositions.Add(new Vector3(15.5f, 9.5f));
        unbreakableBlockPositions.Add(new Vector3(14.5f, 9.5f));
        unbreakableBlockPositions.Add(new Vector3(13.5f, 8.5f));
        unbreakableBlockPositions.Add(new Vector3(12.5f, 8.5f));
        unbreakableBlockPositions.Add(new Vector3(11.5f, 9.5f));
        unbreakableBlockPositions.Add(new Vector3(10.5f, 10.5f));
        unbreakableBlockPositions.Add(new Vector3(9.5f, 10.5f));
        unbreakableBlockPositions.Add(new Vector3(8.5f, 10.5f));
        unbreakableBlockPositions.Add(new Vector3(7.5f, 10.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 10.5f));
        unbreakableBlockPositions.Add(new Vector3(5.5f, 10.5f));
        unbreakableBlockPositions.Add(new Vector3(4.5f, 10.5f));
        
        unbreakableBlockPositions.Add(new Vector3(0.5f, 14.5f));
        unbreakableBlockPositions.Add(new Vector3(0.5f, 17.5f));
        unbreakableBlockPositions.Add(new Vector3(0.5f, 18.5f));
        unbreakableBlockPositions.Add(new Vector3(1.5f, 14.5f));
        unbreakableBlockPositions.Add(new Vector3(1.5f, 17.5f));
        unbreakableBlockPositions.Add(new Vector3(0.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(1.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(2.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(3.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(5.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(7.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(8.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(10.5f, 15.5f));
        unbreakableBlockPositions.Add(new Vector3(0.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(1.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(2.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(3.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(4.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(5.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(7.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(8.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(9.5f, 16.5f));
        unbreakableBlockPositions.Add(new Vector3(10.5f, 16.5f));
                
        unbreakableBlockPositions.Add(new Vector3(18.5f, 14.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 14.5f));

        unbreakableBlockPositions.Add(new Vector3(18.5f, 20.5f));
        unbreakableBlockPositions.Add(new Vector3(17.5f, 20.5f));
        unbreakableBlockPositions.Add(new Vector3(16.5f, 20.5f));
        unbreakableBlockPositions.Add(new Vector3(15.5f, 20.5f));
        unbreakableBlockPositions.Add(new Vector3(15.5f, 21.5f));
        unbreakableBlockPositions.Add(new Vector3(15.5f, 22.5f));
        unbreakableBlockPositions.Add(new Vector3(15.5f, 23.5f));
        unbreakableBlockPositions.Add(new Vector3(15.5f, 24.5f));

        unbreakableBlockPositions.Add(new Vector3(5.5f, 20.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 20.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 21.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 22.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 23.5f));
        unbreakableBlockPositions.Add(new Vector3(6.5f, 24.5f));

        foreach (Vector3 position in unbreakableBlockPositions)
        {
            Instantiate(unbreakable_block, position, Quaternion.identity);
        }
        
        //unbreakable triangles set at 0 degrees
        ArrayList unbreakableTriangle0 = new ArrayList();
        unbreakableTriangle0.Add(new Vector3(5.5f, 3.5f));
        unbreakableTriangle0.Add(new Vector3(5.5f, 0.5f));
        unbreakableTriangle0.Add(new Vector3(8.5f, 7.5f));
        unbreakableTriangle0.Add(new Vector3(9.5f, 6.5f));
        unbreakableTriangle0.Add(new Vector3(14.5f, 5.5f));
        unbreakableTriangle0.Add(new Vector3(15.5f, 0.5f));
        unbreakableTriangle0.Add(new Vector3(4.5f, 11.5f));
        unbreakableTriangle0.Add(new Vector3(10.5f, 11.5f));
        unbreakableTriangle0.Add(new Vector3(11.5f, 10.5f));
        unbreakableTriangle0.Add(new Vector3(12.5f, 9.5f));
        unbreakableTriangle0.Add(new Vector3(0.5f, 19.5f));
        unbreakableTriangle0.Add(new Vector3(1.5f, 18.5f));
        unbreakableTriangle0.Add(new Vector3(2.5f, 17.5f));

        foreach (Vector3 position in unbreakableTriangle0)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.identity);
        }
        
        //unbreakable triangles set at 90 degrees
        ArrayList unbreakableTriangle90 = new ArrayList();
        unbreakableTriangle90.Add(new Vector3(4.5f, 3.5f));
        unbreakableTriangle90.Add(new Vector3(0.5f, 5.5f));
        unbreakableTriangle90.Add(new Vector3(1.5f, 6.5f));
        unbreakableTriangle90.Add(new Vector3(7.5f, 7.5f));
        unbreakableTriangle90.Add(new Vector3(13.5f, 0.5f));
        unbreakableTriangle90.Add(new Vector3(16.5f, 0.5f));
        unbreakableTriangle90.Add(new Vector3(3.5f, 11.5f));
        unbreakableTriangle90.Add(new Vector3(9.5f, 11.5f));
        unbreakableTriangle90.Add(new Vector3(13.5f, 9.5f));
        unbreakableTriangle90.Add(new Vector3(18.5f, 10.5f));

        foreach (Vector3 position in unbreakableTriangle90)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 90));
        }

        //unbreakable triangles set at 180 degrees
        ArrayList unbreakableTriangle180 = new ArrayList();
        unbreakableTriangle180.Add(new Vector3(7.5f, 5.5f));
        unbreakableTriangle180.Add(new Vector3(8.5f, 4.5f));
        unbreakableTriangle180.Add(new Vector3(3.5f, 10.5f));
        unbreakableTriangle180.Add(new Vector3(10.5f, 9.5f));
        unbreakableTriangle180.Add(new Vector3(11.5f, 8.5f));
        unbreakableTriangle180.Add(new Vector3(16.5f, 8.5f));
        unbreakableTriangle180.Add(new Vector3(13.5f, 3.5f));
        unbreakableTriangle180.Add(new Vector3(4.5f, 20.5f));

        foreach (Vector3 position in unbreakableTriangle180)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 180));
        }
        
        //unbreakable triangles set at 270 degrees
        ArrayList unbreakableTriangle270 = new ArrayList();
        unbreakableTriangle270.Add(new Vector3(5.5f, 2.5f));
        unbreakableTriangle270.Add(new Vector3(1.5f, 4.5f));
        unbreakableTriangle270.Add(new Vector3(2.5f, 5.5f));
        unbreakableTriangle270.Add(new Vector3(14.5f, 8.5f));
        unbreakableTriangle270.Add(new Vector3(2.5f, 14.5f));
        unbreakableTriangle270.Add(new Vector3(18.5f, 9.5f));

        foreach (Vector3 position in unbreakableTriangle270)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 270));
        }

        //breakable bricks
        ArrayList breakableBricks = new ArrayList();
        breakableBricks.Add(new Vector3(9.25f, 0.25f));
        breakableBricks.Add(new Vector3(9.25f, 0.75f));
        breakableBricks.Add(new Vector3(9.75f, 0.25f));
        breakableBricks.Add(new Vector3(9.75f, 0.75f));
        breakableBricks.Add(new Vector3(9.25f, 1.25f));
        breakableBricks.Add(new Vector3(9.25f, 1.75f));
        breakableBricks.Add(new Vector3(9.75f, 1.25f));
        breakableBricks.Add(new Vector3(9.75f, 1.75f));

        breakableBricks.Add(new Vector3(10.25f, 5.25f));
        breakableBricks.Add(new Vector3(10.25f, 5.75f));
        breakableBricks.Add(new Vector3(10.75f, 5.25f));
        breakableBricks.Add(new Vector3(10.75f, 5.75f));
        breakableBricks.Add(new Vector3(11.25f, 5.25f));
        breakableBricks.Add(new Vector3(11.25f, 5.75f));
        breakableBricks.Add(new Vector3(11.75f, 5.25f));
        breakableBricks.Add(new Vector3(11.75f, 5.75f));
        breakableBricks.Add(new Vector3(12.25f, 5.25f));
        breakableBricks.Add(new Vector3(12.25f, 5.75f));
        breakableBricks.Add(new Vector3(12.75f, 5.25f));
        breakableBricks.Add(new Vector3(12.75f, 5.75f));
        
        breakableBricks.Add(new Vector3(13.25f, 6.25f));
        breakableBricks.Add(new Vector3(13.25f, 6.75f));
        breakableBricks.Add(new Vector3(13.75f, 6.25f));
        breakableBricks.Add(new Vector3(13.75f, 6.75f));
        breakableBricks.Add(new Vector3(13.25f, 7.25f));
        breakableBricks.Add(new Vector3(13.25f, 7.75f));
        breakableBricks.Add(new Vector3(13.75f, 7.25f));
        breakableBricks.Add(new Vector3(13.75f, 7.75f));

        breakableBricks.Add(new Vector3(15.25f, 4.25f));
        breakableBricks.Add(new Vector3(15.25f, 4.75f));
        breakableBricks.Add(new Vector3(15.75f, 4.25f));
        breakableBricks.Add(new Vector3(15.75f, 4.75f));
        breakableBricks.Add(new Vector3(16.25f, 4.25f));
        breakableBricks.Add(new Vector3(16.25f, 4.75f));
        breakableBricks.Add(new Vector3(16.75f, 4.25f));
        breakableBricks.Add(new Vector3(16.75f, 4.75f));
        
        breakableBricks.Add(new Vector3(0.25f, 11.25f));
        breakableBricks.Add(new Vector3(0.25f, 11.75f));
        breakableBricks.Add(new Vector3(0.75f, 11.25f));
        breakableBricks.Add(new Vector3(0.75f, 11.75f));
        breakableBricks.Add(new Vector3(0.25f, 12.25f));
        breakableBricks.Add(new Vector3(0.25f, 12.75f));
        breakableBricks.Add(new Vector3(0.75f, 12.25f));
        breakableBricks.Add(new Vector3(0.75f, 12.75f));
        breakableBricks.Add(new Vector3(1.25f, 11.25f));
        breakableBricks.Add(new Vector3(1.25f, 11.75f));
        breakableBricks.Add(new Vector3(1.75f, 11.25f));
        breakableBricks.Add(new Vector3(1.75f, 11.75f));
        breakableBricks.Add(new Vector3(1.25f, 12.25f));
        breakableBricks.Add(new Vector3(1.25f, 12.75f));
        breakableBricks.Add(new Vector3(1.75f, 12.25f));
        breakableBricks.Add(new Vector3(1.75f, 12.75f));
        breakableBricks.Add(new Vector3(1.25f, 13.25f));
        breakableBricks.Add(new Vector3(1.25f, 13.75f));
        breakableBricks.Add(new Vector3(1.75f, 13.25f));
        breakableBricks.Add(new Vector3(1.75f, 13.75f));
        breakableBricks.Add(new Vector3(2.25f, 12.25f));
        breakableBricks.Add(new Vector3(2.25f, 12.75f));
        breakableBricks.Add(new Vector3(2.75f, 12.25f));
        breakableBricks.Add(new Vector3(2.75f, 12.75f));
        breakableBricks.Add(new Vector3(2.25f, 13.25f));
        breakableBricks.Add(new Vector3(2.25f, 13.75f));
        breakableBricks.Add(new Vector3(2.75f, 13.25f));
        breakableBricks.Add(new Vector3(2.75f, 13.75f));


        breakableBricks.Add(new Vector3(11.25f, 13.25f));
        breakableBricks.Add(new Vector3(11.25f, 13.75f));
        breakableBricks.Add(new Vector3(11.75f, 13.25f));
        breakableBricks.Add(new Vector3(11.75f, 13.75f));
        breakableBricks.Add(new Vector3(11.25f, 14.25f));
        breakableBricks.Add(new Vector3(11.25f, 14.75f));
        breakableBricks.Add(new Vector3(11.75f, 14.25f));
        breakableBricks.Add(new Vector3(11.75f, 14.75f));
        breakableBricks.Add(new Vector3(11.25f, 15.25f));
        breakableBricks.Add(new Vector3(11.25f, 15.75f));
        breakableBricks.Add(new Vector3(11.75f, 15.25f));
        breakableBricks.Add(new Vector3(11.75f, 15.75f));
        breakableBricks.Add(new Vector3(11.25f, 16.25f));
        breakableBricks.Add(new Vector3(11.25f, 16.75f));
        breakableBricks.Add(new Vector3(11.75f, 16.25f));
        breakableBricks.Add(new Vector3(11.75f, 16.75f));
        breakableBricks.Add(new Vector3(11.25f, 17.25f));
        breakableBricks.Add(new Vector3(11.25f, 17.75f));
        breakableBricks.Add(new Vector3(11.75f, 17.25f));
        breakableBricks.Add(new Vector3(11.75f, 17.75f));
        breakableBricks.Add(new Vector3(12.25f, 15.25f));
        breakableBricks.Add(new Vector3(12.25f, 15.75f));
        breakableBricks.Add(new Vector3(12.75f, 15.25f));
        breakableBricks.Add(new Vector3(12.75f, 15.75f));
        breakableBricks.Add(new Vector3(13.25f, 14.25f));
        breakableBricks.Add(new Vector3(13.25f, 14.75f));
        breakableBricks.Add(new Vector3(13.75f, 14.25f));
        breakableBricks.Add(new Vector3(13.75f, 14.75f));
        breakableBricks.Add(new Vector3(13.25f, 15.25f));
        breakableBricks.Add(new Vector3(13.25f, 15.75f));
        breakableBricks.Add(new Vector3(13.75f, 15.25f));
        breakableBricks.Add(new Vector3(13.75f, 15.75f));
        breakableBricks.Add(new Vector3(13.25f, 16.25f));
        breakableBricks.Add(new Vector3(13.25f, 16.75f));
        breakableBricks.Add(new Vector3(13.75f, 16.25f));
        breakableBricks.Add(new Vector3(13.75f, 16.75f));
        breakableBricks.Add(new Vector3(13.25f, 17.25f));
        breakableBricks.Add(new Vector3(13.25f, 17.75f));
        breakableBricks.Add(new Vector3(13.75f, 17.25f));
        breakableBricks.Add(new Vector3(13.75f, 17.75f));
        
        breakableBricks.Add(new Vector3(15.25f, 12.25f));
        breakableBricks.Add(new Vector3(15.25f, 12.75f));
        breakableBricks.Add(new Vector3(15.75f, 12.25f));
        breakableBricks.Add(new Vector3(15.75f, 12.75f));
        breakableBricks.Add(new Vector3(15.25f, 13.25f));
        breakableBricks.Add(new Vector3(15.25f, 13.75f));
        breakableBricks.Add(new Vector3(15.75f, 13.25f));
        breakableBricks.Add(new Vector3(15.75f, 13.75f));

        breakableBricks.Add(new Vector3(15.25f, 15.25f));
        breakableBricks.Add(new Vector3(15.25f, 15.75f));
        breakableBricks.Add(new Vector3(15.75f, 15.25f));
        breakableBricks.Add(new Vector3(15.75f, 15.75f));
        breakableBricks.Add(new Vector3(15.25f, 16.25f));
        breakableBricks.Add(new Vector3(15.25f, 16.75f));
        breakableBricks.Add(new Vector3(15.75f, 16.25f));
        breakableBricks.Add(new Vector3(15.75f, 16.75f));
        breakableBricks.Add(new Vector3(15.25f, 17.25f));
        breakableBricks.Add(new Vector3(15.25f, 17.75f));
        breakableBricks.Add(new Vector3(15.75f, 17.25f));
        breakableBricks.Add(new Vector3(15.75f, 17.75f));
        breakableBricks.Add(new Vector3(16.25f, 15.25f));
        breakableBricks.Add(new Vector3(16.25f, 15.75f));
        breakableBricks.Add(new Vector3(16.75f, 15.25f));
        breakableBricks.Add(new Vector3(16.75f, 15.75f));
        breakableBricks.Add(new Vector3(17.25f, 15.25f));
        breakableBricks.Add(new Vector3(17.25f, 15.75f));
        breakableBricks.Add(new Vector3(17.75f, 15.25f));
        breakableBricks.Add(new Vector3(17.75f, 15.75f));
        breakableBricks.Add(new Vector3(17.25f, 16.25f));
        breakableBricks.Add(new Vector3(17.25f, 16.75f));
        breakableBricks.Add(new Vector3(17.75f, 16.25f));
        breakableBricks.Add(new Vector3(17.75f, 16.75f));
        
        breakableBricks.Add(new Vector3(11.25f, 11.25f));
        breakableBricks.Add(new Vector3(11.25f, 11.75f));
        breakableBricks.Add(new Vector3(11.75f, 11.25f));
        breakableBricks.Add(new Vector3(11.75f, 11.75f));
        breakableBricks.Add(new Vector3(12.25f, 11.25f));
        breakableBricks.Add(new Vector3(12.25f, 11.75f));
        breakableBricks.Add(new Vector3(12.75f, 11.25f));
        breakableBricks.Add(new Vector3(12.75f, 11.75f));
        breakableBricks.Add(new Vector3(13.25f, 11.25f));
        breakableBricks.Add(new Vector3(13.25f, 11.75f));
        breakableBricks.Add(new Vector3(13.75f, 11.25f));
        breakableBricks.Add(new Vector3(13.75f, 11.75f));
        
        breakableBricks.Add(new Vector3(7.25f, 21.25f));
        breakableBricks.Add(new Vector3(7.25f, 21.75f));
        breakableBricks.Add(new Vector3(7.75f, 21.25f));
        breakableBricks.Add(new Vector3(7.75f, 21.75f));
        breakableBricks.Add(new Vector3(8.25f, 21.25f));
        breakableBricks.Add(new Vector3(8.25f, 21.75f));
        breakableBricks.Add(new Vector3(8.75f, 21.25f));
        breakableBricks.Add(new Vector3(8.75f, 21.75f));
        breakableBricks.Add(new Vector3(9.25f, 21.25f));
        breakableBricks.Add(new Vector3(9.25f, 21.75f));
        breakableBricks.Add(new Vector3(9.75f, 21.25f));
        breakableBricks.Add(new Vector3(9.75f, 21.75f));
        breakableBricks.Add(new Vector3(10.25f, 21.25f));
        breakableBricks.Add(new Vector3(10.25f, 21.75f));
        breakableBricks.Add(new Vector3(10.75f, 21.25f));
        breakableBricks.Add(new Vector3(10.75f, 21.75f));
        breakableBricks.Add(new Vector3(10.25f, 22.25f));
        breakableBricks.Add(new Vector3(10.25f, 22.75f));
        breakableBricks.Add(new Vector3(10.75f, 22.25f));
        breakableBricks.Add(new Vector3(10.75f, 22.75f));
        breakableBricks.Add(new Vector3(10.25f, 23.25f));
        breakableBricks.Add(new Vector3(10.25f, 23.75f));
        breakableBricks.Add(new Vector3(10.75f, 23.25f));
        breakableBricks.Add(new Vector3(10.75f, 23.75f));
        breakableBricks.Add(new Vector3(10.25f, 24.25f));
        breakableBricks.Add(new Vector3(10.25f, 24.75f));
        breakableBricks.Add(new Vector3(10.75f, 24.25f));
        breakableBricks.Add(new Vector3(10.75f, 24.75f));

        foreach (Vector3 position in breakableBricks)
        {
            Instantiate(breakable_block, position, Quaternion.identity);
        }
        
        //Enemies
        Instantiate(stationary_turret, new Vector3(15.5f, 7.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(stationary_turret, new Vector3(4.5f, 15.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(stationary_turret, new Vector3(9.5f, 15.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(stationary_turret, new Vector3(9.5f, 18.5f), Quaternion.Euler(0, 0, 225));
        Instantiate(stationary_turret, new Vector3(9.5f, 19.5f), Quaternion.Euler(0, 0, 270));
        Instantiate(stationary_turret, new Vector3(9.5f, 20.5f), Quaternion.Euler(0, 0, 315));
        Instantiate(stationary_turret, new Vector3(14.5f, 24.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(enemy_tank, new Vector3(5.5f, 8.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(enemy_tank, new Vector3(8.5f, 23.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(enemy_tank, new Vector3(7.5f, 12.5f), Quaternion.Euler(0, 0, 90));
    }
}
