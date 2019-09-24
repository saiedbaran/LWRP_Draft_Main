using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(followPath(path)); 
    }
    IEnumerator followPath(List<WayPoints> enemyPath)
    {
        print("Starting Patrol");
        foreach (WayPoints wayPoint in enemyPath)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("End Patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
