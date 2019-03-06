using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{

    public GameObject EnemyPrefab;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EnemyPrefab, new Vector3(5.0f, 1.0f, 5.0f),
                        Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
