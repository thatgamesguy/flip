using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineFactory))]
public class LineDrawer : MonoBehaviour
{
    public LayerMask worldMask;
    public Transform lineContainer;
    public Player player;
    public WorldRotation worldRotation;

    private static readonly float MAX_PLAYER_DIST = 0.8f;
    private static readonly float LINE_MAX_LENGTH = 0.25f;

    private LineFactory lineFactory;
    private Line drawnLine;
    private bool listenForSwipes = true;

    void Awake()
    {
        lineFactory = GetComponent<LineFactory>();
    }

    void OnEnable()
    {
        worldRotation.onRotationStarted += OnWorldRotationStarted;
        worldRotation.onRotationFinished += OnWorldRotationFinished;
    }

    void OnDisable()
    {
        worldRotation.onRotationStarted -= OnWorldRotationStarted;
        worldRotation.onRotationFinished -= OnWorldRotationFinished;
    }

    void Update()
    {
        print(listenForSwipes);

        if (!listenForSwipes)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, worldMask))
            {
                if (Vector3.Distance(player.transform.position, hit.point) > MAX_PLAYER_DIST)
                {
                    return;
                }

                drawnLine = lineFactory.GetLine(player.transform.position, hit.point, 0.1f, Color.black);
                drawnLine.transform.SetParent(lineContainer, true);

                player.RemoveAllWaypoints();
                player.AddWaypoint(drawnLine);
            }
        }
        else if (Input.GetMouseButton(0))
        {
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

                        player.AddWaypoint(drawnLine);
                    }
                    else
                    {
                        drawnLine.end = hit.point;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            drawnLine = null;
        }
    }

    private void OnWorldRotationStarted()
    {
        print("line drawer: world rotation started");

        listenForSwipes = false;

        drawnLine = null;
    }

    private void OnWorldRotationFinished()
    {
        print("line drawer: world rotation finished");

        listenForSwipes = true;
    }
}
