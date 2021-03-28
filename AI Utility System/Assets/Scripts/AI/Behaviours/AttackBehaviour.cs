using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : AIBehaviour
{
    private bool hasWeapon;
    public override void Execute()
    {
        //get close to the player and fuckin smack them
        //or throw shit idk
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (hasWeapon)
        {

            navAgent.SetDestination(playerPos);
            if (Vector3.Distance(transform.position, playerPos) < 5)
            {
                //smack
                Debug.Log("Smack");
                //damage the player
            }
            GameObject.FindGameObjectWithTag("Weapon").transform.position = transform.position + transform.forward;
        }
        else
        {
            navAgent.SetDestination(GameObject.FindGameObjectWithTag("Weapon").transform.position);
            if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Weapon").transform.position) < 1)
            {
                hasWeapon = true;
            }

        }
    }

    public override void OnExit()
    {
        base.OnExit();
        hasWeapon = false;
        //drop weapon
    }
}
