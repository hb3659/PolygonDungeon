using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// StateMachine ���� ����� State �� ����
public abstract class State<T>
{
    // State �� �����ϴ� StateMachine �� ������ �� �ֵ���
    protected StateMachine<T> stateMachine;
    // ������ �����ڿ� ���� context
    protected T context;

    public State() { }

    internal void SetStateMachineAndContext(StateMachine<T> stateMachine, T context)
    {
        this.stateMachine = stateMachine;
        this.context = context;

        // ���¿� ���� �ʱ�ȭ �Լ� ȣ��
        OnInitialized();
    }

    public virtual void OnInitialized() { }
    public virtual void OnEnter() { }
    // ���� ���� �Լ�
    public abstract void OnUpdate(float deltaTime);
    public virtual void OnExit() { }
}
