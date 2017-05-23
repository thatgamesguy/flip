using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles line drawing. Stores data for a line.
/// </summary>
public class Line : MonoBehaviour
{
    /// <summary>
    /// Start position in world space. Calculates new line position when value changed.
    /// </summary>
    /// <value>The start position.</value>
    public Vector2 start
    {
        get
        {
            return startPosition;
        }
        set
        {
            startPosition = value;
            UpdatePosition();
        }
    }

    /// <summary>
    /// End position in world space. Calculates new line position when value changed.
    /// </summary>
    /// <value>The end position.</value>
    public Vector2 end
    {
        get
        {
            return endPosition;
        }
        set
        {
            endPosition = value;
            UpdatePosition();
        }
    }

    /// <summary>
    /// Width of line. Updates sprite renderer when value changed.
    /// </summary>
    /// <value>The width.</value>
    public float width
    {
        get { return lineWidth; }
        set
        {
            lineWidth = value;
            UpdateWidth();
        }
    }

    /// <summary>
    /// Line color. Updates sprite renderer color when value changed.
    /// </summary>
    /// <value>The color.</value>
    public Color color
    {
        get { return lineColor; }
        set
        {
            lineColor = value;
            Debug.Log("Not updating colour");
            //UpdateColor();
        }
    }

    private static readonly float LINE_HEIGHT = 0.1f;

    private Vector2 startPosition;
    private Vector2 endPosition;
    private float lineWidth;
    private Color lineColor;
    //private SpriteRenderer lineRenderer;

        /*
    void Awake()
    {
        lineRenderer = GetComponent<SpriteRenderer>();
    }
    */

    /// <summary>
    /// Initialise the specified start, end, width and color of sprite.
    /// </summary>
    /// <param name="start">Start position.</param>
    /// <param name="end">End position.</param>
    /// <param name="width">Width.</param>
    /// <param name="color">Color.</param>
    public void Initialise(Vector2 start, Vector2 end, float width, Color color)
    {
        startPosition = start;
        endPosition = end;
        lineWidth = width;
        lineColor = color;

        UpdatePosition();
        UpdateWidth();
        //UpdateColor();
    }

    private void UpdatePosition()
    {
        var heading = endPosition - startPosition;
        var distance = heading.magnitude;

        Vector3 centerPos = new Vector3(startPosition.x + endPosition.x, startPosition.y + endPosition.y) / 2;

        centerPos.z -= LINE_HEIGHT * 0.5f;

        transform.position = centerPos;
        transform.localScale = new Vector3(lineWidth, distance, LINE_HEIGHT);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, endPosition - startPosition);
    }

    private void UpdateWidth()
    {
        transform.localScale = transform.localScale.WithX(lineWidth);
    }

    /*
    private void UpdateColor()
    {
        lineRenderer.color = lineColor;
    }
    */
}
