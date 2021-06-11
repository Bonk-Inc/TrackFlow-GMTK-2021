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
}
