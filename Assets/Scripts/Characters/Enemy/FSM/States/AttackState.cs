using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<EnemyController>
{ 
    public override void OnEnter()
    {
        if (context.IsAttackable)
            context.animator.SetTrigger("attackTrigger");
        else
            stateMachine.ChangeState<IdleState>();
    }

    public override void OnUpdate(float deltaTime)
    {
        
    }
}
