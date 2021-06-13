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

    public Wagon PrevWagon() => prevWagon;
    
    public void PrevWagon(Wagon wagon) => prevWagon = wagon;
    
    public Wagon NextWagon() => nextWagon;

    public void NextWagon(Wagon wagon) => nextWagon = wagon;

    public void Train(Train train) => this.train = train;
    
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
                lastWagon = lastWagon.NextWagon();
        }

        return lastWagon;
    }

    public void AttachTo(Wagon prevWagon)
    {
        prevWagon.NextWagon(this);
        
        this.prevWagon = prevWagon;
        this.nextWagon = null;
    }
    
    private void CoupleWagon()
    {
        if (null != prevWagon)
        {
            transform.position = new Vector3(prevWagon.transform.position.x - 5,
                prevWagon.transform.position.y, prevWagon.transform.position.z);
        }
    }
}