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
        // 계속 적을 검색
        Transform enemy = context.SerachEnemy();

        if (enemy)
        {
            // 적을 발견하고 그 적이 공격할 수 있는 적이라면 공격 상태로 전환
            if (context.IsAttackable)
                stateMachine.ChangeState<AttackState>();
            else
                stateMachine.ChangeState<MoveState>();
        }
        else if (isPatrol && stateMachine.ElapsedTimeInState > idleTime)
            stateMachine.ChangeState<PatrolState>();
    }
}
