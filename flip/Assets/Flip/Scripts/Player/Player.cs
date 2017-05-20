using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public WorldRotation worldRotation;

    private List<Line> waypoints = new List<Line>();
    private int touchingPlatforms = 0;


    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count > 0)
        {
            transform.position += (((Vector3)waypoints[0].end - transform.position).normalized * moveSpeed * Time.deltaTime).WithZ(0f);

            if (Vector2.Distance(transform.position, waypoints[0].end) < 0.2f)
            {
                waypoints[0].gameObject.SetActive(false);
                waypoints.RemoveAt(0);
            }
        }
    }

    public void AddWaypoint(Line next)
    {
        waypoints.Add(next);
    }

    public void RemoveAllWaypoints()
    {
        if(waypoints.Count == 0)
        {
            return;
        }

        foreach(var waypoint in waypoints)
        {
            waypoint.gameObject.SetActive(false);
        }

        waypoints.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        if(worldRotation.isRotating)
        {
            return;
        }

        if (other.CompareTag("Platform Chunk"))
        {
            touchingPlatforms++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (worldRotation.isRotating)
        {
            return;
        }

        if (other.CompareTag("Platform Chunk"))
        {
            other.GetComponent<PlatformChunk>().Remove();

            touchingPlatforms--;

            if(touchingPlatforms <= 0)
            {
                Debug.Log("Player touching no platforms");
            }
        }
    }
}
