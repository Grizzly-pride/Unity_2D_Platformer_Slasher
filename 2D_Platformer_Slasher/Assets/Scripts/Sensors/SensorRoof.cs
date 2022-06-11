using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorRoof : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsCheckLayer;
    [SerializeField] private float hitPositionLeft;
    [SerializeField] private float hitPositionRight;
    [SerializeField] private float CheckDistance;


    private RaycastHit2D hitRight;
    private RaycastHit2D hitLeft;

    public bool detected;


    public void Checking()
    {
        hitLeft = Physics2D.Raycast(new Vector2(transform.position.x + hitPositionLeft, transform.position.y), Vector2.up, CheckDistance, whatIsCheckLayer);
        hitRight = Physics2D.Raycast(new Vector2(transform.position.x + hitPositionRight, transform.position.y), Vector2.up, CheckDistance, whatIsCheckLayer);


        if (hitLeft || hitRight)
        {
            detected = true;
        }
        else
        {
            detected = false;
        }

    }

    private void OnDrawGizmos()
    {
        
        if (hitLeft)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionLeft, transform.position.y), new Vector2(transform.position.x + hitPositionLeft, transform.position.y + CheckDistance));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionLeft, transform.position.y), new Vector2(transform.position.x + hitPositionLeft, transform.position.y + CheckDistance));
        }


        if (hitRight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionRight, transform.position.y), new Vector2(transform.position.x + hitPositionRight, transform.position.y + CheckDistance));
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(new Vector2(transform.position.x + hitPositionRight, transform.position.y), new Vector2(transform.position.x + hitPositionRight, transform.position.y + CheckDistance));
        }



    }
}
