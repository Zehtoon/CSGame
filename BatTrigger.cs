using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    public BatFly batToTrigger;
    public Transform startPoint;
    public Transform endPoint;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            batToTrigger.TriggerFly(startPoint, endPoint);
        }
    }
}
