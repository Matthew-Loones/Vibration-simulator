using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticityForce : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float elasticityConstant;
    public Vector3 equilibriumPoint;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        equilibriumPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AddElasticityForce(elasticityConstant);
    }

    public virtual void AddElasticityForce(float elasticityconstant)
    {
        float tempDistance = Vector3.Distance(equilibriumPoint,transform.position);
        Vector3 tempDirection =(transform.position-equilibriumPoint).normalized;
        myRigidbody.AddForce(-elasticityconstant*tempDistance*tempDirection);
    }
}
