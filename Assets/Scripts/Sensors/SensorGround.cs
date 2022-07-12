using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorGround : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsCheckLayer;

    [SerializeField] private float hitPositionRight;
    [SerializeField] private float hitPositionleft;
    [SerializeField] private float CheckDistance;

    [SerializeField] private float hitPositionRightAuxiliary;
    [SerializeField] private float hitPositionleftAuxiliary;


    private RaycastHit2D hitRight;
    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRightAuxiliary;
    private RaycastHit2D hitLeftAuxiliary;


    public bool detected;
    public bool isOnSlope;
    public float hitRightTiltAngle;
    public float hitLeftTiltAngle;
    public Vector2 slopeDirection;


    public void Checking()
    {

        hitRight = Physics2D.Raycast(new Vector2(transform.position.x + hitPositionRight, transform.position.y), Vector2.down, CheckDistance, whatIsCheckLayer);
        hitLeft = Physics2D.Raycast(new Vector2(transform.position.x + hitPositionleft, transform.position.y), Vector2.down, CheckDistance, whatIsCheckLayer);
        hitRightAuxiliary = Physics2D.Raycast(new Vector2(transform.position.x + hitPositionRightAuxiliary, transform.position.y), Vector2.down, CheckDistance, whatIsCheckLayer);
        hitLeftAuxiliary = Physics2D.Raycast(new Vector2(transform.position.x + hitPositionleftAuxiliary, transform.position.y), Vector2.down, CheckDistance, whatIsCheckLayer);

        
        if (hitRight || hitLeft)
        {
            detected = true;    

            if (hitRight)
            {
                hitRightTiltAngle = Vector2.Angle(hitRight.normal, Vector2.up.normalized);
            }
            else
            {
                hitRightTiltAngle = 0.0f;
            }

            if (hitLeft)
            {
                hitLeftTiltAngle = Vector2.Angle(hitLeft.normal, Vector2.up.normalized);
            }
            else
            {
                hitLeftTiltAngle = 0.0f;
            }




            if (!hitRightTiltAngle.Equals(0) && hitRightAuxiliary)
            {
                isOnSlope = true;
                slopeDirection = Vector2.Perpendicular(hitRight.normal).normalized;
            }
            else if (!hitLeftTiltAngle.Equals(0) && hitLeftAuxiliary)
            {
                isOnSlope = true;
                slopeDirection = Vector2.Perpendicular(hitLeft.normal).normalized;
            }
            else 
            {
                isOnSlope = false;
            }

        }
        else
        {
            hitRightTiltAngle = 0.0f;
            hitLeftTiltAngle = 0.0f;
            detected = false;
            isOnSlope = false;
        }
        

    }
    

    private void OnDrawGizmos()
    {
        
        if (hitRight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionRight, transform.position.y), new Vector2(transform.position.x + hitPositionRight, transform.position.y - CheckDistance));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionRight, transform.position.y), new Vector2(transform.position.x + hitPositionRight, transform.position.y - CheckDistance));
        }

        if (hitLeft)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionleft, transform.position.y), new Vector2(transform.position.x + hitPositionleft, transform.position.y - CheckDistance));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionleft, transform.position.y), new Vector2(transform.position.x + hitPositionleft, transform.position.y - CheckDistance));
        }

        if (hitRightAuxiliary)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionRightAuxiliary, transform.position.y), new Vector2(transform.position.x + hitPositionRightAuxiliary, transform.position.y - CheckDistance));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionRightAuxiliary, transform.position.y), new Vector2(transform.position.x + hitPositionRightAuxiliary, transform.position.y - CheckDistance));
        }

        if (hitLeftAuxiliary)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionleftAuxiliary, transform.position.y), new Vector2(transform.position.x + hitPositionleftAuxiliary, transform.position.y - CheckDistance));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionleftAuxiliary, transform.position.y), new Vector2(transform.position.x + hitPositionleftAuxiliary, transform.position.y - CheckDistance));
        }


    }

}
