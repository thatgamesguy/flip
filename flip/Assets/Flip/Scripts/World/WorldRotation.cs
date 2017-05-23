using System;
using System.Collections;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    public float rotationTime = 0.8f;  

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
        if(startedRotating)
        {
            return;
        }

        targetRotation *= Quaternion.AngleAxis(90f, Vector3.up);

        StartCoroutine(RotateToTarget());

        if(onRotationStarted != null)
        {
            onRotationStarted();
        }
    }

    public void RotateRight()
    {
        if(startedRotating)
        {
            return;
        }

        targetRotation *= Quaternion.AngleAxis(-90f, Vector3.up);

        StartCoroutine(RotateToTarget());

        if (onRotationStarted != null)
        {
            onRotationStarted();
        }
    }

    public void RotateDown()
    {
        if (startedRotating)
        {
            return;
        }

        targetRotation *= Quaternion.AngleAxis(-90f, Vector3.right);

        StartCoroutine(RotateToTarget());

        if (onRotationStarted != null)
        {
            onRotationStarted();
        }
    }

    public void RotateUp()
    {
        if (startedRotating)
        {
            return;
        }

        targetRotation *= Quaternion.AngleAxis(90f, Vector3.right);

        StartCoroutine(RotateToTarget());

        if (onRotationStarted != null)
        {
            onRotationStarted();
        }
    }

    private IEnumerator RotateToTarget()
    {
        startedRotating = true; 

        for (float t = 0.0f; t < rotationTime; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t / rotationTime);

            yield return null;
        }

        startedRotating = false;

        transform.rotation = targetRotation;

        if (onRotationFinished != null)
        {
            onRotationFinished();
        }
    }
}
