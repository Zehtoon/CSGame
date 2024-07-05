using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHealthanager : MonoBehaviour
{
    public int attack;
    private Rigidbody2D rb;
    public int maxHealth = 100;
    public int currentHealth ;
    public Health healthBar ;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }   
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void DealDamage(GameObject target)
    {
        var trgt = target.GetComponent<AttackHealthanager>();
        if(trgt != null){
            trgt.TakeDamage(attack);
        }
    }
}
