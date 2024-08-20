using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    public Transform target; // The object to rotate around
    public float distance = 5.0f; // Distance from the target
    public float rotationSpeed = 10.0f; // Speed of rotation

    private Vector3 offset;

    void Start()
    {
        // Set the initial position of the camera
        offset = new Vector3(0, 0, -distance);
        transform.position = target.position + offset;
    }

    void Update()
    {
        // Automatically rotate the camera around the target object
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);

        // Maintain the distance from the target
        offset = transform.position - target.position;
        offset = offset.normalized * distance;
        transform.position = target.position + offset;

        // Look at the target
        transform.LookAt(target);
    }
}