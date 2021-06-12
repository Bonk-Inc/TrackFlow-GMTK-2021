using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Waypoint : MonoBehaviour
{
    public Vector3 Position
    {
        get => transform.position; 
        set => transform.position = value;
    }

    public abstract Waypoint NextWaypoint();
}
