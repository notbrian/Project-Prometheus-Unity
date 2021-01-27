﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAgent : MonoBehaviour
{
    Rigidbody rBody;
    public GameObject CollectionPoint;
    public GameObject Resource;

    public float maxSpeed = 30;
    public float maxAcceleration = 1000;

    public string state = "collecting";
    public bool carryingObject = false;


    void Start()
    {
        rBody = GetComponent<Rigidbody>();

    }
    void Update()
    {

        if (state == "collecting")
        {
            Vector3 direction = (Resource.transform.position - transform.position).normalized;
            Vector3 lookRotation = Quaternion.LookRotation(direction).eulerAngles;
            lookRotation.x = -90f;
            // lookRotation.y = 0f;
            lookRotation.z = 0f;
            Debug.Log(lookRotation);
            transform.rotation = Quaternion.Euler(lookRotation);
            // transform.position = transform.position + direction * 2;
            rBody.AddForce(direction * maxAcceleration);


        }

        else if (state == "returning")
        {
            Vector3 direction = ((CollectionPoint.transform.position + new Vector3(10, 0, 0)) - transform.position).normalized;
            float distance = Vector3.Distance(CollectionPoint.transform.position, transform.position);

            Vector3 lookRotation = Quaternion.LookRotation(direction).eulerAngles;
            lookRotation.x = -90f;
            // lookRotation.y = 0f;
            lookRotation.z = 0f;
            transform.rotation = Quaternion.Euler(lookRotation);
            // transform.position = transform.position + direction * 2;
            rBody.AddForce(direction * maxAcceleration);

            if (distance < 10)
            {
                Resource.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Resource.transform.localPosition = new Vector3(0, -0.128f, 0.0423f);
                Resource.transform.parent = null;
                Resource = null;
                state = "seeking";
                carryingObject = false;
            }
        }

        else if (state == "seeking")
        {
            Resource = findNearestResource();

            if (Resource != null)
            {
                state = "collecting";
            }

            if (Resource == null)
            {
                state = "idle";
            }
        }
        else if (state == "idle")
        {
            Vector3 direction = (new Vector3(0, 0, 0) - transform.position).normalized;
            float distance = Vector3.Distance(CollectionPoint.transform.position, transform.position);
            Vector3 lookRotation = Quaternion.LookRotation(direction).eulerAngles;
            lookRotation.x = -90f;
            // lookRotation.y = 0f;
            lookRotation.z = 0f;
            transform.rotation = Quaternion.Euler(lookRotation);
            // transform.position = transform.position + direction * 2;
            rBody.AddForce(direction * maxAcceleration);

        }


        if (rBody.velocity.magnitude > maxSpeed)
        {
            rBody.velocity = rBody.velocity.normalized * maxSpeed;
        }

    }

    private GameObject findNearestResource()
    {
        GameObject[] resources = GameObject.FindGameObjectsWithTag("resource");
        GameObject closest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject resource in resources)
        {
            if (!resource.gameObject.GetComponent<Resource>().collected)
            {
                Vector3 diff = resource.transform.position - transform.position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = resource;
                    distance = curDistance;
                }
            }

        }
        return closest;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("resource") && !carryingObject)
        {
            if (!other.gameObject.GetComponent<Resource>().collected)
            {
                state = "returning";
                other.transform.parent = transform;
                // other.transform.localPosition = new Vector3(0, 2, 0);
                other.transform.localPosition = new Vector3(0, 0, 0.04f);
                other.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                other.gameObject.GetComponent<Resource>().collected = true;
                carryingObject = true;
            }

        }
    }

}
