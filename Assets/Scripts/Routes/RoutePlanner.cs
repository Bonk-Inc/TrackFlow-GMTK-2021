using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoutePlanner : MonoBehaviour
{
    [SerializeField]
    private int routeSize = 4;
    private Queue<Station> route = new Queue<Station>();

    public Queue<Station> PlanRoute(Station startingPoint)
    {
        route.Clear();
        for (int i = 0; i < routeSize; i++)
        {
            if(route.Count == 0)
                AddDestination(startingPoint);
            else
                AddDestination(route.ToArray()[i-1]);
        }

        return route;
    }

    private void AddDestination(Station from, List<Station> tries = null)
    {
        if (tries == null)
            tries = new List<Station>();


        Station toAdd = from.FindNear();
        if (ContainsStation(toAdd))
        {
            tries.Add(toAdd);
            AddDestination(from);
        }
        else
            route.Enqueue(toAdd);
    }

    private bool ContainsStation(Station station)
    {
        foreach (Station currentStation in route.ToArray())
        {
            if (currentStation.Equals(station))
                return true;
        }
        return false;
    }
}
