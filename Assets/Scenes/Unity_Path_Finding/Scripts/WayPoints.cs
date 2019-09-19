﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer meshRendererTop = transform.Find("Top").GetComponent<MeshRenderer>();
        meshRendererTop.material.color = color;
    }
}
