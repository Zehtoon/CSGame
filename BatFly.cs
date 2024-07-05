using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFly : MonoBehaviour
{
    
    public Transform targetPoint;
    public float speed = 5f;
    private Animator animator;
    private bool isFlying = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(isFlying){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
            Debug.Log($"Current Position: {transform.position} | Target: {targetPoint.position} | Distance: {Vector3.Distance(transform.position, targetPoint.position)}");

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
            {
                Debug.Log("Reached endpoint.");
                //Arrived at the end point
                isFlying = false;
                animator.SetBool("IsFlying", isFlying);
                transform.position = targetPoint.position;
                
            }
        }
        
    }

    public void TriggerFly(Transform startPoint, Transform endPoint)
    {
        transform.position = startPoint.position;
        targetPoint = endPoint;
        isFlying = true;
        animator.SetBool("IsFlying", isFlying);
    }
}
