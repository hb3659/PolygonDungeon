using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State<EnemyController>
{
    public override void OnEnter()
    {
        context.agent?.SetDestination(context.Target.position);
        context.animator?.SetBool("IsMove", true);
    }

    public override void OnUpdate(float deltaTime)
    {
        Transform enemy = context.SerachEnemy();
        float stoppingDistance = context.attackRange;

        if (enemy)
        {
            // 적의 위치로 목적지를 설정
            context.agent.SetDestination(context.Target.position);

            // 이동할 거리가 남았다면
            if(context.agent.remainingDistance > stoppingDistance)
                context.controller.Move(context.agent.velocity * Time.deltaTime);
        }

        if (!enemy || context.agent.remainingDistance <= stoppingDistance)
            stateMachine.ChangeState<IdleState>();
    }

    public override void OnExit()
    {
        context.animator.SetBool("IsMove", false);
        context.agent.ResetPath();
    }
}
