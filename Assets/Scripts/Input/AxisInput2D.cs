using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisInput2D : MoveInput2D
{

    [SerializeField]
    private float speed = 1;

    public override (bool hasmoved, Vector2 movement) CheckMove()
    {
        Vector2 axis = GetAxis();

        if (axis.x == 0 && axis.y == 0)
            return (false, Vector2.zero);

        return (true, axis.normalized * speed);
    }

    private void Update()
    {
        CheckAxisInput();
    }

    private void CheckAxisInput()
    {
        
    }

    private Vector2 GetAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }

    
}
