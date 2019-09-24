using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoints startWayPoint, endWayPoint;

    Dictionary<Vector2Int, WayPoints> grid = new Dictionary<Vector2Int, WayPoints>();
    Queue<WayPoints> queue = new Queue<WayPoints>();
    List<WayPoints> path = new List<WayPoints>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left
    };
    
    bool isRunning = true;
    WayPoints searchCenter; // Current Search Center

    public List<WayPoints> GetPath()
    {
        LoadBlocks(); 
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }
    
    
    void Start()
    {
        //ExploreNeighbours();
    }

    private void CreatePath() 
    {
        path.Add(endWayPoint);
        WayPoints previous = endWayPoint.exploredFrom;
        while (previous != startWayPoint)
        {
            WayPoints current = previous;
            path.Add(current);
            previous = previous.exploredFrom;
        }
        path.Add(startWayPoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWayPoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEnd();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
        print("Finish BreadthFirstSearch!");
    }

    private void HaltIfEnd()
    {
        if (searchCenter == endWayPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) {return;}

        foreach (Vector2Int direction in directions)
        {
            Vector2Int ExpCoord = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(ExpCoord)) // TODO instead we can use try and catch
            {
                QueueNewNeighbours(ExpCoord);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int ExpCoord)
    {
        WayPoints neighbour = grid[ExpCoord];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
            //neighbour.isExplored = true; 
            //neighbour.SetTopColor(Color.blue); // trasformed into Waypoints class
        }

    }

    private void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.grey);
        endWayPoint.SetTopColor(Color.green);
    }

    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<WayPoints>();
        foreach (WayPoints wayPoint in wayPoints)
        {
            var gridPos = wayPoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("There is douplicate in "+ wayPoint);
            }
            else
            {
                grid.Add(gridPos, wayPoint);
            }
        }
        //print(grid.Count);

    }
}
