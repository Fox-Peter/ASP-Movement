using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectAction : ActionBase
{

    [ReorderableList]
    public ObjectRotate[] objectsToRotate;

    [Range(1f, 30f)]
    public float rotationSpeed;

    [System.Serializable]
    public struct ObjectRotate
    {
        public bool dirX, dirY, dirZ;
        public GameObject gameObject;
    }
    public override void Execute()
    {
        foreach (var obj in objectsToRotate)
        {
            if (obj.gameObject == null)
            {
                Debug.LogWarning($"({gameObject.name}) > RotateObjectAction ({this.Name}) Object is null, ignoring", this.gameObject);
            }
            else
            {
                if (obj.dirX) { obj.gameObject.transform.Rotate(obj.gameObject.transform.right, rotationSpeed * Time.deltaTime); }
                if (obj.dirY) { obj.gameObject.transform.Rotate(obj.gameObject.transform.up, rotationSpeed * Time.deltaTime); }
                if (obj.dirZ) { obj.gameObject.transform.Rotate(obj.gameObject.transform.forward, rotationSpeed * Time.deltaTime); }
            }
        }
    }
}
