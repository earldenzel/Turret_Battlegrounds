using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public GameObject unbreakable_block;
    public GameObject unbreakable_triangle;
    public GameObject breakable_block;
    public GameObject stationary_turret;
    public GameObject enemy_tank;
    public GameObject spawnpoint;
    public GameObject waterblock;
    public GameObject enemy_spawner;
    public GameObject homing_turret;
    public GameObject ice_floor;
    public GameObject mud_floor;
    public GameObject lavablock;

    // Use this for initialization
    void Start () {

        //programatically instantiate all blocks
        ArrayList unbreakableBlockPositions = new ArrayList();
        ArrayList unbreakableTriangle0 = new ArrayList();
        ArrayList unbreakableTriangle90 = new ArrayList();
        ArrayList unbreakableTriangle180 = new ArrayList();
        ArrayList unbreakableTriangle270 = new ArrayList();
        ArrayList breakableBricks = new ArrayList();
        int[][] spawner = new int[85][];
        
        //Page 1
        spawner[0]  = new int[] { 1, 0, 0, 0, 1, 3, 0, 0, 0, 2, 0, 0, 0, 4, 1, 3, 4, 1, 1 };
        spawner[1]  = new int[] { 1, 0, 7, 0, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 1, 8, 0, 1, 1 };
        spawner[2]  = new int[] { 1, 0, 0, 0, 1, 6, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1 };
        spawner[3]  = new int[] { 1, 0, 0, 0, 4, 3, 0, 0, 0, 1, 0, 0, 0, 5, 1, 0, 0, 1, 1 };
        spawner[4]  = new int[] { 1, 6, 0, 0, 0, 0, 0, 0, 5, 1, 0, 0, 0, 1, 1, 2, 2, 1, 1 };
        spawner[5]  = new int[] { 4, 1, 6, 0, 0, 0, 0, 5, 1, 1, 2, 2, 2, 1, 3, 0, 0, 1, 1 };
        spawner[6]  = new int[] { 0, 4, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0, 0, 2, 0, 0, 0, 1, 1 };
        spawner[7]  = new int[] { 0, 0, 0, 0, 0, 0, 0, 4, 3, 0, 0, 0, 0, 2, 0, 0, 0, 1, 1 };
        spawner[8]  = new int[] { 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 1, 6, 0, 5, 1, 1 };
        spawner[9]  = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 3, 4, 1, 1, 1, 1, 1 };
        spawner[10] = new int[] { 0, 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0, 0, 0, 0, 0, 4 };
        spawner[11] = new int[] { 2, 2, 0, 4, 3, 0, 0, 0, 0, 4, 3, 2, 2, 2, 0, 0, 0, 0, 0 };
        spawner[12] = new int[] { 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 7, 0 };
        spawner[13] = new int[] { 8, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0 };
        spawner[14] = new int[] { 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 1, 1 };
        spawner[15] = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 2, 2, 2, 0, 2, 2, 2, 0 };
        spawner[16] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 0, 2, 0, 2, 0, 2, 0 };
        spawner[17] = new int[] { 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, 9, 2, 0, 2, 0, 2, 0, 0, 0 };
        spawner[18] = new int[] { 1, 3, 0, 0, 0, 0, 0, 7, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[19] = new int[] { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[20] = new int[] { 0, 0, 0, 0, 5, 1, 1, 0, 0, 0, 9, 0, 0, 0, 0, 1, 1, 1, 1 };
        spawner[21] = new int[] { 0, 0, 0, 0, 0, 8, 1, 2, 2, 2, 2, 0, 0, 0, 0, 1, 0, 0, 0 };
        spawner[22] = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, 8, 0 };
        spawner[23] = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0 };
        spawner[24] = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0 };

        //page 2
        spawner[25] = new int[] { 0, 0, 0, 0, 0, 0, 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  2,  2 };
        spawner[26] = new int[] { 0, 0, 0, 0, 0, 0, 1,  0,  0,  0,  0,  1, 10, 10, 10, 10,  2,  2,  2 };
        spawner[27] = new int[] { 0, 2, 0, 0, 2, 0, 1,  0,  0,  0,  0,  1, 10, 10, 10, 10, 10,  2,  2 };
        spawner[28] = new int[] { 0, 2, 0, 0, 2, 0, 1, 10, 10, 10,  5,  1,  6, 10, 10, 10, 10, 10, 10 };
        spawner[29] = new int[] { 0, 0, 0, 0, 0, 0, 1, 10, 10, 10,  1,  1,  1, 10, 10,  5, 10, 10, 10 };
        spawner[30] = new int[] { 0, 2, 0, 0, 2, 0, 1, 10, 10, 10,  4,  0,  3, 10, 10,  1,  0,  0,  0 };
        spawner[31] = new int[] { 0, 2, 0, 0, 2, 0, 1, 10, 10, 10, 10, 10, 10, 10, 10,  1,  0,  7,  0 };
        spawner[32] = new int[] { 0, 0, 0, 0, 0, 0, 1,  6, 10, 10, 10, 10, 10, 10,  5,  3,  0,  0,  0 };
        spawner[33] = new int[] { 0, 0, 0, 0, 0, 5, 1,  1,  1,  1,  1,  1,  1,  1,  3,  2,  2,  2,  2 };
        spawner[34] = new int[] { 0, 0, 0, 0, 5, 1, 3,  0,  0,  0,  0,  4,  1,  0, 10, 10, 10, 10, 10 };
        spawner[35] = new int[] { 0, 0, 0, 0, 1, 3, 0,  0,  0,  0,  0,  0,  1,  2,  2,  2,  2,  2,  2 };
        spawner[36] = new int[] { 0, 0, 0, 1, 3, 0, 0,  0,  9,  1,  1,  2,  1, 10, 10, 10, 10, 10, 10 };
        spawner[37] = new int[] { 0, 7, 0, 1, 0, 0, 0,  9,  9,  1,  0,  0,  1,  2,  2,  2,  2,  2,  2 };
        spawner[38] = new int[] { 0, 0, 0, 1, 0, 0, 9,  9,  8,  1,  0,  1,  3, 10, 10, 10, 10, 10, 10 };
        spawner[39] = new int[] { 0, 0, 0, 0, 0, 0, 9,  0,  0,  0,  0,  1, 10, 10, 10, 10, 10,  5,  1 };
        spawner[40] = new int[] { 0, 0, 0, 0, 0, 0, 9,  0,  0,  0,  0,  1, 10, 10, 10, 10,  5,  1,  1 };
        spawner[41] = new int[] { 0, 0, 0, 0, 0, 0, 9,  0,  0,  0,  0,  1, 10, 10, 10,  1,  3,  0,  0 };
        spawner[42] = new int[] { 0, 0, 0, 0, 0, 0, 0,  0,  0,  0,  0,  1, 10, 10, 10,  2,  2,  0,  8 };
        spawner[43] = new int[] { 1, 2, 2, 2, 2, 0, 0,  0,  0,  0,  0,  1, 10, 10, 10,  2,  2,  0,  0 };
        spawner[44] = new int[] { 0, 0, 0, 0, 0, 0, 1,  1,  1,  1,  1,  3, 10, 10, 10,  2,  2,  0,  0 };
        spawner[45] = new int[] { 1, 0, 0, 0, 0, 5, 1, 12, 12, 12, 10, 10, 10, 10, 12,  1,  1,  1,  0 };
        spawner[46] = new int[] { 0, 0, 0, 0, 0, 1, 0, 12, 10, 10, 10, 10, 10, 10, 12,  1,  0,  4,  1 };
        spawner[47] = new int[] { 0, 0, 0, 0, 0, 1, 1, 10, 10, 10, 10, 10, 10, 10, 12,  0,  8,  0,  0 };
        spawner[48] = new int[] { 0, 0, 0, 0, 0, 0, 1,  0,  0,  0,  0,  0, 12, 12, 12,  0,  0,  0,  0 };
        spawner[49] = new int[] { 0, 0, 0, 0, 5, 1, 1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1 };

        //page 3                                   
        spawner[50] = new int[] {  1,  1,  1,  1,  1,  1,  3,  0,  0, 0, 1, 2, 2, 0, 0, 0, 0, 9, 0 };
        spawner[51] = new int[] {  1,  0,  0,  0,  0,  0,  0,  0,  7, 0, 1, 2, 2, 0, 0, 0, 0, 9, 9 };
        spawner[52] = new int[] {  2,  0,  0,  2,  2,  0,  2,  0,  0, 0, 1, 8, 0, 0, 0, 0, 0, 0, 0 };
        spawner[53] = new int[] {  2,  0,  0,  2,  2,  0,  2,  2,  0, 5, 1, 2, 2, 0, 0, 0, 2, 2, 0 };
        spawner[54] = new int[] {  1,  6,  0,  0,  0,  0,  0,  0,  0, 1, 3, 2, 2, 0, 0, 0, 2, 2, 0 };
        spawner[55] = new int[] {  1,  0,  0,  0,  0,  0,  0,  0,  5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[56] = new int[] {  1,  3,  0,  2,  2,  0,  0,  5,  3, 0, 0, 2, 2, 0, 0, 0, 1, 0, 0 };
        spawner[57] = new int[] {  0,  0,  0,  2,  2,  0,  5,  3,  0, 7, 0, 2, 2, 0, 0, 0, 1, 0, 0 };
        spawner[58] = new int[] {  0,  0,  0,  0,  0,  9,  9,  0,  0, 0, 0, 1, 9, 9, 9, 9, 9, 0, 0 };
        spawner[59] = new int[] {  0,  0,  0,  0,  9,  9, 11, 11, 11, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 };
        spawner[60] = new int[] { 11, 11, 11, 11,  9, 11, 11, 11, 11, 1, 0, 0, 0, 0, 0, 0, 7, 0, 0 };
        spawner[61] = new int[] { 11, 11, 11, 11,  9, 11, 11, 11, 11, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[62] = new int[] { 11, 11, 11, 11,  9, 11, 11, 11, 11, 1, 0, 0, 0, 5, 1, 1, 1, 1, 1 };
        spawner[63] = new int[] { 11, 11, 11, 11, 11, 11, 11, 11, 11, 1, 2, 2, 2, 0, 0, 0, 0, 0, 0 };
        spawner[64] = new int[] { 11, 11, 11, 11, 11, 11, 11, 11, 11, 1, 2, 2, 2, 0, 0, 0, 0, 0, 8 };
        spawner[65] = new int[] { 11, 11, 11, 11,  2,  2,  2, 11,  5, 3, 0, 0, 0, 4, 1, 0, 0, 0, 1 };
        spawner[66] = new int[] {  1,  0,  1,  1,  1,  8,  1,  0,  1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
        spawner[67] = new int[] {  4,  1,  1,  1,  1,  1,  1,  1,  1, 0, 0, 0, 0, 0, 1, 0, 8, 0, 1 };
        spawner[68] = new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 };
        spawner[69] = new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 };
        spawner[70] = new int[] {  0,  0,  0,  0,  0,  1,  1,  1,  1, 1, 1, 1, 1, 1, 3, 2, 2, 2, 4 };
        spawner[71] = new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 };
        spawner[72] = new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  2, 0, 0, 7, 0, 0, 2, 0, 0, 0, 0 };
        spawner[73] = new int[] {  0,  0,  8,  0,  0,  0,  0,  0,  2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 };
        spawner[74] = new int[] {  0,  0,  8,  0,  0,  0,  0,  0,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        //page 4
        spawner[75] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0 };
        spawner[76] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[77] = new int[] { 1, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[78] = new int[] { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
        spawner[79] = new int[] { 1, 0, 8, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[80] = new int[] { 3, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[81] = new int[] { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
        spawner[82] = new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[83] = new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        spawner[84] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0 };
        
        //0 - nothing           //1 - unbreakable block     //2 - breakable
        //3 - triangle 0        //4 - triangle 90           //5 - triangle 180
        //6 - triangle 270      //7 - spawnpoint            //8 - powerup
        //9 water               //10 ice                    //11 ground
        //12 void               //enemies and turrets are not in spawner!!

        for (int i = 0; i < 85; i++)
        {
            unbreakableBlockPositions.Add(new Vector3(-0.5f, i + 0.5f));
            unbreakableBlockPositions.Add(new Vector3(19.5f, i + 0.5f));

            for (int j = 0; j<19; j++)
            {
                unbreakableBlockPositions.Add(new Vector3(j + 0.5f, -0.5f));
                unbreakableBlockPositions.Add(new Vector3(j + 0.5f, 85.5f));

                switch (spawner[i][j])
                {
                    case 1: //unbreakable
                        unbreakableBlockPositions.Add(new Vector3 (j+0.5f, i+0.5f));
                        break;
                    case 2: //breakable
                        breakableBricks.Add(new Vector3(j + 0.25f, i + 0.25f));
                        breakableBricks.Add(new Vector3(j + 0.75f, i + 0.25f));
                        breakableBricks.Add(new Vector3(j + 0.25f, i + 0.75f));
                        breakableBricks.Add(new Vector3(j + 0.75f, i + 0.75f));
                        break;
                    case 3:
                        unbreakableTriangle0.Add(new Vector3(j + 0.5f, i + 0.5f));
                        break;
                    case 4:
                        unbreakableTriangle90.Add(new Vector3(j + 0.5f, i + 0.5f));
                        break;
                    case 5:
                        unbreakableTriangle180.Add(new Vector3(j + 0.5f, i + 0.5f));
                        break;
                    case 6:
                        unbreakableTriangle270.Add(new Vector3(j + 0.5f, i + 0.5f));
                        break;
                    case 7:
                        Instantiate(spawnpoint, new Vector3(j + 0.5f, i + 0.5f), Quaternion.identity);
                        break;
                    case 9:
                        Instantiate(waterblock, new Vector3(j + 0.5f, i + 0.5f), Quaternion.identity);
                        break;
                    case 10:
                        Instantiate(ice_floor, new Vector3(j + 0.5f, i + 0.5f), Quaternion.identity);
                        break;
                    case 11:
                        Instantiate(mud_floor, new Vector3(j + 0.5f, i + 0.5f), Quaternion.identity);
                        break;
                    case 12:
                        Instantiate(lavablock, new Vector3(j + 0.5f, i + 0.5f), Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
        
        foreach (Vector3 position in unbreakableBlockPositions)
        {
            Instantiate(unbreakable_block, position, Quaternion.identity);
        }

        foreach (Vector3 position in breakableBricks)
        {
            Instantiate(breakable_block, position, Quaternion.identity);
        }

        foreach (Vector3 position in unbreakableTriangle0)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.identity);
        }

        foreach (Vector3 position in unbreakableTriangle90)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 90));
        }
        foreach (Vector3 position in unbreakableTriangle180)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 180));
        }
        foreach (Vector3 position in unbreakableTriangle270)
        {
            Instantiate(unbreakable_triangle, position, Quaternion.Euler(0, 0, 270));
        }

        //Enemies
        Instantiate(stationary_turret, new Vector3(15.5f, 7.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(stationary_turret, new Vector3(4.5f, 15.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(stationary_turret, new Vector3(9.5f, 15.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(stationary_turret, new Vector3(9.5f, 18.5f), Quaternion.Euler(0, 0, 225));
        Instantiate(stationary_turret, new Vector3(9.5f, 19.5f), Quaternion.Euler(0, 0, 270));
        Instantiate(stationary_turret, new Vector3(9.5f, 20.5f), Quaternion.Euler(0, 0, 315));
        Instantiate(stationary_turret, new Vector3(14.5f, 24.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(stationary_turret, new Vector3(9.5f, 40.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(stationary_turret, new Vector3(8.5f, 41.5f), Quaternion.Euler(0, 0, 135));
        Instantiate(stationary_turret, new Vector3(4.5f, 29.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(stationary_turret, new Vector3(1.5f, 29.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(stationary_turret, new Vector3(4.5f, 32.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(stationary_turret, new Vector3(1.5f, 32.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(stationary_turret, new Vector3(0.5f, 44.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(stationary_turret, new Vector3(5.5f, 48.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(stationary_turret, new Vector3(11.5f, 30.5f), Quaternion.Euler(0, 0, 0));
        Instantiate(stationary_turret, new Vector3(12.5f, 26.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(stationary_turret, new Vector3(12.5f, 27.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(stationary_turret, new Vector3(13.5f, 34.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(stationary_turret, new Vector3(18.5f, 38.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(stationary_turret, new Vector3(18.5f, 45.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(stationary_turret, new Vector3(6.5f, 46.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(stationary_turret, new Vector3(1.5f, 55.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(stationary_turret, new Vector3(1.5f, 66.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(stationary_turret, new Vector3(7.5f, 60.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(stationary_turret, new Vector3(13.5f, 59.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(stationary_turret, new Vector3(15.5f, 59.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(enemy_tank, new Vector3(5.5f, 8.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(enemy_tank, new Vector3(8.5f, 23.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(enemy_tank, new Vector3(7.5f, 12.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(enemy_tank, new Vector3(1.5f, 23.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(enemy_tank, new Vector3(4.5f, 23.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(enemy_tank, new Vector3(9.5f, 35.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(enemy_tank, new Vector3(3.5f, 46.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(enemy_tank, new Vector3(17.5f, 30.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(enemy_tank, new Vector3(5.5f, 54.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(enemy_tank, new Vector3(1.5f, 58.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(enemy_tank, new Vector3(18.5f, 58.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(enemy_tank, new Vector3(7.5f, 69.5f), Quaternion.Euler(0, 0, -90));
        Instantiate(homing_turret, new Vector3(3.5f, 35.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(homing_turret, new Vector3(7.5f, 42.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(homing_turret, new Vector3(13.5f, 36.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(homing_turret, new Vector3(18.5f, 40.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(homing_turret, new Vector3(1.5f, 52.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(homing_turret, new Vector3(6.5f, 59.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(homing_turret, new Vector3(18.5f, 50.5f), Quaternion.Euler(0, 0, 90));
        Instantiate(homing_turret, new Vector3(14.5f, 59.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(homing_turret, new Vector3(7.5f, 74.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(homing_turret, new Vector3(8.5f, 83.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(homing_turret, new Vector3(18.5f, 83.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(homing_turret, new Vector3(18.5f, 76.5f), Quaternion.Euler(0, 0, 180));
        Instantiate(homing_turret, new Vector3(7.5f, 66.5f), Quaternion.Euler(0, 0, 180));

        //Enemy Spawners
        Instantiate(enemy_spawner, new Vector3(17.5f, 18.5f), Quaternion.identity);
        Instantiate(enemy_spawner, new Vector3(14.5f, 51.5f), Quaternion.identity);
        Instantiate(enemy_spawner, new Vector3(16.5f, 64.5f), Quaternion.identity);
        Instantiate(enemy_spawner, new Vector3(16.5f, 72.5f), Quaternion.identity);
    }
}
