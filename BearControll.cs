using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearControll : MonoBehaviour
{
    public float speed;
    public Transform pointA;
    public Transform pointB;
    private Transform targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBear();
        FlipEnemy();
    }

    void MoveBear()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            if (targetPoint == pointA)
            {
                targetPoint = pointB;
            }
            else
            {
                targetPoint = pointA;
            }
        }
    }

    void FlipEnemy()
    {
        if (targetPoint.position.x > transform.position.x)
        {
        // Target is to the right, ensure the character is facing right
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (targetPoint.position.x < transform.position.x)
        {
            // Target is to the left, ensure the character is facing left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
}

    

}
