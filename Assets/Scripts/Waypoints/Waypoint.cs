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

    protected static bool drawGizmoz = false;

    public abstract Waypoint NextWaypoint();

    public abstract Waypoint[] GetAllPoints();

    [ContextMenu("Toggle Gizmos")]
    private void ToggleGizmos()
    {
        drawGizmoz = !drawGizmoz;
    }
}
