using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    public bool isMove;

    public void Box ()
    {
        if (!isMove)
        {
            isMove = true;
            Debug.Log("Path is Open");
            transform.position = new Vector2(transform.position.x, 1f);
        }
    }
}