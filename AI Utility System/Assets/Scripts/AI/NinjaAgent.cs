using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAgent : MonoBehaviour
{
    public AIBehaviourSelector AISelector { get; private set; }
    public BlackBoard BlackBoard { get; private set; }

    public Transform enemyTarget;
    public Transform playerTarget;
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

        enemyTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        AISelector.OnUpdate();

        var distance = BlackBoard.GetFloatVariableValue("FloatValue_Distance");

        distance.Value = Vector3.Distance(playerTarget.position, enemyTarget.position);

        Debug.Log(distance.Value);

        var distanceFromPlayer = BlackBoard.GetFloatVariableValue("FloatValue_DistanceNinja");
        distanceFromPlayer.Value = Vector3.Distance(playerTarget.position, transform.position);
        Debug.Log(distance.Value);

    }
}
