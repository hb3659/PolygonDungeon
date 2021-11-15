using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//StateMachine
// - ���¸� �ٲٰ� �� ������ DoUpdate �Լ��� �����Ű��
//   ���µ��� �Ѱ����ִ� ����

public sealed class StateMachine<T>
{
    private T context;

    // ���� ���¿� ���� ����
    private State<T> currentState;
    // �б� ����
    public State<T> CurrentState
    {
        get { return currentState; }
    }

    // ���� ���¿� ���� ����
    private State<T> priviousState;
    public State<T> PriviousState
    {
        get { return priviousState; }
    }

    // ���� ��ȭ �� �󸶳� �ð��� �귶���� Ȯ���ϱ� ���� ����
    // ������ ��Ÿ��
    private float elapsedTimeInState = 0f;
    public float ElapsedTimeInState
    {
        get { return elapsedTimeInState; }
    }

    // ���¸� ����ϱ� ���� ��ųʸ�
    // State�� Ÿ�԰� State�� �ν��Ͻ��� ����
    private Dictionary<Type, State<T>> states = new Dictionary<Type, State<T>>();

    public StateMachine(T context, State<T> initialState)
    {
        this.context = context;

        // ���¸� �ʱ�ȭ
        AddState(initialState);
        // ��ϵ� ���¸� ���� ���·� ������ �� �ٷ� ����� �� �ֵ��� �Ѵ�.
        currentState = initialState;
        currentState.OnEnter();
    }

    public void AddState(State<T> state)
    {
        // ����Ϸ��� ���¿� ���� �ӽ��� ������ �ִ� �����ڸ� �Ķ���ͷ�
        state.SetStateMachineAndContext(this, context);
        // ��ųʸ��� ���
        states[state.GetType()] = state;
    }

    public void Update(float deltaTime)
    {
        elapsedTimeInState += deltaTime;
        CurrentState.OnUpdate(deltaTime);
    }

    // R �� �ݵ�� State<T>���� ��ӹ��� Ÿ���̾�� �Ѵ�.
    public R ChangeState<R>() where R : State<T>
    {
        // Ÿ���� Ȯ���ϱ� ����
        var newType = typeof(R);

        // ���� ��ȭ�Ǿ���� ������ Ÿ�԰� �����ϴٸ�
        // ���� ���¸� �� �� ȣ���ϴ� �Ͱ� ����.
        if (currentState.GetType() == newType)
            // ���� ��ȯ���� �ʴ´�.
            return currentState as R;

        if (currentState != null)
            // ���ο� ���°� �����Ѵٸ� �� ���¸� �����Ѵ�.
            currentState.OnExit();

        // ���¸� ��ü
        priviousState = currentState;
        currentState = states[newType];
        currentState.OnEnter();
        elapsedTimeInState = 0f;

        return currentState as R;
    }
}
