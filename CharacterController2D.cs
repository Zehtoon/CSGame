using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    //player handling
    private Rigidbody2D rb;
    [SerializeField]
    private float Speed ;
    [SerializeField]
    private float jump;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    [SerializeField]
    public float attackRange;
    [SerializeField]
    public int damage=10;
    private bool facingRight = true;
    private AudioManager audioManager;
    //ground checkers:
    //using the Command Pattern
    private ICommand moveLeftCommand;
    private ICommand moveRightCommand;
    private ICommand JumpCommand;

    
   
    private void Awake()
    {
        audioManager = ServiceLocator.Get<AudioManager>();
        //Initialize the commands
        moveLeftCommand = new MoveLeftCommand();
        moveRightCommand = new MoveRightCommand();
        JumpCommand = new JumpCommand();
    }
    void Start()
    {
        Debug.Log("Starting");

        
        rb = gameObject.GetComponent<Rigidbody2D>();
        Speed = 0.7f;
        jump = 30f;
        isJumping = false; 
        

    }
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * Speed;
        moveVertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        Flip(moveHorizontal);

        

        if (Input.GetKeyDown(KeyCode.G) && !isJumping) // Prevent attacking mid-air if desired
        {
            Attack();
        }
        if (animator.GetBool("isAttacking")){
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Attack_1") && stateInfo.normalizedTime >= 1.0f){
                endAttack();
            }

        }
       
        
    }
    
    
     void FixedUpdate(){
        if ( moveHorizontal <0f){
            moveLeftCommand.Execute(rb, Speed, jump, isJumping, moveHorizontal, moveVertical);
        }
        else if(moveHorizontal > 0f){
            moveRightCommand.Execute(rb, Speed, jump, isJumping, moveHorizontal, moveVertical);
        }
        if(moveVertical > 0f){
            JumpCommand.Execute(rb, Speed, jump, isJumping, moveHorizontal, moveVertical);
        }

     }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform" || collision.gameObject.tag == "jumpTrap")
        {
            Debug.Log("Jumping is false");
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
            if(collision.gameObject.tag == "jumpTrap"){
                audioManager.PlaySFX(audioManager.jumpBounce);
                jump *= 2f;
            }
        }

        // if(collision.gameObject.tag == "PinkGem")
        // {
        //     collectPinkGem();
        //     Debug.Log("pink gem collected");
        // }
    }



    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform" || collision.gameObject.tag == "jumpTrap")
        {
            Debug.Log("Jumping is true");
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
            if(collision.gameObject.tag == "jumpTrap"){
                jump /= 2f;
            }
 
        }
    }
    void Attack()
{
    audioManager.PlaySFX(audioManager.Attack);
    if (!animator.GetBool("isAttacking")) // Prevent re-triggering the attack while already attacking
    {
        Debug.Log("Attack initiated");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        Debug.Log("Number of enemies detected: " + enemiesToDamage.Length);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            Enemy enemy = enemiesToDamage[i].GetComponent<Enemy>();
            if (enemy != null){
                enemy.TakeDamage(damage);
            }else{
                Debug.Log("Enemy component not found on attacked object");
            }
        }
        animator.SetBool("isAttacking", true);
    }
}
    public void endAttack(){
        animator.SetBool("isAttacking", false);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void Flip(float moveHorizontal){
        if(moveHorizontal > 0 && !facingRight){
            FlipCharacter();
        }
        else if(moveHorizontal < 0 && facingRight){
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1 ;
        transform.localScale = theScale;
    }

   

 

}

