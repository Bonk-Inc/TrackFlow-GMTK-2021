using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Train : MonoBehaviour
{
    [SerializeField] 
    private float speed, offset;

    [SerializeField] 
    private Waypoint startPoint;

    [SerializeField] 
    private Locomotive locomotive;

    [SerializeField]
    private Wagon prefabWagon;

    [SerializeField]
    private TextMeshProUGUI lengthCounter, destinationName;

    [SerializeField] 
    private RouteManager routeManager;

    [SerializeField] 
    private Image stationIcon;
    
    private Station nextDestination;
    
    private int length;
    
    public float Speed { get => speed; }
    
    public float Offset { get => offset; }
    
    public Waypoint StartPoint { get => startPoint; }

    private void Start()
    {
        ArrivalTime arrivalTime = GetComponent<ArrivalTime>();

        arrivalTime.onEarlyArrival += AddWagon;
        arrivalTime.onLateArrival += DetachLastWagon;

        length = 1;
        nextDestination = routeManager.GetNextDestination();
        destinationName.text = nextDestination.Name;
        stationIcon.color = nextDestination.Color;
        
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        lengthCounter.text = length.ToString();
    }

    [ContextMenu("Add Wagon")]
    public void AddWagon()
    {
        Wagon wagonToAdd = Instantiate(prefabWagon, transform);
        Wagon lastWagonAttached = locomotive.FirstWagon.GetLastWagonAttached();

        wagonToAdd.NextWaypoint = lastWagonAttached.NextWaypoint;
        wagonToAdd.Train = this;
        wagonToAdd.AttachTo(lastWagonAttached);

        length++;
        UpdateCounter();
    }

    [ContextMenu("Delete last wagon attached")]
    public void DetachLastWagon()
    {
        Wagon lastWagonAttached = locomotive.FirstWagon.GetLastWagonAttached();
        lastWagonAttached.Detach();

        length--;
        UpdateCounter();
    }
}
