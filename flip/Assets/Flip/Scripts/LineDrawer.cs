using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineFactory))]
public class LineDrawer : MonoBehaviour
{
    public LayerMask worldMask;
    public WorldRotation world;
    public Transform lineContainer;
    public Player player;

    private static readonly float LINE_MAX_LENGTH = 0.25f;

    private LineFactory lineFactory;
    private Line drawnLine;

    // Use this for initialization
    void Awake()
    {
        lineFactory = GetComponent<LineFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, worldMask))
            {
                Vector3 startPos = hit.point;

                if (drawnLine == null)
                {
                    if (Vector3.Distance(player.transform.position, hit.point) > LINE_MAX_LENGTH)
                    {
                        return;
                    }

                    startPos = player.transform.position;
                }

                drawnLine = lineFactory.GetLine(startPos, hit.point, 0.1f, Color.black);
                drawnLine.transform.SetParent(lineContainer, true);

                player.AddWayPoint(startPos);
            }
        }

        if (drawnLine != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, worldMask))
            {
                if (Vector3.Distance(drawnLine.start, drawnLine.end) > LINE_MAX_LENGTH)
                {
                    drawnLine = lineFactory.GetLine(drawnLine.end, hit.point, 0.1f, Color.black);
                    drawnLine.transform.SetParent(lineContainer, true);

                    player.AddWayPoint(drawnLine.end);
                }
                else
                {
                    drawnLine.end = hit.point;
                }
            }
            else
            {
                //world.RotateLeft();
                //drawnLine = null;
            }
        }
    }
}
