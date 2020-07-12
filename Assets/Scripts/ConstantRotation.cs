using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public string axis;

    [Range(0, 10)]
    public float speed;

    private void FixedUpdate()
    {
        Vector3 newRot = Vector3.zero;
        switch (axis)
        {
            case "x":
                newRot = (transform.rotation.eulerAngles + Vector3.forward * speed);                
                break;

            case "y":
                newRot = (transform.rotation.eulerAngles + Vector3.up * speed);
                break;

            case "z":
                newRot = (transform.rotation.eulerAngles + Vector3.right * speed);
                break;
        }

        transform.rotation = Quaternion.Euler(newRot);
    }
}
