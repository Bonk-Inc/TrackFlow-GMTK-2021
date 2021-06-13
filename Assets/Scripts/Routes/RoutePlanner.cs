using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutePlanner : MonoBehaviour
{
    [SerializeField]
    private int routeSize = 3;
    [SerializeField]
    private Queue<Station> route = new Queue<Station>();

    public Queue<Station> PlanRoute(Station startingPoint)
    {
        route.Clear();
        AddDestinations(startingPoint);
        return route;
    }

    private void AddDestinations(Station from)
    {
        List<Station> toAdd = FixDifferences(from.FindNear(), from);

        for (int i = 0; i < toAdd.Count; i++)
        {
            route.Enqueue(toAdd[i]);
        }

        List<Station> farStations = from.FindFar();
        int finalStation = Random.Range(0, farStations.Count - 1);

        route.Enqueue(farStations[finalStation]);
    }

    private List<Station> FixDifferences(List<Station> toChange, Station from)
    {
        int diff = toChange.Count - routeSize;
        if (diff > 0)
        {
            for (int i = 0; i < toChange.Count - routeSize; i++)
            {
                int toRemove = Random.Range(0, toChange.Count - 1);
                toChange.RemoveAt(toRemove);
            }
        }
        else if (diff < 0)
        {
            diff = Mathf.Abs(diff);
            for (int i = 0; i < diff; i++)
            {
                toChange.Add(from.FindRandom());
            }
        }

        return toChange;
    }
}
