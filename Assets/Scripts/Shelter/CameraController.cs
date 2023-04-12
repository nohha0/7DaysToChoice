using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public float height;
    public float minX;
    public float maxX;


    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y + height, -10);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing * Time.deltaTime);
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);
        transform.position = smoothedPosition;
    }
}
