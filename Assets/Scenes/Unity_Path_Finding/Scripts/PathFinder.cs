﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, WayPoints> grid = new Dictionary<Vector2Int, WayPoints>();

    
    void Start()
    {
        LoadBlocks();        
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
                if ()

        
                wayPoint.SetTopColor(Color.black);
            }
        }
        print(grid.Count);

    }
}
