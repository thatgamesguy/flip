using System;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    public float rotateSmooth = 2f;  

    public Action onRotationStarted;
    public Action onRotationFinished;
    
    private Quaternion targetRotation;
    private bool startedRotating;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    public void RotateLeft()
    {
        targetRotation *= Quaternion.AngleAxis(90f, Vector3.up);

        if(onRotationStarted != null)
        {
            onRotationStarted();
        }

        startedRotating = true;
    }

    public void RotateRight()
    {
        targetRotation *= Quaternion.AngleAxis(-90f, Vector3.up);

        if (onRotationStarted != null)
        {
            onRotationStarted();
        }

        startedRotating = true;
    }

    public void RotateDown()
    {
        targetRotation *= Quaternion.AngleAxis(-90f, Vector3.right);

        if (onRotationStarted != null)
        {
            onRotationStarted();
        }

        startedRotating = true;
    }

    public void RotateUp()
    {
        targetRotation *= Quaternion.AngleAxis(90f, Vector3.right);

        if (onRotationStarted != null)
        {
            onRotationStarted();
        }

        startedRotating = true;
    }

    void Update()
    {
        if(startedRotating)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSmooth * Time.deltaTime);

            if (transform.rotation.x.IsApproximately(targetRotation.x) &&
                transform.rotation.y.IsApproximately(targetRotation.y))
            {
                startedRotating = false;

                transform.rotation = targetRotation;

                if(onRotationFinished != null)
                {
                    onRotationFinished();
                }
            }
        }
    }
}
