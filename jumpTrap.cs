using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrap : MonoBehaviour
{
    public Animator animator;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            StartCoroutine(jumpTrapAnimation());
        }
    }
    
    private IEnumerator jumpTrapAnimation(){
        animator.SetBool("jumpTrap", true);
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("jumpTrap", false);
    }
}
