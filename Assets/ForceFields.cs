using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFields : MonoBehaviour
{
    public float NormalSpeed;
    public float AngularSpeed;

    [SerializeField] Vector3 ForceField;
    [SerializeField] float Frequence;
    Vector3 CurrentForceField;
    float SinFun;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        CurrentForceField = new Vector3(0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        NormalSpeed = rigidBody.velocity.magnitude;
        AngularSpeed = rigidBody.angularVelocity.magnitude;

        if (Mathf.Sin(Time.deltaTime*Frequence) > 0f)
        {
            SinFun = 1f;
        }
        else
        {
            SinFun = -1f;
        }
        //CurrentForceField.x = ForceField.x *Mathf.Round(Mathf.Sin(Time.deltaTime*Frequence));
        CurrentForceField.x = ForceField.x * SinFun;

        rigidBody.AddForce(CurrentForceField);
        
    }
}
