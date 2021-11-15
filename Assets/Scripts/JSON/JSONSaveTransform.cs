using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JSONSaveTransform
{
    public Vector3[] position;
    public Quaternion[] rotation;

    public JSONSaveTransform() { }
    public JSONSaveTransform(int slotNum)
    {
        position = new Vector3[slotNum];
        rotation = new Quaternion[slotNum];
    }

    public JSONSaveTransform(Vector3 v, Quaternion r, int index)
    {
        position[index] = v;
        rotation[index] = r;
    }
}
