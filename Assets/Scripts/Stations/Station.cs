using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField]
    private string name;
    private Waypoint location;

    [SerializeField]
    private List<StationDistance> stations;

    public string Name { get => name; set => name = value; }
    public Waypoint Location { get => location; }

    private void Awake()
    {
        location = GetComponent<Waypoint>();
        FindStationInOrderOfDistance();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    private void FindStationInOrderOfDistance()
    {
        DijkstraSearcher ds = new DijkstraSearcher();
        
        ds.FindFrom(Location, (node) =>
        {
            if (node.waypoint == Location)
                return false;

            Station station = node.waypoint.GetComponent<Station>();

            if (station == null)
                return false;

            stations.Add(new StationDistance(node.distance, station));

            return false;
        });
    }

    public StationDistance FindStation(Station station)
    {
        foreach (StationDistance currentStation in stations)
        {
            if (station.Equals(currentStation))
                return currentStation;
        }
        return null;
    }

    [System.Serializable]
    public class StationDistance
    {
        [SerializeField]
        public float distance;
        [SerializeField]
        public Station station;

        public StationDistance(float distance, Station station)
        {
            this.distance = distance;
            this.station = station;
        }
    }
}
