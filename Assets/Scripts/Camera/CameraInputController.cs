using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputController : MonoBehaviour
{

    [SerializeField]
    private MoveInputCollection moveInput;

    [SerializeField]
    private Transform followTarget;

    public bool Follow { get; set; }

    private void Update()
    {
        var (hasMoved, movement) = moveInput.CheckMove();

        if (hasMoved)
        {
            Follow = false;
            transform.Translate(movement);
        }

        if (!Follow && Input.GetKeyDown(KeyCode.K))//TODO remove, just used for testing
        {
            Follow = true;
        }

        if (Follow)//possibly put this in fixed update
        {
            transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
        }
    }

}
