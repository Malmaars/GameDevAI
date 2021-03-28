using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIBehaviour : MonoBehaviour
{
    [SerializeField] public UtilityEvaluator[] utilities;

    protected NavMeshAgent navAgent;

    public void OnInitialize(BlackBoard bb)
    {
        foreach(var utility in utilities)
        {
            utility.OnInitialize(bb);
        }
        navAgent = GetComponent<NavMeshAgent>();
    }

    public float GetNormalizedScore()
    {
        return Mathf.Clamp01(utilities.ToList().Sum(x => x.GetNormalizedScore()) / utilities.Length);
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void Execute() { }
}
