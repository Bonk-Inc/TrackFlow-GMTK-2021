using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    [SerializeField]
    private Station startingPoint;

    private RoutePlanner planner;
    [SerializeField]
    private Queue<Station> route;

    public Action onDestinationReached, onRouteFinished;

    public void Start()
    {
        planner = GetComponent<RoutePlanner>();
        route = planner.PlanRoute(startingPoint);
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
            // Remove current destination
            Station currentDestination = route.Dequeue();

            if (onDestinationReached != null)
                onDestinationReached.Invoke();

            // Plan new route when reached last destination
            if (route.Count == 0)
            {
                route = planner.PlanRoute(route.Dequeue());

                if (onRouteFinished != null)
                    onRouteFinished.Invoke();
            }
        }
    }

    public Station[] GetDestinations()
    {
        return route.ToArray();
    }

    public Station GetNextDestination()
    {
        return route.Peek();
    }
}
