using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWaypoint : Waypoint
{
    [SerializeField]
    private List<Waypoint> possiblePoints;

    private int current = 0;

    public override Waypoint NextWaypoint()
    {
        return possiblePoints[current];
    }

    public void SwitchRoute()
    {
        this.current = current++;
        current %= possiblePoints.Count;
    }
}
