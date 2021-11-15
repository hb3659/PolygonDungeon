using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 씬에 보여주기 위한 편집기
[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        // 왼쪽 꼭짓점
        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
        // 오른쪽 꼭짓점
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fov.VisibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }
    }
}
