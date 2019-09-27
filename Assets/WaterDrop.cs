using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    [SerializeField] float blendingRatio = 1f;
    SkinnedMeshRenderer waterBlendshape;
    float waterBlendingPrecent = 0.0f;
    bool waterCollision = false;
    bool NewColliderActive = false;
    private Collider col;
    // Start is called before the first frame update
    void Start()
    {
        waterBlendshape = GetComponent<SkinnedMeshRenderer>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waterCollision == true && waterBlendingPrecent < 100f)
        {
            waterBlendingPrecent = waterBlendingPrecent + Time.deltaTime * blendingRatio;
        }
        Waterblending();
        if (waterBlendingPrecent > 99f && !NewColliderActive)
        {
            Destroy(col);
            gameObject.AddComponent<BoxCollider>();
            NewColliderActive = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        waterCollision = true;
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Water")
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void Waterblending()
    {
        waterBlendshape.SetBlendShapeWeight(0, waterBlendingPrecent);
    }
}
