using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class PulseMaker : MonoBehaviour
{
    public float maxRadius;
    public float speed;
    public float force;
    public float currentRadius;
    private bool blast;
    public Vector3 source;
    public List<Collider> hitObjects;
    public Vector3 vibrateDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        source = transform.position;
    }

    private void Blast()
    {
        if(currentRadius < maxRadius && blast)
        {
            currentRadius += Time.deltaTime*speed;
            Damage(currentRadius);
        }
        if(currentRadius>= maxRadius)
        {
            blast = false;
            currentRadius = 0f;
            hitObjects.Clear();
        }
    }

    private void Damage(float currentRadius)
    {
        Collider[] hittingObjects = Physics.OverlapSphere(transform.position, currentRadius);
        for(int i=0; i< hittingObjects.Length; i++)
        {
            Rigidbody rb= hittingObjects[i].GetComponent<Rigidbody>();
            Vector3 position = hittingObjects[i].GetComponent<ElasticityForce>().equilibriumPoint;

            if (position==null)
            {
                position = hittingObjects[i].transform.position;
            }
            if (!hitObjects.Contains(hittingObjects[i]) && force - (rb.drag * force * 0.05f * (1 / speed) * Vector3.Distance(source, position)) >= 0)
            {
                rb.AddForce(vibrateDirection.normalized * (force - (rb.drag*force * 0.05f * Vector3.Distance(source, position)*(1/speed))), ForceMode.Impulse);
                hitObjects.Add(hittingObjects[i]);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("activate force"))
        {
            blast = true;
        }
        Blast();
        source = transform.position;
    }

}
