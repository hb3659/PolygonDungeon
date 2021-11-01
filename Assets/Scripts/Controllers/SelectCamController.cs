using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCamController : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform point;

    private float moveSpeed = .15f;

    void Start()
    {
        new WaitForSeconds(1f);

        cam = Camera.main;
    }

    void LateUpdate()
    {
        CamWalk();
    }

    void CamWalk()
    {
        if (FadeMng.Instance.IsFade == false)
        {
            Vector3 camPosition =
                Vector3.MoveTowards(cam.transform.position, point.position, moveSpeed);
            Vector3 camRotation =
                Vector3.MoveTowards(cam.transform.eulerAngles, new Vector3(0, 90, 0), moveSpeed * 2);

            cam.transform.position = camPosition;
            cam.transform.eulerAngles = camRotation;
        }
    }
}
