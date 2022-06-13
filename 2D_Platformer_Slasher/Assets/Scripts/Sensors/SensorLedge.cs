using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorLedge : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsCheckLayer;
    [SerializeField] private float hitUpPosY;
    [SerializeField] private float hitDownPosY;
    [SerializeField] private float CheckDistance;
    [SerializeField] private float contactOffset;

    private RaycastHit2D hitUp;
    private RaycastHit2D hitDown;
    private RaycastHit2D hitAngle;
    private float angleCheckDistance;


    public bool detected;
    public bool hitAngleDetected;
 

    public float distanceHitX;
    public Vector2 pointAngle;


    public void Checking(int xDirect)
    {

        hitUp = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + hitUpPosY), Vector2.right * xDirect, CheckDistance, whatIsCheckLayer);
        hitDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + hitDownPosY), Vector2.right * xDirect, CheckDistance, whatIsCheckLayer);

        angleCheckDistance = hitUpPosY - hitDownPosY;
        

        if (!hitUp && hitDown)
        {
            detected = true;
            
            distanceHitX = hitDown.distance;


            hitAngle = Physics2D.Raycast(new Vector3(transform.position.x + (distanceHitX + contactOffset) * xDirect, transform.position.y + hitUpPosY), Vector2.down, angleCheckDistance, whatIsCheckLayer);

            if (hitAngle)
            {
                hitAngleDetected = true;
            }
            else
            {
                hitAngleDetected = false;
            }


            pointAngle = (new Vector2(hitAngle.point.x - (contactOffset * xDirect), hitAngle.point.y));
            
        }
        else
        {
            pointAngle = Vector2.zero;
            distanceHitX = 0.0f;
            hitAngleDetected = false;
            detected = false;
        }


        drawDirection = xDirect;
    }


    private int drawDirection;
    private void OnDrawGizmos()
    {
        

        if (hitUp)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitUpPosY), new Vector2(transform.position.x + CheckDistance * drawDirection, transform.position.y + hitUpPosY));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitUpPosY), new Vector2(transform.position.x + CheckDistance * drawDirection, transform.position.y + hitUpPosY));
            
        }

        if (hitDown)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitDownPosY), new Vector2(transform.position.x + CheckDistance * drawDirection, transform.position.y + hitDownPosY));

        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitDownPosY), new Vector2(transform.position.x + CheckDistance * drawDirection, transform.position.y + hitDownPosY));
        }

        if(!hitUp && hitDown)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x + (distanceHitX + contactOffset) * drawDirection, transform.position.y + hitUpPosY), new Vector2(transform.position.x + (distanceHitX + contactOffset) * drawDirection, transform.position.y + hitUpPosY - angleCheckDistance));
        }

    }
}
