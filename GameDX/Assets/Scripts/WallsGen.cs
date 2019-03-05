using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsGen : MonoBehaviour
{
    public GameObject mainWallTile;
    public GameObject randWallTile;

    private int fieldSizeX = 15;
    private int fieldSizeZ = 15;
    private float levelHeight = 1.0f;
    private float tileSizeX;
    private float tileSizeZ;
    private int wallsCount = 45;
    private int[,] field;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 localSize = mainWallTile.transform.localScale;
        tileSizeX = localSize.x;
        tileSizeZ = localSize.z;
        ClearField();

        GenBorder();
        GenWalls();
        ClearField();
        GenRandValues();
        GenRandWalls();
    }

    void GenBorder()
    {
        for (int i = 0; i < fieldSizeX; i++)
        {
            Instantiate(mainWallTile, new Vector3(i * tileSizeX, levelHeight, 0.0f), Quaternion.identity);
            Instantiate(mainWallTile, new Vector3(i * tileSizeX, levelHeight, tileSizeZ * (fieldSizeZ - 1)), Quaternion.identity);
        }
        for (int i = 1; i < fieldSizeZ - 1; i++)
        {
            Instantiate(mainWallTile, new Vector3(0.0f, levelHeight, i * tileSizeZ), Quaternion.identity);
            Instantiate(mainWallTile, new Vector3(tileSizeX * (fieldSizeX - 1), levelHeight, i * tileSizeZ), Quaternion.identity);
        }
    }
    void GenWalls()
    {
        for (int i = 1; i < fieldSizeX / 2; i++)
        {
            for (int j = 1; j < fieldSizeZ / 2; j++)
            {
                Instantiate(mainWallTile, new Vector3(i * 2 * tileSizeX, levelHeight, j * 2 * tileSizeZ), Quaternion.identity);
            }
        }
    }
    void ClearField()
    {
        field = new int[fieldSizeX, fieldSizeZ];
        for (int i = 0; i < fieldSizeX; i++)
        {
            for (int j = 0; j < fieldSizeZ; j++)
            {
                field[i, j] = 0;
            }
        }
        for (int i = 1; i < fieldSizeX / 2; i++)
        {
            for (int j = 1; j < fieldSizeZ / 2; j++)
            {
                field[i * 2, j * 2] = 2;
            }
        }
    }
    void GenRandValues()
    {
        int x;
        int z;
        int i = 0;
        do
        {
            x = UnityEngine.Random.Range(1, fieldSizeX - 2);
            z = UnityEngine.Random.Range(1, fieldSizeZ - 2);

            if (field[x, z] == 0)
            {
                field[x, z] = 1;
                i++;
            }


        }
        while (i != wallsCount);
    }
    void GenRandWalls()
    {
        for (int i = 1; i < field.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < field.GetLength(1) - 1; j++)
            {
                if (field[i, j] == 1)
                {
                    Instantiate(randWallTile, new Vector3(i * tileSizeX, levelHeight, j * tileSizeZ), Quaternion.identity);
                }
            }
        }
    }
    void setPlayer()
    {
        
    }


}
