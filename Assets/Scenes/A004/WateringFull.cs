using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class WateringFull : MonoBehaviour
{
    SkinnedMeshRenderer BlendShape;
    [SerializeField] [Range (0.0f,100f)] float wettingPrecent = 0.0f;
    [SerializeField] float wettingMultiplier = 1.0f;
    [SerializeField] float DryingMultiplier = 1.0f;
    [SerializeField] float DropTime = 1.0f;
    [SerializeField] float CactusHealth = 100f;
    [SerializeField] float CactusHitPoint = 10f;

    bool underWater = false;
    public GameObject WaterSplash;
    public GameObject WaterDrop;
    public GameObject WateronGround;

    float dropWaitTime = 0f;

    void Start()
    {
        BlendShape = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputKeys();
        WaterCheck();
        WateringMethod();
    }

    private void WaterCheck()
    {

    }

    private void WateringMethod()
    {
        BlendShape.SetBlendShapeWeight(0, wettingPrecent);
    }
    
    private void WaterDropping()
    {
        GameObject waterDrop = Instantiate(WaterDrop) as GameObject;
        waterDrop.transform.position = transform.position;
    }

    private void GetInputKeys()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            float verticalPosition = transform.position.y - 0.2f;
            transform.position = new Vector3(transform.position.x,verticalPosition,transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            float verticalPosition = transform.position.y + 0.2f;
            transform.position = new Vector3(transform.position.x,verticalPosition,transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            Debug.Log("Cuctus is underwater");
            if (!underWater)
            {
                // GameObject waterSplash = Instantiate(WaterSplash) as GameObject;
                // waterSplash.transform.position = transform.position;
            }
            underWater = true;
        }
        if (collider.gameObject.tag == "CactusEnemy")
        {
            CactusHealth = CactusHealth - CactusHitPoint;
            if (CactusHealth < 1)
            {
                Destroy(gameObject,0.001f);
                if (wettingPrecent > 1)
                {
                    GameObject waterOnGround = Instantiate(WateronGround) as GameObject;
                    waterOnGround.transform.position = transform.position;
                }
            }
        }
        if (collider.gameObject.tag == "FullWater")
        {
            Debug.Log("Collider Happend");
            wettingPrecent = 100f;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Cuctus is out of water");
        underWater = false;
    }

}
