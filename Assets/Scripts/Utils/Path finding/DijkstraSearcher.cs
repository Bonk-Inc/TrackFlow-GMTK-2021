using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DijkstraSearcher : MonoBehaviour
{
    private BinairyHeap<Node> open = new BinairyHeap<Node>(new NodeDistanceComparer());
    private List<Waypoint> closed = new List<Waypoint>();

    public Waypoint[] FindFrom(Waypoint start, Func<Node, bool> check)
    {
        Node current = new Node(start, null, 0);
        float currentDistance = 0;


        while (current != null)
        {
            
            if (closed.Contains(current.waypoint))
            {
                var nPoint = GetHighest();
                currentDistance = nPoint.distance;
                current = nPoint;
                continue;
            }

            if (check(current))
            {
                return ReconstructPath(current);
            }

            Waypoint[] neighbors = current.waypoint.GetAllPoints();
            foreach (Waypoint neighbor in neighbors)
            {
                if (closed.Contains(neighbor))
                    continue;

                float distanceToNeighbor = (neighbor.Position - current.waypoint.Position).magnitude;
                open.Enqueue(new Node(neighbor, current, currentDistance + distanceToNeighbor));
            }

            closed.Add(current.waypoint);
            var point = GetHighest();
            currentDistance = point != null ? point.distance : 0;
            current = point;
        }

        return null;
    }


    private Node GetHighest()
    {
        if(open.Count == 0)
        {
            return null;
        }
        return open.Dequeue();
    }

    private Waypoint[] ReconstructPath(Node node)
    {
        List<Waypoint> waypoints = new List<Waypoint>();
        do {
            waypoints.Add(node.waypoint);
            node = node.previous;
        } while (node != null);
        waypoints.Reverse();
        return waypoints.ToArray();
    }

    public class Node
    {
        public Waypoint waypoint;
        public Node previous;
        public float distance;

        public Node(Waypoint node, Node previous, float distance)
        {
            this.waypoint = node;
            this.previous = previous;
            this.distance = distance;
        }

        public override bool Equals(object obj)
        {
            return obj is Node node && node.waypoint.Equals(((Node)obj).waypoint);
        }

        public override int GetHashCode()
        {
            return waypoint.GetHashCode();
        }
    }

    public class NodeDistanceComparer : Comparer<Node>
    {
        public override int Compare(Node x, Node y)
        {
            return x.distance.CompareTo(y.distance);
        }
    }



}
