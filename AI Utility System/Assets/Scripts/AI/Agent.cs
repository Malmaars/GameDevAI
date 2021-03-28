using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour, IDamageable
{
    public AIBehaviourSelector AISelector { get; private set; }
    public BlackBoard BlackBoard { get; private set; }

    protected Transform playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        OnInitialize();
    }

    public void OnInitialize()
    {
        AISelector = GetComponent<AIBehaviourSelector>();
        BlackBoard = GetComponent<BlackBoard>();
        BlackBoard.OnInitialize();
        AISelector.OnInitialize(BlackBoard);

        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        AISelector.OnUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
        var distance = BlackBoard.GetFloatVariableValue(VariableType.Distance);

        //Change this to reflect the distance to the player
        distance.Value = Vector3.Distance(transform.position, playerTarget.position);
        //Debug.Log(distance.Value);

        var smokeBool = BlackBoard.GetFloatVariableValue("InSmoke");

        if (GameObject.FindGameObjectWithTag("Smoke") != null &&
            Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Smoke").transform.position) < 7.5f)
        {
            smokeBool.Value = 1;
        }
        else { smokeBool.Value = 0; }
    }

    public void TakeDamage(float damage)
    {
        FloatValue res = BlackBoard.GetFloatVariableValue(VariableType.Health);
        if (res)
        {
            res.Value -= damage;
        }
        AISelector.EvaluateBehaviours();
    }
}


public interface IDamageable
{
    void TakeDamage(float damage);
}