using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<EnemyController>
{
    private bool isPatrol = false;
    private float minIdleTime = 0f;
    private float maxIdleTime = 3f;
    private float idleTime = 0f;

    public override void OnInitialized()
    {
        isPatrol = true;
    }
    public override void OnEnter()
    {
        context.animator.SetBool("IsMove", false);
        context.controller.Move(Vector3.zero);

        if (isPatrol)
            idleTime = Random.Range(minIdleTime, maxIdleTime);
    }
    public override void OnUpdate(float deltaTime)
    {
        // ��� ���� �˻�
        Transform enemy = context.SerachEnemy();

        if (enemy)
        {
            // ���� �߰��ϰ� �� ���� ������ �� �ִ� ���̶�� ���� ���·� ��ȯ
            if (context.IsAttackable)
                stateMachine.ChangeState<AttackState>();
            else
                stateMachine.ChangeState<MoveState>();
        }
        else if (isPatrol && stateMachine.ElapsedTimeInState > idleTime)
            stateMachine.ChangeState<PatrolState>();
    }
}
