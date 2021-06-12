using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] 
    private float speed;

    [SerializeField] 
    private Waypoint startPoint;

    private Waypoint nextWaypoint;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.Position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * speed;
        Waypoint waypoint = (null != nextWaypoint) ? nextWaypoint : startPoint.NextWaypoint();
        Vector3 chinaVector = transform.position - waypoint.Position;

        transform.rotation = Quaternion.Euler(waypoint.Position.x, waypoint.Position.y, Vector3.Angle(chinaVector, Vector3.up));
        transform.position = Vector3.MoveTowards(transform.position, waypoint.Position, step);
        
        if (Vector3.Distance(transform.position, waypoint.Position) < 0.01f && null != waypoint.NextWaypoint())
            nextWaypoint = waypoint.NextWaypoint();
    }
}
