using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private float Y_ANGLE_MIN = 0.0f;
    private float Y_ANGLE_MAX = 50.0f;
    public Transform lookAt;
    public float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 45.0f;
    public bool FollowPlayerOrientation;
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 Orientation = rotation.eulerAngles;
        transform.position = lookAt.position + Quaternion.Euler(Orientation) * dir;
        transform.LookAt(lookAt.position);
    }
}