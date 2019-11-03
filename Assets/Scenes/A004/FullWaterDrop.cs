using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullWaterDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
       Debug.Log("Trigger Full Water");
       Destroy(gameObject,0.001f); 
    }
}
