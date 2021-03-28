using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatBehaviour : AIBehaviour
{


    public override void Execute()
    {
        //run bitch
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        Vector3 targetLocation = transform.position - playerPos;
        targetLocation = new Vector3(Mathf.Clamp(targetLocation.x, -50, 50), 0, Mathf.Clamp(targetLocation.z, -50, 50));
        navAgent.SetDestination(targetLocation);
    }
}
