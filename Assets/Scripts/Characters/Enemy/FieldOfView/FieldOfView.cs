using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // 시야의 거리
    public float viewRadius;
    // 시야각
    [Range(0, 360)]
    public float viewAngle;
    public float delay = .2f;

    private float distanceToTarget;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    private Transform nearestTarget = null;

    private List<Transform> visibleTargets = new List<Transform>();

    #region Property
    // 읽기 전용 (ReadOnly)
    public List<Transform> VisibleTargets => visibleTargets;
    public float DistanceToTarget => distanceToTarget;
    public Transform NearestTarget => nearestTarget;
    #endregion

    void Start()
    {
        StartCoroutine(FindTargetDelay(delay));
    }

    IEnumerator FindTargetDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindTargets();
        }
    }

    void FindTargets()
    {
        distanceToTarget = 0.0f;
        nearestTarget = null;
        visibleTargets.Clear();

        // 중점과 반지름으로 가상의 원을 만들어 반경 이내에 들어와 있는 콜라이더를 추출하여 반환
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            // 자기 위치에서부터 타겟 위치의 방향을 정규화
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            // 전방 벡터와 타겟 방향 벡터의 크기가 시야각의 1/2 이면 
            // 시야각 안에 타겟이 존재
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                // 적과 나 사이에 장애물이 없다면
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    VisibleTargets.Add(target);

                    if (nearestTarget == null || (DistanceToTarget > dstToTarget))
                    {
                        nearestTarget = target;
                        distanceToTarget = dstToTarget;

                        //print("raycast Hit");
                        //Debug.DrawRay(transform.position, dirToTarget * distanceToTarget, Color.red, 5f);
                    }
                }
            }
        }
    }
    internal Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            // 로컬이라면 현재 오브젝트의 y 값
            // 글로벌이라면 글로벌의 y 값
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    void OnDisable()
    {
        nearestTarget = null;
        visibleTargets.Clear();
    }
}
