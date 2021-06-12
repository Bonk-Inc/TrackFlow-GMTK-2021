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
        current++;
        current %= possiblePoints.Count;
    }

    public override Waypoint[] GetAllPoints()
    {
        return possiblePoints.ToArray();
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmoz || possiblePoints == null)
            return;

        Gizmos.color = Color.blue;
        for (int i = 0; i < possiblePoints.Count; i++)
        {
            if (possiblePoints[i] == null)
                continue;

            Gizmos.DrawLine(Position, possiblePoints[i].Position);
        }
    }

}
