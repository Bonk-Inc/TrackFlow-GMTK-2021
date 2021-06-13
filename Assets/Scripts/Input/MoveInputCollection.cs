using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveEvent: UnityEvent<Vector2> { }

public class MoveInputCollection : MoveInput2D
{

    [SerializeField]
    private MoveEvent OnMove;

    [SerializeField]
    private MoveInput2D[] inputs;

    public override (bool hasmoved, Vector2 movement) CheckMove()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i] == null)
                continue;

            var (hasmoved, movement) = inputs[i].CheckMove();

            if (hasmoved)
            {
                OnMove?.Invoke(movement);
                return (true, movement);
            }

        }

        return (false, Vector2.zero);
    }

}
