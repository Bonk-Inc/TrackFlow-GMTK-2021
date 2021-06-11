using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Waypoint : MonoBehaviour
{
    public Vector3 Position => transform.position;

    public abstract Waypoint NextWaypoint();
}
