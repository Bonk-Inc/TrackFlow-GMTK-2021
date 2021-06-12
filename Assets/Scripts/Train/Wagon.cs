using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    [SerializeField]
    private Wagon prevWagon, nextWagon;

    [SerializeField]
    private Train train; 
    
    private Waypoint nextWaypoint;

    void Start()
    {
        //TODO: uncomment when wagons get generated automatically
        //CoupleWagon();
    }

    private void Update()
    {
        float step = Time.deltaTime * train.Speed;
        Waypoint waypoint = (null != nextWaypoint) ? nextWaypoint : train.StartPoint.NextWaypoint();
        Vector2 difference = transform.position - waypoint.Position;

        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, difference) - train.Offset);
        transform.position = Vector3.MoveTowards(transform.position, waypoint.Position, step);
        
        if (Vector3.Distance(transform.position, waypoint.Position) < 0.01f && null != waypoint.NextWaypoint())
            nextWaypoint = waypoint.NextWaypoint();
    }

    [ContextMenu("Couples wagon")]
    private void CoupleWagon()
    {
        if (null != prevWagon)
        {
            transform.position = new Vector3(prevWagon.transform.position.x - 5,
                prevWagon.transform.position.y, prevWagon.transform.position.z);
        }
    }
}