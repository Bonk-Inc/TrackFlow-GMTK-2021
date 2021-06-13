using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInput2D : MoveInput2D
{
    private Vector3 prevPosition;

    [SerializeField]
    private float speed = 0.2f;

    private void Awake()
    {
        prevPosition = Input.mousePosition;
    }

    public override (bool hasmoved, Vector2 movement) CheckMove()
    {
        if (Input.mousePosition == prevPosition || !Input.GetMouseButton(0))
        {
            prevPosition = Input.mousePosition;
            return (false, Vector2.zero);
        }

        var result = (true, (Input.mousePosition - prevPosition) * -speed);
        prevPosition = Input.mousePosition;
        return result;
    }
}
