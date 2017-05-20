using UnityEngine;

public class WorldSwipeMovement : MonoBehaviour
{
    public WorldRotation worldRotation;

    public float minSwipeVelocity = 500f;
    public float minSwipeDistance = 50f;

    private static readonly Vector2 X_AXIS = new Vector2(1, 0);
    private static readonly Vector2 Y_AXIS = new Vector2(0, 1);

    // The angle range for detecting swipe
    private const float mAngleRange = 30;

    private Vector2 startPos;
    private float startTime;

    void Update()
    {
        /*
        if(worldRotation.isRotating)
        {
            return;
        }
        */

        if (Input.GetMouseButtonDown(0))
        {
            startPos = new Vector2(Input.mousePosition.x,
                                         Input.mousePosition.y);
            startTime = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            float deltaTime = Time.time - startTime;

            Vector2 endPosition = new Vector2(Input.mousePosition.x,
                                               Input.mousePosition.y);
            Vector2 swipeVector = endPosition - startPos;

            float velocity = swipeVector.magnitude / deltaTime;

            if (velocity > minSwipeVelocity &&
                swipeVector.magnitude > minSwipeDistance)
            {
                // if the swipe has enough velocity and enough distance

                swipeVector.Normalize();

                float angleOfSwipe = Vector2.Dot(swipeVector, X_AXIS);
                angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

                // Detect left and right swipe
                if (angleOfSwipe < mAngleRange)
                {
                    worldRotation.RotateRight();
                }
                else if ((180.0f - angleOfSwipe) < mAngleRange)
                {
                    worldRotation.RotateLeft();
                }
                else
                {
                    // Detect top and bottom swipe
                    angleOfSwipe = Vector2.Dot(swipeVector, Y_AXIS);
                    angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
                    if (angleOfSwipe < mAngleRange)
                    {
                        worldRotation.RotateUp();
                    }
                    else if ((180.0f - angleOfSwipe) < mAngleRange)
                    {
                        worldRotation.RotateDown();
                    }
                }
            }
        }
    }
}
