using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    public float rotateSmooth = 2f;  

    public bool isRotating { get; private set; }

    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    public void RotateLeft()
    {
        targetRotation *= Quaternion.AngleAxis(90f, Vector3.up);
    }

    public void RotateRight()
    {
        targetRotation *= Quaternion.AngleAxis(-90f, Vector3.up);
    }

    public void RotateDown()
    {
        targetRotation *= Quaternion.AngleAxis(-90f, Vector3.right);
    }

    public void RotateUp()
    {
        targetRotation *= Quaternion.AngleAxis(90f, Vector3.right);
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSmooth * Time.deltaTime);

        //isRotating = transform.eulerAngles != targetAngle;

        isRotating = !(Mathf.Approximately(transform.rotation.x, targetRotation.x))
             || !(Mathf.Approximately(transform.rotation.y, targetRotation.y));
    }
}
