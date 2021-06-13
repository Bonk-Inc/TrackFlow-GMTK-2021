using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField]
    private string name;

    [SerializeField]
    private int stationRange = 10;
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

    // Within first 10%
    public List<StationDistance> FindNear()
    {
        int range = Mathf.FloorToInt(stations.Count / stationRange); //2
        return FindInRange(0, range);
    }

    // Within last 10%
    public List<StationDistance> FindFar()
    {
        int range = Mathf.FloorToInt(stations.Count / stationRange);
        return FindInRange(stations.Count - range, stations.Count);
    }
    
    
    public List<StationDistance> FindInRange(int min, int max)
    {
        List<Station> possibleStations = new List<Station>();

        return stations.GetRange(min, max - min);
    }

    public Station FindRandom()
    {
        int stationNumber = Random.Range(0, stations.Count);
        return stations[stationNumber].station;
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
