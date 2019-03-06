using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject StaticWallsPrefab;
    public GameObject CollapsingWallsPrefab;
    public GameObject playerPrefab;

    private GameSet gs = GameSet.Default;
    private float levelHeight = 1.0f;


    void Start()
    {
        Field field = new Field();
        field.FirstTimeFieldGenerate();
        SpawnObjects(Field.GameField);
    }

   

    void SpawnObjects(int[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == 1)
                {
                    Instantiate(StaticWallsPrefab, new Vector3(i * gs.TileSizeX, levelHeight, j * gs.TileSizeZ),
                        Quaternion.identity);
                }
                else if (field[i, j] == 2)
                {
                    Instantiate(CollapsingWallsPrefab, new Vector3(i * gs.TileSizeX, levelHeight, j * gs.TileSizeZ),
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