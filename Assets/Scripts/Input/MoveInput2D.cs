using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveInput2D : MonoBehaviour
{

    public abstract (bool hasmoved, Vector2 movement) CheckMove();

}
