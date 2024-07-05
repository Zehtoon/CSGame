using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int Health;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public bool isDead = false;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    public bool isAttacked = false;
    [SerializeField]
    public float attackCooldwn = 2.0f;
    [SerializeField]
    private float lastAttackTime = -2.0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }
   

    public void TakeDamage(int damage){
        
        GetComponent<DamageEffect>().ApplyDamageEffect();
        Health -= damage;
        if (!isAttacked){
            StartCoroutine(AttackAnimation());
        }
        if (Health <= 0)
        {
            animator.SetTrigger("isDead");
            rb.bodyType = RigidbodyType2D.Static;
            StartCoroutine(DeadDestroy());
                
        }           
        

    }
    
    private IEnumerator DeadDestroy(){
        yield return new WaitForSeconds(0.5f);
        Destroy(rb.gameObject);
    } 
    private IEnumerator AttackAnimation(){
        isAttacked = true;
        animator.SetBool("isAttacked", true);
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("isAttacked", false);
        isAttacked = false;
    }

    
}
