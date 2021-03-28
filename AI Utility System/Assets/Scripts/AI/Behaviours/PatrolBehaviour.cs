using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : AIBehaviour
{
    private bool walking = false;
    Vector3 targetLocation;

    public override void Execute()
    {
        if (!walking)
        {
            targetLocation = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
            navAgent.SetDestination(targetLocation);
            walking = true;
        }
        else if(Vector3.Distance(transform.position, targetLocation) < 5)
        {
            walking = false;
        }
    }
}
