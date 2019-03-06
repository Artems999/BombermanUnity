using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    private GameSet gs = GameSet.Default;

    public static int[,] GameField { get; private set; }

    public void FirstTimeFieldGenerate()
    {
        CreateField();
        GenerateStaticField();
        GenerateCollapsingWalls();
        GeneratePlayerPosition();
    }



    void CreateField()
    {
        GameField = new int[gs.FieldSizeX, gs.FieldSizeZ];
        for (int i = 0; i < gs.FieldSizeX; i++)
        {
            for (int j = 0; j < gs.FieldSizeZ; j++)
            {
                GameField[i, j] = 0;
            }
        }
    }

    void GenerateStaticField()
    {
        for (int i = 0; i < gs.FieldSizeX; i++)
        {
            for (int j = 0; j < gs.FieldSizeZ; j++)
            {
                if (i == 0 || i == gs.FieldSizeX - 1 || j == 0 || j == gs.FieldSizeZ - 1)
                {
                    GameField[i, j] = 1;
                }
                else if (i % 2 == 0 && j % 2 == 0)
                {
                    GameField[i, j] = 1;
                }

            }
        }
    }

    void GenerateCollapsingWalls()
    {

        int collapsingWalls = 0;
        do
        {
            int x = UnityEngine.Random.Range(1, gs.FieldSizeX - 2);
            int z = UnityEngine.Random.Range(1, gs.FieldSizeZ - 2);

            if (GameField[x, z] == 0)
            {
                GameField[x, z] = 2;
                collapsingWalls++;
            }
        } while (collapsingWalls < gs.CollapsingWalls);
    }

    void GeneratePlayerPosition()
    {
        bool PlayerFieldSpawned = false;

        while (!PlayerFieldSpawned)
        {
            int x = UnityEngine.Random.Range(1, gs.FieldSizeX - 2);
            int z = UnityEngine.Random.Range(1, gs.FieldSizeZ - 2);

            if (GameField[x, z] == 0)
            {
                if (GameField[x - 1, z] == 0 || GameField[x + 1, z] == 0 || GameField[x, z - 1] == 0 || GameField[x, z + 1] == 0)
                {
                    GameField[x, z] = 9;
                    PlayerFieldSpawned = true;
                }
            }
        }
    }
}
