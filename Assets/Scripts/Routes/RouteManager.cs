using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    [SerializeField]
    private Station startingPoint;

    private RoutePlanner planner;
    
    private Queue<Station> route;

    public Action onDestinationReached, onRouteFinished;

    public void Start()
    {
        planner = GetComponent<RoutePlanner>();
        route = planner.PlanRoute(startingPoint);
        Locomotive loco = GetComponentInChildren<Locomotive>();
        loco.onWayPointReach += CheckStation;
    }

    public bool IsDestinationReached(Waypoint waypoint)
    {
        Station currentDestination = route.Peek();
        return currentDestination.Location.Equals(waypoint);
    }

    public void CheckStation(Waypoint waypoint)
    {
        if (IsDestinationReached(waypoint))
        {
            if (route.Count == 0)
                return;

                // Remove current destination
                Station currentDestination = route.Dequeue();


            // Plan new route when reached last destination
            if (route.Count == 0)
            {
                route = planner.PlanRoute(currentDestination);

                if (onRouteFinished != null)
                    onRouteFinished.Invoke();
            }

            if (onDestinationReached != null)
                onDestinationReached.Invoke();
        }
    }

    public Station[] GetDestinations()
    {
        return route.ToArray();
    }

    public Station GetNextDestination()
    {
        if (route.Count == 0)
            return null;
        return route.Peek();
    }
}
