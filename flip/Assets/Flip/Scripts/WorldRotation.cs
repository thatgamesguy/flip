using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    public float rotateSmooth = 2f;

    private Vector3 targetAngle;

    public void RotateLeft()
    {
        targetAngle = transform.eulerAngles + 180f * Vector3.up;
        print("here");
    }

    void Update()
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngle, rotateSmooth * Time.deltaTime);
    }

}
