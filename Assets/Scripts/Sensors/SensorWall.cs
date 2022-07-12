using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorWall : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsCheckLayerHitUp;
    [SerializeField] private LayerMask whatIsCheckLayerHitDown;
    [SerializeField] private float hitUpPosY;
    [SerializeField] private float hitDownPosY;
    [SerializeField] private float CheckDistance;

    private RaycastHit2D hitUpRight;
    private RaycastHit2D hitDownRight;
    private RaycastHit2D hitUpLeft;
    private RaycastHit2D hitDownLeft;

    public bool detected;
    public float startHitUp;
    public Vector2 pointHit;
    public bool rightSide;
    public bool leftSide;

    public void Checking(int xDirect)
    {

        hitUpRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + hitUpPosY), Vector2.right, CheckDistance, whatIsCheckLayerHitUp);
        hitDownRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + hitDownPosY), Vector2.right, CheckDistance, whatIsCheckLayerHitDown);
        hitUpLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + hitUpPosY), Vector2.left, CheckDistance, whatIsCheckLayerHitUp);
        hitDownLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + hitDownPosY), Vector2.left, CheckDistance, whatIsCheckLayerHitDown);

        startHitUp = hitUpPosY;


        if (xDirect.Equals(1))
        {
            if(hitUpRight && hitDownRight)
            {
                detected = true;
                rightSide = true;
                pointHit = hitUpRight.point;
            }
            else
            {
                rightSide = false;
                leftSide = false;
                detected = false;
            }

        }
        else if (xDirect.Equals(-1))
        {
            if (hitUpLeft && hitDownLeft)
            {
                detected = true;
                leftSide = true;
                pointHit = hitUpLeft.point;
            }
            else
            {
                rightSide = false;
                leftSide = false;
                detected = false;
            }

        }


    }

    private void OnDrawGizmos()
    {


        if (hitUpRight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitUpPosY), new Vector2(transform.position.x + CheckDistance, transform.position.y + hitUpPosY));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitUpPosY), new Vector2(transform.position.x + CheckDistance, transform.position.y + hitUpPosY));
        }

        if (hitDownRight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitDownPosY), new Vector2(transform.position.x + CheckDistance, transform.position.y + hitDownPosY));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitDownPosY), new Vector2(transform.position.x + CheckDistance, transform.position.y + hitDownPosY));
        }

        if (hitUpLeft)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitUpPosY), new Vector2(transform.position.x - CheckDistance, transform.position.y + hitUpPosY));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitUpPosY), new Vector2(transform.position.x - CheckDistance, transform.position.y + hitUpPosY));
        }

        if (hitDownLeft)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitDownPosY), new Vector2(transform.position.x - CheckDistance, transform.position.y + hitDownPosY));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + hitDownPosY), new Vector2(transform.position.x - CheckDistance, transform.position.y + hitDownPosY));
        }



    }
}
