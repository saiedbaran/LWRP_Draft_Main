using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoints> path;

    void Start()
    {
        //StartCoroutine(followPath()); 
    }

    IEnumerator followPath()
    {
        print("Starting Patrol");
        foreach (WayPoints wayPoint in path)
        {
            print("Visiting waypoint: "+ wayPoint);
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
