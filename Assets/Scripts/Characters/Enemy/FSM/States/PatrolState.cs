using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State<EnemyController>
{
    public override void OnEnter()
    {
        if (context.targetWayPoint == null)
            context.FindNexWayPoint();

        if (context.targetWayPoint)
        {
            context.agent.SetDestination(context.targetWayPoint.position);
            context.animator.SetBool("IsMove", true);
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        Transform enemy = context.SerachEnemy();

        if (enemy)
        {
            if (context.IsAttackable)
                stateMachine.ChangeState<AttackState>();
            else
                stateMachine.ChangeState<MoveState>();
        }
        else
        {
            if(!context.agent.pathPending && (context.agent.remainingDistance <= context.agent.stoppingDistance))
            {
                Transform nextDest = context.FindNexWayPoint();

                if (nextDest)
                    context.agent.SetDestination(nextDest.position);

                stateMachine.ChangeState<IdleState>();
            }
            else
                context.controller.Move(context.agent.velocity * deltaTime);
        }
    }

    public override void OnExit()
    {
        context.animator.SetBool("IsMove", false);
        context.agent.ResetPath();
    }
}
