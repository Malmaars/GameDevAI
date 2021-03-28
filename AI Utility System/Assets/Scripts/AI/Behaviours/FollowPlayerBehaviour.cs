using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerBehaviour : AIBehaviour
{
    public override void Execute()
    {
        Debug.Log("Wow niet zo snel kom terug");

        Vector3 moveToThis = GameObject.FindGameObjectWithTag("Player").transform.position + (transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized * 5;
        navAgent.SetDestination(moveToThis);
    }
}
