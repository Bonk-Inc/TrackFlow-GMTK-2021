using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float Speed { get => speed; }
    public float Offset { get => offset; }
    
    public Waypoint StartPoint { get => startPoint; }

    [ContextMenu("Add Wagon")]
    public void AddWagon()
    {
        Wagon wagonToAdd = Instantiate(prefabWagon, transform);
        Wagon lastWagonAttached = locomotive.FirstWagon.GetLastWagonAttached();

        wagonToAdd.NextWaypoint = lastWagonAttached.NextWaypoint;
        wagonToAdd.Train = this;
        wagonToAdd.AttachTo(lastWagonAttached);
    }

    [ContextMenu("Delete last wagon attached")]
    public void DetachLastWagon()
    {
        Wagon lastWagonAttached = locomotive.FirstWagon.GetLastWagonAttached();
        lastWagonAttached.Detach();
    }
}
