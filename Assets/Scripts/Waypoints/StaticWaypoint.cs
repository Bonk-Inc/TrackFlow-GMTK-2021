using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticWaypoint : Waypoint
{
    [SerializeField]
    private Waypoint next;

    
    public override Waypoint NextWaypoint()
    {
        return next;
    }

    public override Waypoint[] GetAllPoints()
    {
        return new Waypoint[] { next };
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmoz || next == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Position, next.Position);

    }
}
