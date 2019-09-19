﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoints))]
public class CubeEditor : MonoBehaviour
{
    WayPoints wayPoints;
    private void Awake() 
    {
        wayPoints = GetComponent<WayPoints>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLable();

    }

    private void SnapToGrid()
    {
        int gridSize = wayPoints.GetGridSize();

        transform.position = new Vector3(
            wayPoints.GetGridPos().x,
            0, 
            wayPoints.GetGridPos().y
            );
    }

    private void UpdateLable()
    {
        int gridSize = wayPoints.GetGridSize();

        string lableText = wayPoints.GetGridPos().x / gridSize + "," + wayPoints.GetGridPos().y / gridSize;
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = lableText;
        gameObject.name = lableText;
    }
}