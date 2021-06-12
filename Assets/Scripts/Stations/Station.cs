using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField]
    private string name;
    private Waypoint location;

    public string Name { get => name; set => name = value; }
    public Waypoint Location { get => location; }

    private void Awake()
    {
        location = GetComponent<Waypoint>();
    }
}
