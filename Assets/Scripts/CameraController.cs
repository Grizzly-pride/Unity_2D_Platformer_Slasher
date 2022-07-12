using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public BoxCollider2D boundsBox;
    public float smoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;
    private float halfHeight, halfWidth;

    private void Start()
    {
        
 
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            //Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            
            Vector3 targetPosition = new Vector3(
                Mathf.Clamp(target.position.x, boundsBox.bounds.min.x + halfWidth, boundsBox.bounds.max.x - halfWidth),
                Mathf.Clamp(target.position.y, boundsBox.bounds.min.y + halfHeight, boundsBox.bounds.max.y - halfHeight),
                transform.position.z);
            
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

    }

}
