using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalTime : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private float timePerDistance = 1f, delayedOffset = 1.4f;

    [SerializeField]
    private Station startingPoint;

    private RouteManager routeManager;
    private Station destination;

    private float arrivalTime = 40f, lateTime = 60f;

    public Action<Station> onDestinationUpdated;
    public Action onEarlyArrival, onLateArrival;

    private bool hap = false;

    private void Start()
    {
        routeManager = GetComponent<RouteManager>();
        routeManager.onDestinationReached += HandleArrival;

        CalculateNextArrivalTime();
        RestartTime();
    }
    private void Update()
    {
        if (!hap)
        {
            hap = true;
        if (onDestinationUpdated != null)
            onDestinationUpdated.Invoke(destination);
        }
    }

    private void HandleArrival()
    {
        CheckArrivalTime();
        CalculateNextArrivalTime();
        RestartTime();
    }

    private void CheckArrivalTime()
    {
        if (timer.CurrentTime <= arrivalTime && onEarlyArrival != null)
            onEarlyArrival.Invoke();
        else if (timer.CurrentTime > lateTime && onLateArrival != null)
            onLateArrival.Invoke();
    }

    private void CalculateNextArrivalTime()
    {
        Station nextDestination = routeManager.GetNextDestination();
        float distance = destination != null ? destination.FindStation(nextDestination).distance :
                startingPoint.FindStation(nextDestination).distance;

        arrivalTime = distance * timePerDistance;
        lateTime = arrivalTime * delayedOffset;

        destination = destination != null ? destination.FindStation(nextDestination).station :
                startingPoint.FindStation(nextDestination).station;

        if (onDestinationUpdated != null)
            onDestinationUpdated.Invoke(destination);
    }

    private void RestartTime()
    {
        timer.ResetTime();
    }
}
