using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathState : ZombieStates
{

    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private static readonly int IsDeadHash = Animator.StringToHash("IsDead");
    public ZombieDeathState(ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
    }

    public override void Start()
    {
        base.Start();
        OwnerZombie.zombieMeshAgent.isStopped = true;
        OwnerZombie.zombieMeshAgent.ResetPath();

        OwnerZombie.ZombieAnimator.SetFloat(MovementZHash, 0.0f);
        OwnerZombie.ZombieAnimator.SetBool(IsDeadHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        OwnerZombie.zombieMeshAgent.isStopped = false;
        OwnerZombie.ZombieAnimator.SetBool(IsDeadHash, false);
    }
}
