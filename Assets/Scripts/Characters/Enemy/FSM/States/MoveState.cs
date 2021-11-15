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
            // ���� ��ġ�� �������� ����
            context.agent.SetDestination(context.Target.position);

            // �̵��� �Ÿ��� ���Ҵٸ�
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
