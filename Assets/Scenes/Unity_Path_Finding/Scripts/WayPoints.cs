using System.Collections;
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
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        print(transform.Find("Top").GetComponent<MeshRenderer>());
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        //topMeshRenderer.material.color = color; //Old Renderpipeline 
        var materialBlock = new MaterialPropertyBlock();
        materialBlock.SetColor("_BaseColor", color);
        topMeshRenderer.SetPropertyBlock(materialBlock);
    }
}
