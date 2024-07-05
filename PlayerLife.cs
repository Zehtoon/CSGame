using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    //player health
    [SerializeField]
    public int maxHealth = 100;
    [SerializeField]
    public bool isDead = false;
    [SerializeField]
    public int currentHealth ;
    [SerializeField]
    public Health healthBar ;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    private AudioManager audioManager ;
    [SerializeField]
    DamageEffect damageEffect ;



    //trying to implement a cool down for the player getting damaged
    private float damageCooldown = 2.0f;
    private bool canTakeDamage = true;

    // Variables for invincibility
    private bool isInvincible = false;
    private float invincibilityDuration = 10f;
    private float invincibilityTimer = 0f;



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        damageEffect = GetComponent<DamageEffect>();
    }
    
    private void Awake()
    {
        audioManager = ServiceLocator.Get<AudioManager>();
    }
    private void Update()
    {
        // Check if invincibility timer has expired
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
                damageEffect.ApplyDamageEffect();
            }
        }        
    }

    // Correct method signature for collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Checking collision");
        if (collision.gameObject.CompareTag("PinkGem"))
        {
            Debug.Log("PinkGem collision detected");
            Destroy(collision.gameObject);
            collectPinkGem();
        }
        if(!isInvincible){
            if (collision.gameObject.CompareTag("Eagle"))
            {
                audioManager.PlaySFX(audioManager.Hurt);
                StartCoroutine(Damaged(50));
            }
            else if (collision.gameObject.CompareTag("Dog"))
            {
                Debug.Log("dog collided");
                audioManager.PlaySFX(audioManager.Hurt);
                StartCoroutine(Damaged(10));
            }
            else if (collision.gameObject.CompareTag("Slime"))
            {
                audioManager.PlaySFX(audioManager.Hurt);
                StartCoroutine(Damaged(5));
            }
            else if (collision.gameObject.CompareTag("Vulture")){
                audioManager.PlaySFX(audioManager.Hurt);
                StartCoroutine(Damaged(7));
            }
            else if(collision.gameObject.CompareTag("spikes")){
                audioManager.PlaySFX(audioManager.Hurt);
                StartCoroutine(Damaged(35));
            }
            else if(collision.gameObject.CompareTag("Dino")){
                audioManager.PlaySFX(audioManager.Hurt);
                StartCoroutine(Damaged(20));
            }            
            else if(collision.gameObject.CompareTag("OutOfMap"))
            {
                StartCoroutine(Die());
            }
            
        }
        //taking damage differently depending on the enemy/NPC
       
    }
    void collectPinkGem(){
        
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
        damageEffect.ApplyInvincibilityEffect();
    }

    private IEnumerator Die()
    {
        audioManager.PlaySFX(audioManager.GameOver);
        rb.bodyType = RigidbodyType2D.Static; // This effectively "kills" the player by stopping all physics on them
        animator.SetTrigger("Dead");

        yield return new WaitForSeconds(0.6f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void TakeDamage(int damage){
        if(!isDead){
            animator.SetBool("Hurt",true);
            currentHealth -= damage;
            animator.SetInteger("currentHealth", currentHealth);
            // healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                animator.SetBool("isDead", true);
                isDead = true;
                StartCoroutine(Die());

            }
            animator.SetBool("Hurt", false);
        }
       
    }

    private IEnumerator Damaged(int damage)
    {
        if(!isDead){
            GetComponent<DamageEffect>().ApplyDamageEffect();
            animator.SetBool("Hurt",true);
            currentHealth -= damage;
            animator.SetInteger("currentHealth", currentHealth);
            if (healthBar != null) {
                healthBar.SetHealth(currentHealth);
            } else {
                Debug.LogError("healthBar reference is null.");
            }
            if (currentHealth <= 0)
            {
                audioManager.PlaySFX(audioManager.Death);
                animator.SetBool("Hurt" ,false);
                animator.SetBool("isDead", true);
                isDead = true;
                StartCoroutine(Die());

            }

            yield return new WaitForSeconds(0.4f);
            animator.SetBool("Hurt", false);
        }
    }

    public void SetupHealthUI(Health healthUIComponent)
    {
        healthBar = healthUIComponent;
        healthBar.MaxHealth(maxHealth); // Initialize the health bar UI
        healthBar.SetHealth(currentHealth); // Update the current health display
    }  

    public void GainHealth(int amount)
    {
        if(currentHealth < maxHealth){
            currentHealth += amount;
            currentHealth = Mathf.Min(currentHealth, maxHealth);
            if(healthBar != null){
                healthBar.SetHealth(currentHealth);
            }
        }
    }

}
