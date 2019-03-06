using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public GameObject Player;

    private IEnumerator coroutine;

    private Field field = new Field();

    // Start is called before the first frame update
    



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            field.MovePlayerForward();
            coroutine = WaitAndMove(0.1f);
            StartCoroutine(coroutine);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            field.MovePlayerBackward();
        }
    }
    private IEnumerator WaitAndMove(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            MovePlayerObjectForward();
        }
    }





    void MovePlayerObjectForward()
    {
        Vector3 playerPosition = Player.transform.position;
        playerPosition.x += 0.1f;
        Player.transform.position = playerPosition;
    }
    void MovePlayerObjectBackward()
    {
        Vector3 playerPosition = Player.transform.position;
        playerPosition.x -= 0.1f;
        Player.transform.position = playerPosition;
    }
}
