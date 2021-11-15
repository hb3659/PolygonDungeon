using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONTransformTEST : MonoBehaviour
{
    void Start()
    {
        JSONSaveTransform test = new JSONSaveTransform(3);
    }

    void Update()
    {
        JSONSaveTransform test2 = new JSONSaveTransform(transform.position, transform.rotation, 3);

        Debug.Log(JSONCreator.Instance.ObjectToJson(test2));
    }
}
