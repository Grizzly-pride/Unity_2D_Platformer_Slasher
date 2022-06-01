using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorSurface : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsCheckLayer;
    [SerializeField] private float hitPositionX1;
    [SerializeField] private float hitPositionX2;
    [SerializeField] private float CheckDistance;
    private RaycastHit2D hit1;
    private RaycastHit2D hit2;
    public bool detected;
    public bool isOnSlope;
    public float tiltAngle;
    public Vector2 slopeDirection;


    public void CheckSurface()
    {

        hit1 = Physics2D.Raycast(new Vector2(transform.position.x + hitPositionX2, transform.position.y), Vector2.down, CheckDistance, whatIsCheckLayer);
        hit2 = Physics2D.Raycast(new Vector2(transform.position.x + hitPositionX1, transform.position.y), Vector2.down, CheckDistance, whatIsCheckLayer);

        
        if (hit1 || hit2)
        {
            detected = true;

            if (hit1 && !hit2)
            {
                tiltAngle = Vector2.Angle(hit1.normal, Vector2.up);
                slopeDirection = Vector2.Perpendicular(hit1.normal).normalized;
             
            }
            else if (hit2 && !hit1)  
            {
                tiltAngle = Vector2.Angle(hit2.normal, Vector2.up);
                slopeDirection = Vector2.Perpendicular(hit2.normal).normalized;              
            }
            else
            {
                tiltAngle = 0;
            }


            if (tiltAngle != 0)
            {               
                isOnSlope = true;
            }
            else
            {
                isOnSlope = false;
            }
        }
        else
        {
            tiltAngle = 0;
            detected = false;
            isOnSlope = false;
        }
        
    }


    private void OnDrawGizmos()
    {
        if (detected)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.blue;
        }

       
        Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionX2, transform.position.y), new Vector2(transform.position.x + hitPositionX2, transform.position.y - CheckDistance));
        Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionX1, transform.position.y), new Vector2(transform.position.x + hitPositionX1, transform.position.y - CheckDistance));

    }

}
