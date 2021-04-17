using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{
    private readonly GameObject FollowTarget;
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private const float stopDistance = 2f;

    public ZombieFollowState(GameObject followTarget ,ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;
    }

    public override void Start()
    {
        base.Start();
        OwnerZombie.zombieMeshAgent.SetDestination(FollowTarget.transform.position);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        OwnerZombie.zombieMeshAgent.SetDestination(FollowTarget.transform.position);
    }

    public override void Update()
    {
        base.Update();
        OwnerZombie.ZombieAnimator.SetFloat(MovementZHash, OwnerZombie.zombieMeshAgent.velocity.normalized.z);

        if(Vector3.Distance(OwnerZombie.transform.position, FollowTarget.transform.position) < stopDistance)
        {
            StateMachine.ChangeState(ZombieStateType.Attack);
        }

        
    }
}
