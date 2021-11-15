using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// StateMachine 에서 사용할 State 를 구현
public abstract class State<T>
{
    // State 를 관리하는 StateMachine 에 접근할 수 있도록
    protected StateMachine<T> stateMachine;
    // 상태의 소유자에 대한 context
    protected T context;

    public State() { }

    internal void SetStateMachineAndContext(StateMachine<T> stateMachine, T context)
    {
        this.stateMachine = stateMachine;
        this.context = context;

        // 상태에 대한 초기화 함수 호출
        OnInitialized();
    }

    public virtual void OnInitialized() { }
    public virtual void OnEnter() { }
    // 순수 가상 함수
    public abstract void OnUpdate(float deltaTime);
    public virtual void OnExit() { }
}
