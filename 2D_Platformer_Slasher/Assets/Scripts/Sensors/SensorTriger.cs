using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTriger : MonoBehaviour
{
    [SerializeField]
    private LayerMask whatIsCheckLayer;
    public bool detected;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision != null)
        {
            detected = ((1<< collision.gameObject.layer) & whatIsCheckLayer) != 0;
        }  
 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detected = false;
    }
}
