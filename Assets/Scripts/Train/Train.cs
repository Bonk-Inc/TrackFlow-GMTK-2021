using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] 
    private float speed, offset;

    [SerializeField] 
    private Waypoint startPoint;

    public float Speed => speed;
    
    public float Offset => offset;
    
    public Waypoint StartPoint => startPoint;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    /*void Update()
    {
        float step = Time.deltaTime * speed;
        Waypoint waypoint = (null != nextWaypoint) ? nextWaypoint : startPoint.NextWaypoint();
        Vector2 difference = transform.position - waypoint.Position;

        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, difference) - offset);
        transform.position = Vector3.MoveTowards(transform.position, waypoint.Position, step);
        
        if (Vector3.Distance(transform.position, waypoint.Position) < 0.01f && null != waypoint.NextWaypoint())
            nextWaypoint = waypoint.NextWaypoint();
    }*/
}
