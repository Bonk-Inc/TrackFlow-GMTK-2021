using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Waypoint : MonoBehaviour
{

    protected static bool drawGizmoz = false;

    public Vector3 Position => transform.position;

    public abstract Waypoint NextWaypoint();

    public abstract Waypoint[] GetAllPoints();

    [ContextMenu("Toggle Gizmos")]
    private void ToggleGizmos()
    {
        drawGizmoz = !drawGizmoz;
    }
}
