using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//StateMachine
// - 상태를 바꾸고 각 상태의 DoUpdate 함수를 실행시키는
//   상태들을 총괄해주는 역할

public sealed class StateMachine<T>
{
    private T context;

    // 현재 상태에 대한 변수
    private State<T> currentState;
    // 읽기 전용
    public State<T> CurrentState
    {
        get { return currentState; }
    }

    // 이전 상태에 대한 변수
    private State<T> priviousState;
    public State<T> PriviousState
    {
        get { return priviousState; }
    }

    // 상태 변화 후 얼마나 시간이 흘렀는지 확인하기 위한 변수
    // 공격의 쿨타임
    private float elapsedTimeInState = 0f;
    public float ElapsedTimeInState
    {
        get { return elapsedTimeInState; }
    }

    // 상태를 등록하기 위한 딕셔너리
    // State의 타입과 State의 인스턴스로 구성
    private Dictionary<Type, State<T>> states = new Dictionary<Type, State<T>>();

    public StateMachine(T context, State<T> initialState)
    {
        this.context = context;

        // 상태를 초기화
        AddState(initialState);
        // 등록된 상태를 현재 상태로 설정한 후 바로 실행될 수 있도록 한다.
        currentState = initialState;
        currentState.OnEnter();
    }

    public void AddState(State<T> state)
    {
        // 등록하려는 상태와 가상 머신을 가지고 있는 소유자를 파라미터로
        state.SetStateMachineAndContext(this, context);
        // 딕셔너리에 등록
        states[state.GetType()] = state;
    }

    public void Update(float deltaTime)
    {
        elapsedTimeInState += deltaTime;
        CurrentState.OnUpdate(deltaTime);
    }

    // R 은 반드시 State<T>에서 상속받은 타입이어야 한다.
    public R ChangeState<R>() where R : State<T>
    {
        // 타입을 확인하기 위함
        var newType = typeof(R);

        // 새로 변화되어야할 상태의 타입과 동일하다면
        // 같은 상태를 두 번 호출하는 것과 같다.
        if (currentState.GetType() == newType)
            // 상태 변환하지 않는다.
            return currentState as R;

        if (currentState != null)
            // 새로운 상태가 존재한다면 현 상태를 종료한다.
            currentState.OnExit();

        // 상태를 교체
        priviousState = currentState;
        currentState = states[newType];
        currentState.OnEnter();
        elapsedTimeInState = 0f;

        return currentState as R;
    }
}
