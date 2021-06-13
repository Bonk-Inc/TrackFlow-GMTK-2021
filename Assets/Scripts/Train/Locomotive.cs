using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Locomotive : MonoBehaviour
{
    [SerializeField] 
    private Train train;

    [SerializeField] 
    private Wagon firstWagon;

    private Waypoint nextWaypoint;

    public Wagon FirstWagon => firstWagon;
    public Action<Waypoint> onWayPointReach;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = train.StartPoint.Position;
        firstWagon.transform.localPosition = new Vector3(transform.localPosition.x - 5, transform.localPosition.y, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()   
    {
        float step = Time.deltaTime * train.Speed;
        Waypoint waypoint = (null != nextWaypoint) ? nextWaypoint : train.StartPoint.NextWaypoint();
        Vector2 difference = transform.position - waypoint.Position;

        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, difference) - train.Offset);
        transform.position = Vector3.MoveTowards(transform.position, waypoint.Position, step);
        
        if (Vector3.Distance(transform.position, waypoint.Position) < 0.01f && null != waypoint.NextWaypoint())
        {
            nextWaypoint = waypoint.NextWaypoint();
            if (onWayPointReach != null)
                onWayPointReach(waypoint);
        }
    }
}
