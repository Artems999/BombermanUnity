using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGen : MonoBehaviour
{
    public GameObject tile;

    private float levelHeight = 0.0f;
    //private GameSet gs = new GameSet();
          
    // Start is called before the first frame update
    void Start()
    {
        GenFloor();
    }

    void GenFloor()
    {
        var gs = GameSet.Default;
        for (int i = 0; i < gs.FieldSizeX; i++)
        {
            for (int j = 0; j < gs.FieldSizeZ; j++)
            {
                Instantiate(tile, new Vector3(i * gs.TileSizeX, levelHeight, j * gs.TileSizeZ), Quaternion.identity);
            }
        }
    }
}
