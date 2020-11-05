using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPointEvo : MonoBehaviour
{
    public PushCollectorEvo agent;

    private void OnTriggerEnter(Collider col)
    {
        // Touched goal.
        if (col.gameObject.CompareTag("resource"))
        {
            agent.CollectedResource();
        }
    }
}
