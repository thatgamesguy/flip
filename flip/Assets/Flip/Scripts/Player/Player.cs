using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    private List<Vector3> waypoints = new List<Vector3>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count > 0)
        {
            transform.position += ((waypoints[0] - transform.position).normalized * moveSpeed * Time.deltaTime).WithZ(0f);

            if (Vector3.Distance(transform.position, waypoints[0]) < 0.2f)
            {
                waypoints.RemoveAt(0);
            }

        }
    }

    public void AddWayPoint(Vector3 position)
    {
        waypoints.Add(position);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Platform Chunk"))
        {
            other.GetComponent<PlatformChunk>().Remove();
        }
    }
}
