using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public GameObject Player;

    public enum  Side
    {
        Left,
        Right,
        Forward,
        Backward
    }

    private IEnumerator coroutine;

    private Field field = new Field();

    private bool KeyUp = true;
    private float MovingSpeed = 5.0f;

    // Start is called before the first frame update

    /* coroutine = WaitAndMove(0.1f);
            StartCoroutine(coroutine);*/


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (KeyUp)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    MovePlayer(Side.Forward);
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    MovePlayer(Side.Backward);
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    MovePlayer(Side.Left);
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    MovePlayer(Side.Right);
                }
               
                KeyUp = false;
            }
        }
        else
        {
            KeyUp = true;
        }

    }

    void MovePlayer(Side side)
    {
        Vector3 startPosition = new Vector3(GetPlayerPosition(0),1.0f,GetPlayerPosition(1));
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
            coroutine = MoveFromTo(Player, startPosition, endPosition, MovingSpeed);
            StartCoroutine(coroutine);
        }

    }

    
    IEnumerator MoveFromTo(GameObject objectToMove, Vector3 startPosition, Vector3 endPosition, float speed)
    {
        float step = (speed / (startPosition - endPosition).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; 
            objectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, t); 
            yield return new WaitForFixedUpdate();        
        }
        objectToMove.transform.position = endPosition;
    }

    int GetPlayerPosition(int axis)
    {
        return Field.PlayerPosition[axis] * 2;
    }



   

  

}
