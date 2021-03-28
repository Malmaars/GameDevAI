using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BlackBoard : MonoBehaviour
{
    [SerializeField] private List<FloatValue> floatVariables = new List<FloatValue>();
    //[SerializeField] private List<FloatValue> boolVariables = new List<FloatValue>();

    public Dictionary<VariableType, FloatValue> VariableDictionary { get; private set; } = new Dictionary<VariableType, FloatValue>();

    public void OnInitialize()
    {
        VariableDictionary = new Dictionary<VariableType, FloatValue>();
        foreach(var v in floatVariables)
        {
            if (!VariableDictionary.ContainsKey(v.Type))
                VariableDictionary.Add(v.Type, v);
        }
    }

    public FloatValue GetFloatVariableValue(string name)
    {
        var res = floatVariables.Find(x => x.name == name);
        return res;
    }
    public FloatValue GetFloatVariableValue(VariableType type)
    {
        if (VariableDictionary.ContainsKey(type))
        {
            return VariableDictionary[type];
        }
        return null;
    }
    public bool GetBoolVariableValue(string name)
    {
        var res = floatVariables.Find(x => x.name == name);
        if (res != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
