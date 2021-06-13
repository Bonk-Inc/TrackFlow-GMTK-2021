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

    public float Speed => speed;

    public float Offset => offset;

    public Waypoint StartPoint => startPoint;

    [ContextMenu("Add Wagon")]
    public void AddWagon()
    {
        //TODO: remove prefab in develop china
        Wagon wagonToAdd = Instantiate(prefabWagon);
        Wagon lastWagonAttached = locomotive.FirstWagon.GetLastWagonAttached();
        
        wagonToAdd.Train(this);
        wagonToAdd.AttachTo(lastWagonAttached);
    }
}
