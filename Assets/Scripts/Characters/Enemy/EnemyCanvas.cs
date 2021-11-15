using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanvas : MonoBehaviour
{
    public Canvas healthCanvas;
    public Camera cam;

    void Update()
    {
        healthCanvas.transform.LookAt(healthCanvas.transform.position + cam.transform.rotation * Vector3.forward,
            cam.transform.rotation * Vector3.up);
    }
}
