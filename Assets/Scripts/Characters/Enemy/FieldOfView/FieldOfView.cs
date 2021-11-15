using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // �þ��� �Ÿ�
    public float viewRadius;
    // �þ߰�
    [Range(0, 360)]
    public float viewAngle;
    public float delay = .2f;

    private float distanceToTarget;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    private Transform nearestTarget = null;

    private List<Transform> visibleTargets = new List<Transform>();

    #region Property
    // �б� ���� (ReadOnly)
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

        // ������ ���������� ������ ���� ����� �ݰ� �̳��� ���� �ִ� �ݶ��̴��� �����Ͽ� ��ȯ
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            // �ڱ� ��ġ�������� Ÿ�� ��ġ�� ������ ����ȭ
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            // ���� ���Ϳ� Ÿ�� ���� ������ ũ�Ⱑ �þ߰��� 1/2 �̸� 
            // �þ߰� �ȿ� Ÿ���� ����
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                // ���� �� ���̿� ��ֹ��� ���ٸ�
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
            // �����̶�� ���� ������Ʈ�� y ��
            // �۷ι��̶�� �۷ι��� y ��
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
