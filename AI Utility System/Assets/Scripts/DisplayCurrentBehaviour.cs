using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrentBehaviour : MonoBehaviour
{
    TextMeshPro displayingText;
    void Awake()
    {
        displayingText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        transform.forward = transform.position - Camera.main.transform.position;

        if (GetComponentInParent<AIBehaviourSelector>().currentBehaviour != null)
            displayingText.text = GetComponentInParent<AIBehaviourSelector>().currentBehaviour.ToString();
    }
}
