using UnityEngine;
using System.Collections.Generic;

public class CameraRig : MonoBehaviour
{
    public Transform waypointsParent;
    public AnimationCurve movementCurve;
    public float moveDuration = 5.0f;
    public bool loop = false;
    public bool vertical = false;
    public Transform Camera;

    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private float moveStartTime;
    private bool isMoving = false;


    void Start()
    {
        // Get all waypoints
        waypoints = new List<Transform>();
        foreach (Transform child in waypointsParent)
        {
            waypoints.Add(child);
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveAlongWaypoints();
        }

        if (vertical)
        {
            Camera.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
        else
        {
            Camera.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    void MoveAlongWaypoints()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            int nextWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            float t = (Time.time - moveStartTime) / moveDuration;
            float curveValue = movementCurve.Evaluate(t);

            transform.position = Vector3.Lerp(waypoints[currentWaypointIndex].position, waypoints[nextWaypointIndex].position, curveValue);
            transform.rotation = Quaternion.Lerp(waypoints[currentWaypointIndex].rotation, waypoints[nextWaypointIndex].rotation, curveValue);

            if (t >= 1.0f)
            {
                currentWaypointIndex = nextWaypointIndex;
                moveStartTime = Time.time;

                if (currentWaypointIndex == 0 && !loop)
                {
                    isMoving = false;
                }
            }
        }
    }

    [ContextMenu("Start Moving")]
    public void StartMoving()
    {
        if (waypoints.Count > 1)
        {
            currentWaypointIndex = 0;
            moveStartTime = Time.time;
            isMoving = true;
        }
    }
}
