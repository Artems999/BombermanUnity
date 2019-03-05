using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGen : MonoBehaviour
{
    public GameObject tile;

    private int floorSizeX = 15;
    private int floorSizeZ = 15;
    private float levelHeight = 0.0f;
    private float tileSizeX;
    private float tileSizeZ;

          
    // Start is called before the first frame update
    void Start()
    {
        Vector3 localSize = tile.transform.localScale;
        tileSizeX = localSize.x;
        tileSizeZ = localSize.z;
        GenFloor();

    }

    void GenFloor()
    {
        for (int i = 0; i < floorSizeX; i++)
        {
            for (int j = 0; j < floorSizeZ; j++)
            {
                Instantiate(tile, new Vector3(i * tileSizeX, levelHeight, j * tileSizeZ), Quaternion.identity);
            }
        }
    }
}
