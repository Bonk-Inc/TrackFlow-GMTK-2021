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

    public Wagon PrevWagon { get => prevWagon; set => prevWagon = value; }
    public Wagon NextWagon { get => nextWagon; set => nextWagon = value; }
    
    public Train Train { set => train = value; }
    
    public Waypoint NextWaypoint { get => nextWaypoint; set => nextWaypoint = value; }
    
    public bool HasNextWagon => null != nextWagon;

    void Start()
    {
        CoupleWagon();
    }

    void Update()
    {
        float step = Time.deltaTime * train.Speed;
        Waypoint waypoint = (null != nextWaypoint) ? nextWaypoint : train.StartPoint.NextWaypoint();
        Vector2 difference = transform.position - waypoint.Position;

        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, difference) - train.Offset);
        transform.position = Vector3.MoveTowards(transform.position, waypoint.Position, step);
        
        if (Vector3.Distance(transform.position, waypoint.Position) < 0.01f && null != waypoint.NextWaypoint())
            nextWaypoint = waypoint.NextWaypoint();
    }

    public Wagon GetLastWagonAttached()
    {
        Wagon lastWagon = this;

        if (HasNextWagon)
        {
            while (lastWagon.HasNextWagon)
                lastWagon = lastWagon.NextWagon;
        }

        return lastWagon;
    }

    public void AttachTo(Wagon prevWagon)
    {
        prevWagon.NextWagon = this;
        
        this.prevWagon = prevWagon;
        this.nextWagon = null;
    }
    
    private void CoupleWagon()
    {
        if (null != prevWagon)
        {
            transform.localPosition = prevWagon.transform.localPosition + (prevWagon.transform.right.normalized * -5);
        }
    }
}