using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class WallsGen : MonoBehaviour
{
    public GameObject mainWallTile;
    public GameObject randWallTile;
    public GameObject playerPrefab;

    private GameSet gs = GameSet.Default;
    private float levelHeight = 1.0f;
    private int wallsCount = 35;
    private int[,] field;


    void Start()
    {
        ClearField();
        GenField();
        GenRandValues();
        GenWalls();
    }

    void ClearField()
    {
        field = new int[gs.FieldSizeX, gs.FieldSizeZ];
        for (int i = 0; i < gs.FieldSizeX; i++)
        {
            for (int j = 0; j < gs.FieldSizeZ; j++)
            {
                field[i, j] = 0;
            }
        }
    }

    void GenField()
    {
        for (int i = 0; i < gs.FieldSizeX; i++)
        {
            for (int j = 0; j < gs.FieldSizeZ; j++)
            {
                if (i == 0 || i == gs.FieldSizeX - 1 || j == 0 || j == gs.FieldSizeZ - 1)
                {
                    field[i, j] = 1;
                }
                else if (i % 2 == 0 && j % 2 == 0)
                {
                    field[i, j] = 1;
                }

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
            x = UnityEngine.Random.Range(1, gs.FieldSizeX - 2);
            z = UnityEngine.Random.Range(1, gs.FieldSizeZ - 2);

            if (field[x, z] == 0)
            {
                if (i == wallsCount)
                {
                    field[x, z] = 9;
                }
                else
                {
                    field[x, z] = 2;
                }

                i++;
            }




        } while (i <= wallsCount);
    }

    void GenWalls()
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == 1)
                {
                    Instantiate(mainWallTile, new Vector3(i * gs.TileSizeX, levelHeight, j * gs.TileSizeZ),
                        Quaternion.identity);
                }
                else if (field[i, j] == 2)
                {
                    Instantiate(randWallTile, new Vector3(i * gs.TileSizeX, levelHeight, j * gs.TileSizeZ),
                        Quaternion.identity);
                }
                else if (field[i, j] == 9)
                {
                    Instantiate(playerPrefab, new Vector3(i * gs.TileSizeX, levelHeight, j * gs.TileSizeZ),
                        Quaternion.identity);
                }

            }
        }
    }

}