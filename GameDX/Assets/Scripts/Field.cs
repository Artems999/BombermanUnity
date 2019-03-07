using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    private GameSet gs = GameSet.Default;


    public static int[,] GameField { get; private set; }

    public static int[] PlayerPosition { get; set; } = {0, 0};

    public void FirstTimeFieldGenerate()
    {
        CreateField();
        GenerateStaticField();
        GenerateCollapsingWalls();
        GeneratePlayerPosition();
        GenerateEnemyPosition();
    }


//Creating walls positions
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
            WriteToRandomCell(2);
            collapsingWalls++;
        } while (collapsingWalls < gs.CollapsingWalls);
    }

    //Creating persons positions
    void GeneratePlayerPosition()
    {
        WriteToRandomCell(9);
        for (int i = 0; i < GameField.GetLength(0); i++)
        {
            for (int j = 0; j < GameField.GetLength(1); j++)
            {
                if (GameField[i, j] == 9)
                {
                    PlayerPosition[0] = i;
                    PlayerPosition[1] = j;
                    break;
                }
            }
        }
    }

    void GenerateEnemyPosition()
    {
        WriteToRandomCell(8);
    }


    private void WriteToRandomCell(int value)
    {
        bool finded = false;
        do
        {
            int xPos = UnityEngine.Random.Range(1, gs.FieldSizeX - 2);
            int zPos = UnityEngine.Random.Range(1, gs.FieldSizeZ - 2);
            finded = AddSomeToField(xPos, zPos, value);
        } while (!finded);

    }

    private bool CellIsFree(int x, int z)
    {
        if (GameField[x, z] == 0)
            return true;
        else
            return false;
    }

    private bool AddSomeToField(int x, int z, int value)
    {
        if (CellIsFree(x, z))
        {
            GameField[x, z] = value;
            return true;
        }
        else
            return false;
    }

    public bool MovePlayer(PlayerMoves.Side Side)
    {
        int x = PlayerPosition[0];
        int z = PlayerPosition[1];
        bool added = false;
        switch (Side)
        {
            case PlayerMoves.Side.Backward:
                added = AddSomeToField(x - 1, z, 9);
                if (added)
                {
                    PlayerPosition[0]--;
                }
                break;

            case PlayerMoves.Side.Forward:
                added = AddSomeToField(x + 1, z, 9);
                if (added)
                {
                    PlayerPosition[0]++;
                }
                break;

            case PlayerMoves.Side.Left:
                added = AddSomeToField(x, z + 1, 9);
                if (added)
                {
                    PlayerPosition[1]++;
                }
                break;

            case PlayerMoves.Side.Right:
                added = AddSomeToField(x, z - 1, 9);
                if (added)
                {
                    PlayerPosition[1]--;
                }
                break;
        }

        if (added)
        {
            ChangeFieldValue(x, z, 0);
        }

        return added;
    }

    private void ChangeFieldValue(int x, int z, int value)
    {
        GameField[x, z] = value;
    }
}
