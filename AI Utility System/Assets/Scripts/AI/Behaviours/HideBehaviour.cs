using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBehaviour : AIBehaviour
{
    private bool thrown = false;
    public GameObject smoke;
    public override void Execute()
    {
        Debug.Log("Im gonna go hide bye");

        Vector3 moveToTree = searchForClosestTree().transform.position + 
            (searchForClosestTree().transform.position - GameObject.FindGameObjectWithTag("Enemy").transform.position).normalized;
        navAgent.SetDestination(moveToTree);

        if(GameObject.FindGameObjectWithTag("Smoke") == null && Vector3.Distance(transform.position, moveToTree) < 3)
        {
            ThrowBomb();
        }
    }

    private GameObject searchForClosestTree()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        GameObject temp = null;
        float tempDistance = 999;
        foreach(GameObject tree in trees)
        {
            if(Vector3.Distance(transform.position, tree.transform.position) < tempDistance)
            {
                temp = tree;
                tempDistance = Vector3.Distance(transform.position, tree.transform.position);
            }
        }
        return temp;
    }

    private void ThrowBomb()
    {
        //Throw a smoke bomb
        Instantiate(smoke, GameObject.FindGameObjectWithTag("Enemy").transform.position, new Quaternion(0, 0, 0, 0));

        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Agent>().TakeDamage(10);
    }
}
