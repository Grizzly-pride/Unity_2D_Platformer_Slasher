using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCollision : MonoBehaviour
{
    [SerializeField] private bool checkOr;
    [SerializeField] private LayerMask whatIsCheckLayerHit1;
    [SerializeField] private LayerMask whatIsCheckLayerHit2;
    [SerializeField] private Vector2 hitPosition1;
    [SerializeField] private Vector2 hitPosition2;
    [SerializeField] private float CheckDistance;
    [SerializeField] private Vector2 direction1;
    [SerializeField] private Vector2 direction2;

    private RaycastHit2D hit1;
    private RaycastHit2D hit2;
    public bool detected;

    private int objectDirection;
   

    public void CheckCollision(int faceDirection)
    {
        objectDirection = faceDirection;
       
        hit1 = Physics2D.Raycast(new Vector2(transform.position.x + hitPosition1.x, transform.position.y + hitPosition1.y), direction1 * objectDirection, CheckDistance, whatIsCheckLayerHit1);
        hit2 = Physics2D.Raycast(new Vector2(transform.position.x + hitPosition2.x, transform.position.y + hitPosition2.y), direction2 * objectDirection, CheckDistance, whatIsCheckLayerHit2);

        if (checkOr)
        {
            if (hit1 || hit2)
            {
                detected = true;
            }
            else
            {

                detected = false;
            }
        }
        else
        {
            if (hit1 && hit2)
            {
                detected = true;
            }
            else
            {

                detected = false;
            }
        }
    }

    public void CheckCollision()
    {

        hit1 = Physics2D.Raycast(new Vector2(transform.position.x + hitPosition1.x, transform.position.y + hitPosition1.y), direction1, CheckDistance, whatIsCheckLayerHit1);
        hit2 = Physics2D.Raycast(new Vector2(transform.position.x + hitPosition2.x, transform.position.y + hitPosition2.y), direction2, CheckDistance, whatIsCheckLayerHit2);

        if (checkOr)
        {
            if (hit1 || hit2)
            {
                detected = true;
            }
            else
            {

                detected = false;
            }
        }
        else
        {
            if (hit1 && hit2)
            {
                detected = true;
            }
            else
            {

                detected = false;
            }
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
       

        if (direction1.y > 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPosition1.x, transform.position.y + hitPosition1.y), new Vector2(transform.position.x + hitPosition1.x, transform.position.y + CheckDistance));
        }
        else if(direction1.y < 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPosition1.x, transform.position.y + hitPosition1.y), new Vector2(transform.position.x + hitPosition1.x, transform.position.y - CheckDistance));

        }
        else if (direction1.x > 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPosition1.x * objectDirection, transform.position.y + hitPosition1.y), new Vector2(transform.position.x + CheckDistance * objectDirection, transform.position.y + hitPosition1.y));

        }
        else if (direction1.x < 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPosition1.x * objectDirection, transform.position.y + hitPosition1.y), new Vector2(transform.position.x - CheckDistance * objectDirection, transform.position.y + hitPosition1.y));
        }


        if (direction2.y > 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPosition2.x, transform.position.y + hitPosition2.y), new Vector2(transform.position.x + hitPosition2.x, transform.position.y + CheckDistance));
        }
        else if (direction2.y < 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPosition2.x, transform.position.y + hitPosition2.y), new Vector2(transform.position.x + hitPosition2.x, transform.position.y - CheckDistance));

        }
        else if (direction2.x > 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPosition2.x * objectDirection, transform.position.y + hitPosition2.y), new Vector2(transform.position.x + CheckDistance * objectDirection, transform.position.y + hitPosition2.y));

        }
        else if (direction2.x < 0)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPosition2.x * objectDirection, transform.position.y + hitPosition2.y), new Vector2(transform.position.x - CheckDistance * objectDirection, transform.position.y + hitPosition2.y));
        }
    }

}
