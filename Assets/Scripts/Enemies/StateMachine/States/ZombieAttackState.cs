using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    private GameObject followTarget;
    private float AttackRange = 2.0f;

    private IDamagable damagableObject;

    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private static readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");

    public ZombieAttackState(GameObject FollowObject ,ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        followTarget = FollowObject;
        UpdateInterval = 2.0f;

        damagableObject = followTarget.GetComponent<IDamagable>();
    }
   
    public override void Start()
    {
        base.Start();
        OwnerZombie.zombieMeshAgent.isStopped = true;
        OwnerZombie.zombieMeshAgent.ResetPath();
        OwnerZombie.ZombieAnimator.SetFloat(MovementZHash, 0.0f);
        OwnerZombie.ZombieAnimator.SetBool(IsAttackingHash, true);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        damagableObject.TakeDamage(OwnerZombie.ZombieDamage);
    }

    public override void Update()
    {
        OwnerZombie.transform.LookAt(followTarget.transform.position, Vector3.up);

        float distanceBetween = Vector3.Distance(OwnerZombie.transform.position, followTarget.transform.position);
        if(distanceBetween > AttackRange)
        {
            StateMachine.ChangeState(ZombieStateType.Follow);
        }

    }

    public override void Exit()
    {
        base.Exit();
        OwnerZombie.ZombieAnimator.SetBool(IsAttackingHash, false);

    }
}
