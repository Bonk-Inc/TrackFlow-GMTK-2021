using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] 
    private float speed;

    [SerializeField] 
    private Waypoint startPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.Position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, startPoint.NextWaypoint().Position, step);
    }
}
