using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(StateMachine))]
public class ZombieComponent : MonoBehaviour
{
    public NavMeshAgent zombieMeshAgent { get; private set; }

    public Animator ZombieAnimator { get; private set; }
    public StateMachine stateMachine { get; private set; }

    public GameObject FollowTarget;

    [SerializeField] private bool _Debug;


    private void Awake()
    {
        zombieMeshAgent = GetComponent<NavMeshAgent>();
        ZombieAnimator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(_Debug)
        {
            Initalize(FollowTarget);
        }

    }

    public void Initalize(GameObject followTarget)
    {
        FollowTarget = followTarget;

        ZombieIdleState idleState = new ZombieIdleState(this, stateMachine);
        stateMachine.AddState(ZombieStateType.Idle, idleState);

        ZombieFollowState followState = new ZombieFollowState(FollowTarget, this, stateMachine);
        stateMachine.AddState(ZombieStateType.Follow, followState);

        ZombieAttackState attackState = new ZombieAttackState(followTarget, this, stateMachine);
        stateMachine.AddState(ZombieStateType.Attack, attackState);

        ZombieDeathState deathState = new ZombieDeathState(this, stateMachine);
        stateMachine.AddState(ZombieStateType.Dead, deathState);

        stateMachine.Initialize(ZombieStateType.Follow);
    }
}
