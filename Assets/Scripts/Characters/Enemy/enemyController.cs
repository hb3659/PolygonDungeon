using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(FieldOfView))]
public class EnemyController : MonoBehaviour
{
    protected StateMachine<EnemyController> stateMachine;
    public StateMachine<EnemyController> StateMachine => stateMachine;

    [Header("Components")]
    [SerializeField]
    private FieldOfView fov;
    public Animator animator;
    public CharacterController controller;
    public NavMeshAgent agent;
    public Transform[] wayPoints;
    [HideInInspector]
    public Transform targetWayPoint;

    [Header("Variables")]
    public float attackRange;
    private int wayPointIndex = 0;

    [SerializeField]
    public Transform Target => fov?.NearestTarget;

    void Start()
    {
        stateMachine = new StateMachine<EnemyController>(this, new PatrolState());

        StateMachine.AddState(new IdleState());
        stateMachine.AddState(new MoveState());
        stateMachine.AddState(new AttackState());
        stateMachine.AddState(new DeadState());
    }

    void Update()
    {
        // �������� ���� �ð��� ����ϱ� ���� �ش� �Լ����� 
        // Time.deltaTime �� ���
        stateMachine.Update(Time.deltaTime);
        Debug.Log(StateMachine.ElapsedTimeInState);
    }

    // ������ ������ �Ÿ����� �Ǵ��ϱ� ���� ������Ƽ
    public bool IsAttackable
    {
        get
        {
            if (!Target)
                return false;

            float distance = Vector3.Distance(transform.position, Target.position);

            return distance < attackRange;
        }
    }

    public Transform SerachEnemy() { return Target; }

    public Transform FindNexWayPoint()
    {
        targetWayPoint = null;

        if (wayPoints.Length > 0)
            targetWayPoint = wayPoints[wayPointIndex];

        wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;

        return targetWayPoint;
    }
}
