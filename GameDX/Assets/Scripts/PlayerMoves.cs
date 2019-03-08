using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public GameObject Player;
    public enum Side
    {
        Left,
        Right,
        Forward,
        Backward
    }

    private Field field = new Field();

   // private bool keyUp = true;
    private bool stepFinished = true;
    private float MovingSpeed = 5.0f;

    void Update()
    {
        if (stepFinished)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MovePlayer(Side.Forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                MovePlayer(Side.Backward);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                MovePlayer(Side.Left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MovePlayer(Side.Right);
            }

        }
    }


    void MovePlayer(Side side)
    {
        Vector3 startPosition = new Vector3(GetPlayerPosition(0), 1.0f, GetPlayerPosition(1));
        Vector3 endPosition = startPosition;

        switch (side)
        {
            case Side.Forward:
                endPosition.x += 2;
                break;
            case Side.Backward:
                endPosition.x -= 2;
                break;
            case Side.Left:
                endPosition.z += 2;
                break;
            case Side.Right:
                endPosition.z -= 2;
                break;
        }

        if (field.MovePlayer(side))
        {
            
            StartCoroutine(MoveFromTo(Player, startPosition, endPosition, MovingSpeed));
        }

    }


    IEnumerator MoveFromTo(GameObject objectToMove, Vector3 startPosition, Vector3 endPosition, float speed)
    {
        stepFinished = false;
        float step = (speed / (startPosition - endPosition).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step;
            objectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return new WaitForFixedUpdate();
        }

        objectToMove.transform.position = endPosition;
        stepFinished = true;

    }

    int GetPlayerPosition(int axis)
    {
        return Field.PlayerPosition[axis] * 2;
    }
}
